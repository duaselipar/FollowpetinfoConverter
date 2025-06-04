namespace FollowpetinfoConverter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDatToIni;
        private System.Windows.Forms.Button btnIniToDat;
        private System.Windows.Forms.Label lblSubtitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblTitle = new Label();
            btnDatToIni = new Button();
            btnIniToDat = new Button();
            lblSubtitle = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(32, 43, 61);
            lblTitle.Location = new Point(0, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(455, 39);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "FollowPetInfo Converter";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDatToIni
            // 
            btnDatToIni.BackColor = Color.FromArgb(79, 195, 247);
            btnDatToIni.FlatAppearance.BorderSize = 0;
            btnDatToIni.FlatAppearance.MouseOverBackColor = Color.FromArgb(129, 212, 250);
            btnDatToIni.FlatStyle = FlatStyle.Flat;
            btnDatToIni.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnDatToIni.ForeColor = Color.White;
            btnDatToIni.Location = new Point(74, 82);
            btnDatToIni.Margin = new Padding(3, 2, 3, 2);
            btnDatToIni.Name = "btnDatToIni";
            btnDatToIni.Size = new Size(140, 45);
            btnDatToIni.TabIndex = 1;
            btnDatToIni.Text = "DAT ➔ INI";
            btnDatToIni.UseVisualStyleBackColor = false;
            btnDatToIni.Click += btnDatToIni_Click;
            // 
            // btnIniToDat
            // 
            btnIniToDat.BackColor = Color.FromArgb(32, 198, 170);
            btnIniToDat.FlatAppearance.BorderSize = 0;
            btnIniToDat.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 230, 203);
            btnIniToDat.FlatStyle = FlatStyle.Flat;
            btnIniToDat.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnIniToDat.ForeColor = Color.White;
            btnIniToDat.Location = new Point(241, 82);
            btnIniToDat.Margin = new Padding(3, 2, 3, 2);
            btnIniToDat.Name = "btnIniToDat";
            btnIniToDat.Size = new Size(140, 45);
            btnIniToDat.TabIndex = 2;
            btnIniToDat.Text = "INI ➔ DAT";
            btnIniToDat.UseVisualStyleBackColor = false;
            btnIniToDat.Click += btnIniToDat_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(0, 146);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(455, 22);
            lblSubtitle.TabIndex = 3;
            lblSubtitle.Text = "by DuaSelipar  |  © 2025";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 249, 252);
            ClientSize = new Size(455, 184);
            Controls.Add(lblSubtitle);
            Controls.Add(btnIniToDat);
            Controls.Add(btnDatToIni);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FollowPetInfo Converter";
            ResumeLayout(false);
        }

        #endregion
    }
}
