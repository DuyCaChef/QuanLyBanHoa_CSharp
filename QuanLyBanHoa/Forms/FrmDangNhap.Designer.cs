namespace DangNhap.Forms
{
    partial class FrmDangNhap
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
            panel1 = new Panel();
            label5 = new Label();
            ckbHienMK = new CheckBox();
            btnDangNhap = new Button();
            label4 = new Label();
            label3 = new Label();
            txtPass = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BackgroundImage = Properties.Resources.Gemini_Generated_Image_jo3i8ajo3i8ajo3i;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(ckbHienMK);
            panel1.Controls.Add(btnDangNhap);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtPass);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(674, 567);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(179, 517);
            label5.Name = "label5";
            label5.Size = new Size(302, 27);
            label5.TabIndex = 8;
            label5.Text = "Chào mừng đã quay trở lại !!!";
            // 
            // ckbHienMK
            // 
            ckbHienMK.AutoSize = true;
            ckbHienMK.BackColor = Color.Transparent;
            ckbHienMK.Font = new Font("Times New Roman", 11F, FontStyle.Italic, GraphicsUnit.Point, 0);
            ckbHienMK.Location = new Point(104, 349);
            ckbHienMK.Name = "ckbHienMK";
            ckbHienMK.Size = new Size(169, 29);
            ckbHienMK.TabIndex = 7;
            ckbHienMK.Text = "Hiện mật khẩu";
            ckbHienMK.UseVisualStyleBackColor = false;
            ckbHienMK.CheckedChanged += ckbHienMK_CheckedChanged;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = SystemColors.ActiveCaptionText;
            btnDangNhap.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = SystemColors.ButtonFace;
            btnDangNhap.Location = new Point(217, 403);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(227, 59);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "Đăng Nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Times New Roman", 14F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.Location = new Point(104, 267);
            label4.Name = "label4";
            label4.Size = new Size(129, 33);
            label4.TabIndex = 5;
            label4.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 14F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.Location = new Point(104, 162);
            label3.Name = "label3";
            label3.Size = new Size(88, 33);
            label3.TabIndex = 4;
            label3.Text = "Email:";
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass.Location = new Point(104, 303);
            txtPass.Name = "txtPass";
            txtPass.PlaceholderText = "Nhập Password";
            txtPass.Size = new Size(448, 40);
            txtPass.TabIndex = 3;
            txtPass.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(104, 198);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập Email";
            txtEmail.Size = new Size(448, 40);
            txtEmail.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(227, 88);
            label2.Name = "label2";
            label2.Size = new Size(217, 45);
            label2.TabIndex = 1;
            label2.Text = "ĐĂNG NHẬP";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(50, 22);
            label1.Name = "label1";
            label1.Size = new Size(562, 48);
            label1.TabIndex = 0;
            label1.Text = "HỆ THỐNG QUẢN LÍ BÁN HOA";
            // 
            // FrmDangNhap
            // 
            AcceptButton = btnDangNhap;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(674, 567);
            Controls.Add(panel1);
            Name = "FrmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private TextBox txtPass;
        private TextBox txtEmail;
        private Button btnDangNhap;
        private CheckBox ckbHienMK;
        private Label label5;
    }
}