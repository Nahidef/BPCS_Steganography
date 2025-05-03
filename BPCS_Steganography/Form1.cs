using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BPCS_Steganography
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnEmbed_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "Image Files (*.png)|*.png|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						string inputFilePath = ofd.FileName;
						string message = txtMessage.Text;
						string outputFilePath = Path.Combine(
							Path.GetDirectoryName(inputFilePath),
							"stego_" + Path.GetFileName(inputFilePath));

						using (Bitmap inputImage = new Bitmap(inputFilePath))
						{
							Bitmap outputImage = BPCSSteganography.EmbedMessage(inputImage, message);
							outputImage.Save(outputFilePath, System.Drawing.Imaging.ImageFormat.Png);
							MessageBox.Show("Message embedded successfully in PNG format");
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Error: {ex.Message}", "Embedding Failed",
									  MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btnExtract_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "Image Files (*.png)|*.png|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						using (Bitmap inputImage = new Bitmap(ofd.FileName))
						{
							pictureBoxImage.Image = new Bitmap(inputImage); 

							string extractedMessage = BPCSSteganography.ExtractMessage(inputImage);
							lblExtractedMessage.Text = "Extracted Message: " + extractedMessage;
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Error: {ex.Message}", "Extraction Failed",
									  MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

	}

	public static class BPCSSteganography
	{
		private const int LENGTH_HEADER_SIZE = 4; 

		public static Bitmap EmbedMessage(Bitmap inputImage, string message)
		{
			byte[] messageBytes = Encoding.UTF8.GetBytes(message);
			int messageLength = messageBytes.Length;

			
			int maxCapacity = (inputImage.Width * inputImage.Height) / 8 - LENGTH_HEADER_SIZE;
			if (messageLength > maxCapacity)
				throw new Exception($"Message too large. Max capacity: {maxCapacity} bytes");

			Bitmap outputImage = new Bitmap(inputImage);

			
			byte[] lengthBytes = BitConverter.GetBytes(messageLength);
			EmbedBytes(outputImage, lengthBytes, 0);

			
			EmbedBytes(outputImage, messageBytes, LENGTH_HEADER_SIZE * 8);

			return outputImage;
		}

		private static void EmbedBytes(Bitmap image, byte[] bytes, int startBitIndex)
		{
			int width = image.Width;
			int totalBits = bytes.Length * 8;

			for (int i = 0; i < totalBits; i++)
			{
				int bitIndex = startBitIndex + i;
				int x = bitIndex % width;
				int y = bitIndex / width;

				if (y >= image.Height) break;

				Color pixel = image.GetPixel(x, y);

				
				int bitValue = (bytes[i / 8] >> (7 - (i % 8))) & 1;

				int newR = (pixel.R & 0xFE) | bitValue;
				image.SetPixel(x, y, Color.FromArgb(newR, pixel.G, pixel.B));
			}
		}

		public static string ExtractMessage(Bitmap inputImage)
		{
			
			int messageLength = ExtractInt(inputImage, 0);
			if (messageLength <= 0 || messageLength > (inputImage.Width * inputImage.Height / 8) - LENGTH_HEADER_SIZE)
				throw new Exception("Invalid message length detected");

			
			byte[] messageBytes = new byte[messageLength];
			ExtractBytes(inputImage, messageBytes, LENGTH_HEADER_SIZE * 8);

			return Encoding.UTF8.GetString(messageBytes);
		}

		private static int ExtractInt(Bitmap image, int startBitIndex)
		{
			byte[] buffer = new byte[4];
			ExtractBytes(image, buffer, startBitIndex);
			return BitConverter.ToInt32(buffer, 0);
		}

		private static void ExtractBytes(Bitmap image, byte[] buffer, int startBitIndex)
		{
			int width = image.Width;
			int totalBits = buffer.Length * 8;

			for (int i = 0; i < totalBits; i++)
			{
				int bitIndex = startBitIndex + i;
				int x = bitIndex % width;
				int y = bitIndex / width;

				if (y >= image.Height) break;

				Color pixel = image.GetPixel(x, y);
				int bitValue = pixel.R & 1;

				buffer[i / 8] |= (byte)(bitValue << (7 - (i % 8)));
			}
		}
	}
}