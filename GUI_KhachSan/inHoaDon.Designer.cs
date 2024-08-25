
namespace GUI_KhachSan
{
    partial class inHoaDon
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
            this.rpHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaPHD = new System.Windows.Forms.TextBox();
            this.btnXemHD = new System.Windows.Forms.Button();
            this.cobMaHD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpHoaDon
            // 
            this.rpHoaDon.Location = new System.Drawing.Point(3, 100);
            this.rpHoaDon.Name = "rpHoaDon";
            this.rpHoaDon.ServerReport.BearerToken = null;
            this.rpHoaDon.Size = new System.Drawing.Size(1129, 517);
            this.rpHoaDon.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.txtMaPHD);
            this.groupBox1.Controls.Add(this.btnXemHD);
            this.groupBox1.Controls.Add(this.cobMaHD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(234, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(615, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập mã hóa đơn";
            // 
            // txtMaPHD
            // 
            this.txtMaPHD.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txtMaPHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaPHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPHD.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtMaPHD.Location = new System.Drawing.Point(374, 44);
            this.txtMaPHD.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaPHD.Name = "txtMaPHD";
            this.txtMaPHD.Size = new System.Drawing.Size(13, 16);
            this.txtMaPHD.TabIndex = 4;
            // 
            // btnXemHD
            // 
            this.btnXemHD.BackColor = System.Drawing.Color.YellowGreen;
            this.btnXemHD.Location = new System.Drawing.Point(396, 39);
            this.btnXemHD.Margin = new System.Windows.Forms.Padding(4);
            this.btnXemHD.Name = "btnXemHD";
            this.btnXemHD.Size = new System.Drawing.Size(164, 33);
            this.btnXemHD.TabIndex = 2;
            this.btnXemHD.Text = "Xem hóa đơn";
            this.btnXemHD.UseVisualStyleBackColor = false;
            this.btnXemHD.Click += new System.EventHandler(this.btnXemHD_Click);
            // 
            // cobMaHD
            // 
            this.cobMaHD.FormattingEnabled = true;
            this.cobMaHD.Location = new System.Drawing.Point(209, 39);
            this.cobMaHD.Margin = new System.Windows.Forms.Padding(4);
            this.cobMaHD.Name = "cobMaHD";
            this.cobMaHD.Size = new System.Drawing.Size(160, 32);
            this.cobMaHD.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn";
            // 
            // inHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1127, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rpHoaDon);
            this.Name = "inHoaDon";
            this.Text = "inHoaDon";
            this.Load += new System.EventHandler(this.inHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpHoaDon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaPHD;
        private System.Windows.Forms.Button btnXemHD;
        private System.Windows.Forms.ComboBox cobMaHD;
        private System.Windows.Forms.Label label1;
    }
}