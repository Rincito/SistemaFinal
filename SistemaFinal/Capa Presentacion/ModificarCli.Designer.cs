namespace SistemaFinal.Capa_Presentacion
{
    partial class ModificarCli
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
            TelTxtBox = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label9 = new Label();
            DomTxtBox = new TextBox();
            label8 = new Label();
            label5 = new Label();
            ApeTxtBox = new TextBox();
            label4 = new Label();
            NomTxtBox = new TextBox();
            label2 = new Label();
            CUILTxtBox = new TextBox();
            label1 = new Label();
            CancelBtn = new Button();
            SaveBtn = new Button();
            EmailTxtBox = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(EmailTxtBox);
            panel1.Controls.Add(TelTxtBox);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(DomTxtBox);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(ApeTxtBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(NomTxtBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(CUILTxtBox);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(492, 439);
            panel1.TabIndex = 3;
            // 
            // TelTxtBox
            // 
            TelTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TelTxtBox.Location = new Point(267, 255);
            TelTxtBox.Name = "TelTxtBox";
            TelTxtBox.Size = new Size(186, 29);
            TelTxtBox.TabIndex = 27;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label13.Location = new Point(287, 50);
            label13.Name = "label13";
            label13.Size = new Size(193, 34);
            label13.TabIndex = 26;
            label13.Text = "(Los únicos valores requeridos\r\n son CUIL y Nombre)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label12.Location = new Point(12, 31);
            label12.Name = "label12";
            label12.Size = new Size(246, 30);
            label12.TabIndex = 25;
            label12.Text = "Modificación de Cliente";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(267, 205);
            label9.Name = "label9";
            label9.Size = new Size(81, 21);
            label9.TabIndex = 19;
            label9.Text = "Teléfono:";
            // 
            // DomTxtBox
            // 
            DomTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DomTxtBox.Location = new Point(267, 346);
            DomTxtBox.Name = "DomTxtBox";
            DomTxtBox.Size = new Size(186, 29);
            DomTxtBox.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(267, 305);
            label8.Name = "label8";
            label8.Size = new Size(89, 21);
            label8.TabIndex = 16;
            label8.Text = "Domicilio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(36, 305);
            label5.Name = "label5";
            label5.Size = new Size(57, 21);
            label5.TabIndex = 11;
            label5.Text = "Email:";
            // 
            // ApeTxtBox
            // 
            ApeTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ApeTxtBox.Location = new Point(36, 255);
            ApeTxtBox.Name = "ApeTxtBox";
            ApeTxtBox.Size = new Size(186, 29);
            ApeTxtBox.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(36, 205);
            label4.Name = "label4";
            label4.Size = new Size(79, 21);
            label4.TabIndex = 9;
            label4.Text = "Apellido:";
            // 
            // NomTxtBox
            // 
            NomTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NomTxtBox.Location = new Point(267, 155);
            NomTxtBox.Name = "NomTxtBox";
            NomTxtBox.Size = new Size(186, 29);
            NomTxtBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(267, 112);
            label2.Name = "label2";
            label2.Size = new Size(77, 21);
            label2.TabIndex = 5;
            label2.Text = "Nombre:";
            // 
            // CUILTxtBox
            // 
            CUILTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CUILTxtBox.Location = new Point(36, 155);
            CUILTxtBox.Name = "CUILTxtBox";
            CUILTxtBox.Size = new Size(186, 29);
            CUILTxtBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(36, 112);
            label1.Name = "label1";
            label1.Size = new Size(49, 21);
            label1.TabIndex = 3;
            label1.Text = "CUIL:";
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(345, 445);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(108, 50);
            CancelBtn.TabIndex = 2;
            CancelBtn.Text = "Cancelar";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(231, 445);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(108, 50);
            SaveBtn.TabIndex = 1;
            SaveBtn.Text = "Guardar";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // EmailTxtBox
            // 
            EmailTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmailTxtBox.Location = new Point(36, 346);
            EmailTxtBox.Name = "EmailTxtBox";
            EmailTxtBox.Size = new Size(186, 29);
            EmailTxtBox.TabIndex = 28;
            // 
            // ModificarCli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(492, 503);
            ControlBox = false;
            Controls.Add(SaveBtn);
            Controls.Add(CancelBtn);
            Controls.Add(panel1);
            Name = "ModificarCli";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Cliente";
            Deactivate += ModificarArt_Deactivate;
            Load += ModificarArt_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button CancelBtn;
        private Button SaveBtn;
        private Label label1;
        private Label label2;
        private TextBox CUILTxtBox;
        private TextBox NomTxtBox;
        private TextBox StockTxtBox;
        private Label label6;
        private Label label5;
        private TextBox ApeTxtBox;
        private Label label4;
        private TextBox StockCritTxtBox;
        private TextBox GanTxtBox;
        private Label label8;
        private Label label7;
        private Label label9;
        private TextBox DomTxtBox;
        private ComboBox RubComBox;
        private ComboBox MarcComBox;
        private ComboBox ProvComBox;
        private Label label11;
        private Label label10;
        private Label label12;
        private Label label13;
        private TextBox TelTxtBox;
        private TextBox EmailTxtBox;
    }
}