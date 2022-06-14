namespace UserInterface
{
    partial class Baslangic
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
            this.btnpersonel = new System.Windows.Forms.Button();
            this.btnogr = new System.Windows.Forms.Button();
            this.btnKitapBul = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnpersonel
            // 
            this.btnpersonel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnpersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpersonel.Location = new System.Drawing.Point(736, 335);
            this.btnpersonel.Name = "btnpersonel";
            this.btnpersonel.Size = new System.Drawing.Size(202, 51);
            this.btnpersonel.TabIndex = 0;
            this.btnpersonel.Text = "PERSONEL GİRİŞ";
            this.btnpersonel.UseVisualStyleBackColor = false;
            this.btnpersonel.Click += new System.EventHandler(this.btnpersonel_Click);
            // 
            // btnogr
            // 
            this.btnogr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnogr.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnogr.Location = new System.Drawing.Point(736, 388);
            this.btnogr.Name = "btnogr";
            this.btnogr.Size = new System.Drawing.Size(202, 51);
            this.btnogr.TabIndex = 1;
            this.btnogr.Text = "ÖĞRENCİ GİRİŞ";
            this.btnogr.UseVisualStyleBackColor = false;
            this.btnogr.Click += new System.EventHandler(this.btnogr_Click);
            // 
            // btnKitapBul
            // 
            this.btnKitapBul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnKitapBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKitapBul.Location = new System.Drawing.Point(736, 441);
            this.btnKitapBul.Name = "btnKitapBul";
            this.btnKitapBul.Size = new System.Drawing.Size(202, 60);
            this.btnKitapBul.TabIndex = 2;
            this.btnKitapBul.Text = "ARADIĞIN KİTAP BURADA VAR MI?";
            this.btnKitapBul.UseVisualStyleBackColor = false;
            this.btnKitapBul.Click += new System.EventHandler(this.btnKitapBul_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Vivaldi", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(671, 47);
            this.label1.TabIndex = 3;
            this.label1.Text = "Samsun Şehir Kütüphanesine Hoşgeldiniz";
            // 
            // Baslangic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserInterface.Properties.Resources.pexels_olenka_sergienko_3646172;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1087, 664);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKitapBul);
            this.Controls.Add(this.btnogr);
            this.Controls.Add(this.btnpersonel);
            this.Name = "Baslangic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baslangic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnpersonel;
        private System.Windows.Forms.Button btnogr;
        private System.Windows.Forms.Button btnKitapBul;
        private System.Windows.Forms.Label label1;
    }
}