namespace Playfair
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.rtbPlaintext = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbCiphtertext = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEncryp = new System.Windows.Forms.Button();
            this.btnDecryp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Short version of the Playfair Key";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(132, 216);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(398, 22);
            this.tbKey.TabIndex = 2;
            // 
            // rtbPlaintext
            // 
            this.rtbPlaintext.Location = new System.Drawing.Point(132, 40);
            this.rtbPlaintext.Name = "rtbPlaintext";
            this.rtbPlaintext.Size = new System.Drawing.Size(398, 125);
            this.rtbPlaintext.TabIndex = 3;
            this.rtbPlaintext.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Plaintext";
            // 
            // rtbCiphtertext
            // 
            this.rtbCiphtertext.Location = new System.Drawing.Point(132, 354);
            this.rtbCiphtertext.Name = "rtbCiphtertext";
            this.rtbCiphtertext.ReadOnly = true;
            this.rtbCiphtertext.Size = new System.Drawing.Size(398, 125);
            this.rtbCiphtertext.TabIndex = 3;
            this.rtbCiphtertext.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Plaintext";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ciphertext";
            // 
            // btnEncryp
            // 
            this.btnEncryp.Location = new System.Drawing.Point(271, 264);
            this.btnEncryp.Name = "btnEncryp";
            this.btnEncryp.Size = new System.Drawing.Size(118, 40);
            this.btnEncryp.TabIndex = 5;
            this.btnEncryp.Text = "Encryption";
            this.btnEncryp.UseVisualStyleBackColor = true;
            this.btnEncryp.Click += new System.EventHandler(this.btnEncryp_Click);
            // 
            // btnDecryp
            // 
            this.btnDecryp.Location = new System.Drawing.Point(412, 264);
            this.btnDecryp.Name = "btnDecryp";
            this.btnDecryp.Size = new System.Drawing.Size(118, 40);
            this.btnDecryp.TabIndex = 5;
            this.btnDecryp.Text = "Decryption";
            this.btnDecryp.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 547);
            this.Controls.Add(this.btnDecryp);
            this.Controls.Add(this.btnEncryp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbCiphtertext);
            this.Controls.Add(this.rtbPlaintext);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Playfair";
            this.Enter += new System.EventHandler(this.btnEncryp_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.RichTextBox rtbPlaintext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbCiphtertext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEncryp;
        private System.Windows.Forms.Button btnDecryp;
    }
}

