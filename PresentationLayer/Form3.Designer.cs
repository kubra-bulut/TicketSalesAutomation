using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer
{
    partial class Form3
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.btnSatisYap = new System.Windows.Forms.Button();
            this.lblSecilenKoltuk = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtMusteriMail = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(264, 83);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(648, 400);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.BackColor = System.Drawing.Color.Transparent;
            this.lblFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiyat.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblFiyat.Location = new System.Drawing.Point(61, 519);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(59, 25);
            this.lblFiyat.TabIndex = 0;
            this.lblFiyat.Text = "Fiyat";
            // 
            // btnSatisYap
            // 
            this.btnSatisYap.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSatisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatisYap.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSatisYap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSatisYap.Location = new System.Drawing.Point(800, 553);
            this.btnSatisYap.Name = "btnSatisYap";
            this.btnSatisYap.Size = new System.Drawing.Size(112, 50);
            this.btnSatisYap.TabIndex = 1;
            this.btnSatisYap.Text = "Satış";
            this.btnSatisYap.UseVisualStyleBackColor = false;
            this.btnSatisYap.Click += new System.EventHandler(this.btnSatisYap_Click);
            // 
            // lblSecilenKoltuk
            // 
            this.lblSecilenKoltuk.AutoSize = true;
            this.lblSecilenKoltuk.BackColor = System.Drawing.Color.Transparent;
            this.lblSecilenKoltuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecilenKoltuk.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSecilenKoltuk.Location = new System.Drawing.Point(331, 519);
            this.lblSecilenKoltuk.Name = "lblSecilenKoltuk";
            this.lblSecilenKoltuk.Size = new System.Drawing.Size(164, 25);
            this.lblSecilenKoltuk.TabIndex = 0;
            this.lblSecilenKoltuk.Text = "Seçilen Koltuk: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Koltuk Seçimi";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.BackColor = System.Drawing.Color.Transparent;
            this.lblMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMail.Location = new System.Drawing.Point(61, 568);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(129, 25);
            this.lblMail.TabIndex = 4;
            this.lblMail.Text = "Müşteri Mail";
            // 
            // txtMusteriMail
            // 
            this.txtMusteriMail.Location = new System.Drawing.Point(336, 568);
            this.txtMusteriMail.Multiline = true;
            this.txtMusteriMail.Name = "txtMusteriMail";
            this.txtMusteriMail.Size = new System.Drawing.Size(378, 30);
            this.txtMusteriMail.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(61, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Listele";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.indir_removebg_preview__2_;
            this.pictureBox1.Location = new System.Drawing.Point(45, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(61, 288);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 50);
            this.button4.TabIndex = 10;
            this.button4.Text = "Zed Graph";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PresentationLayer.Properties.Resources.images__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(924, 668);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtMusteriMail);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSecilenKoltuk);
            this.Controls.Add(this.btnSatisYap);
            this.Controls.Add(this.lblFiyat);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.Button btnSatisYap;
        private System.Windows.Forms.Label lblSecilenKoltuk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMail;
        private TextBox txtMusteriMail;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button4;
    }
}