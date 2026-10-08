namespace SistemaFinal.Capa_Presentacion
{
    partial class AgregarCli
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
            SaveBtn = new Button();
            CancelBtn = new Button();
            panel1 = new Panel();
            label13 = new Label();
            DomTxtBox = new TextBox();
            label11 = new Label();
            label10 = new Label();
            EmailTxtBox = new TextBox();
            label8 = new Label();
            TelTxtBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            NomTxtBox = new TextBox();
            label2 = new Label();
            CUILTxtBox = new TextBox();
            label1 = new Label();
            ApeTxtBox = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(855, 569);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(108, 50);
            SaveBtn.TabIndex = 0;
            SaveBtn.Text = "Guardar";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(969, 569);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(108, 50);
            CancelBtn.TabIndex = 1;
            CancelBtn.Text = "Cancelar";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ApeTxtBox);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(DomTxtBox);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(EmailTxtBox);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TelTxtBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(NomTxtBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(CUILTxtBox);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1088, 563);
            panel1.TabIndex = 2;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label13.Location = new Point(728, 178);
            label13.Name = "label13";
            label13.Size = new Size(248, 42);
            label13.TabIndex = 27;
            label13.Text = "(Los únicos campos obligatorios \r\nson CUIL y Nombre)";
            label13.Click += label13_Click;
            // 
            // DomTxtBox
            // 
            DomTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DomTxtBox.Location = new Point(13, 451);
            DomTxtBox.Name = "DomTxtBox";
            DomTxtBox.Size = new Size(248, 29);
            DomTxtBox.TabIndex = 24;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(13, 385);
            label11.Name = "label11";
            label11.Size = new Size(96, 25);
            label11.TabIndex = 23;
            label11.Text = "Domicilio";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label10.Location = new Point(398, 20);
            label10.Name = "label10";
            label10.Size = new Size(171, 32);
            label10.TabIndex = 22;
            label10.Text = "Nuevo Cliente";
            // 
            // EmailTxtBox
            // 
            EmailTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmailTxtBox.Location = new Point(398, 451);
            EmailTxtBox.Name = "EmailTxtBox";
            EmailTxtBox.Size = new Size(248, 29);
            EmailTxtBox.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(398, 385);
            label8.Name = "label8";
            label8.Size = new Size(59, 25);
            label8.TabIndex = 18;
            label8.Text = "Email";
            // 
            // TelTxtBox
            // 
            TelTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TelTxtBox.Location = new Point(398, 309);
            TelTxtBox.Name = "TelTxtBox";
            TelTxtBox.Size = new Size(248, 29);
            TelTxtBox.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(398, 252);
            label4.Name = "label4";
            label4.Size = new Size(89, 25);
            label4.TabIndex = 9;
            label4.Text = "Teléfono";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 252);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 8;
            label3.Text = "Apellido";
            // 
            // NomTxtBox
            // 
            NomTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NomTxtBox.Location = new Point(398, 175);
            NomTxtBox.Name = "NomTxtBox";
            NomTxtBox.Size = new Size(248, 29);
            NomTxtBox.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(398, 127);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 6;
            label2.Text = "Nombre";
            // 
            // CUILTxtBox
            // 
            CUILTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CUILTxtBox.Location = new Point(13, 175);
            CUILTxtBox.Name = "CUILTxtBox";
            CUILTxtBox.Size = new Size(248, 29);
            CUILTxtBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 127);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 4;
            label1.Text = "CUIL";
            // 
            // ApeTxtBox
            // 
            ApeTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ApeTxtBox.Location = new Point(13, 309);
            ApeTxtBox.Name = "ApeTxtBox";
            ApeTxtBox.Size = new Size(248, 29);
            ApeTxtBox.TabIndex = 28;
            // 
            // AgregarCli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(1088, 631);
            Controls.Add(panel1);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Name = "AgregarCli";
            Text = "Agregar Cliente";
            Load += AgregarArt_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button SaveBtn;
        private Button CancelBtn;
        private Panel panel1;
        private Label label1;
        private TextBox CUILTxtBox;
        private TextBox NomTxtBox;
        private Label label4;
        private Label label3;
        private Label label7;
        private TextBox TelTxtBox;
        private TextBox PrecTxtBox;
        private Label label6;
        private Label label5;
        private ComboBox ProvComBox;
        private ComboBox RubroComBox;
        private TextBox GananciaTxtBox;
        private Label label9;
        private TextBox EmailTxtBox;
        private Label label8;
        private TextBox DomTxtBox;
        private Label label11;
        private Label label10;
        private Label label2;
        private TextBox CostTxtBox;
        private Label label12;
        private Label label13;
        private TextBox ApeTxtBox;
    }
}