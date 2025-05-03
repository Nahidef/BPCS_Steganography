namespace BPCS_Steganography
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.btnEmbed = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.pictureBoxImage = new System.Windows.Forms.PictureBox();
			this.lblExtractedMessage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
			this.SuspendLayout();
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(265, 241);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(248, 22);
			this.txtMessage.TabIndex = 0;
			// 
			// btnEmbed
			// 
			this.btnEmbed.Location = new System.Drawing.Point(265, 307);
			this.btnEmbed.Name = "btnEmbed";
			this.btnEmbed.Size = new System.Drawing.Size(99, 23);
			this.btnEmbed.TabIndex = 1;
			this.btnEmbed.Text = "Mesajı Göm";
			this.btnEmbed.UseVisualStyleBackColor = true;
			this.btnEmbed.Click += new System.EventHandler(this.btnEmbed_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(406, 307);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(107, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Mesajı Çıkar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.btnExtract_Click);
			// 
			// pictureBoxImage
			// 
			this.pictureBoxImage.Location = new System.Drawing.Point(265, 12);
			this.pictureBoxImage.Name = "pictureBoxImage";
			this.pictureBoxImage.Size = new System.Drawing.Size(248, 191);
			this.pictureBoxImage.TabIndex = 3;
			this.pictureBoxImage.TabStop = false;
			// 
			// lblExtractedMessage
			// 
			this.lblExtractedMessage.AutoSize = true;
			this.lblExtractedMessage.Location = new System.Drawing.Point(351, 382);
			this.lblExtractedMessage.Name = "lblExtractedMessage";
			this.lblExtractedMessage.Size = new System.Drawing.Size(44, 16);
			this.lblExtractedMessage.TabIndex = 4;
			this.lblExtractedMessage.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(824, 494);
			this.Controls.Add(this.lblExtractedMessage);
			this.Controls.Add(this.pictureBoxImage);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnEmbed);
			this.Controls.Add(this.txtMessage);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnEmbed;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.PictureBox pictureBoxImage;
		private System.Windows.Forms.Label lblExtractedMessage;
	}
}

