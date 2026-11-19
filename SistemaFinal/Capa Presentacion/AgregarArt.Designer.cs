namespace SistemaFinal.Capa_Presentacion
{
    partial class AgregarArt
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
            CostTxtBox = new TextBox();
            label12 = new Label();
            StockCritTxtBox = new TextBox();
            label11 = new Label();
            label10 = new Label();
            GananciaTxtBox = new TextBox();
            label9 = new Label();
            IVATxtBox = new TextBox();
            label8 = new Label();
            RubroComBox = new ComboBox();
            MarcCombBox = new ComboBox();
            StockTxtBox = new TextBox();
            PrecTxtBox = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            NomTxtBox = new TextBox();
            label2 = new Label();
            CodTxtBox = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // SaveBtn
            // 
            SaveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveBtn.Location = new Point(845, 569);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(108, 50);
            SaveBtn.TabIndex = 0;
            SaveBtn.Text = "Guardar";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            panel1.Controls.Add(label13);
            panel1.Controls.Add(CancelBtn);
            panel1.Controls.Add(CostTxtBox);
            panel1.Controls.Add(SaveBtn);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(StockCritTxtBox);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(GananciaTxtBox);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(IVATxtBox);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(RubroComBox);
            panel1.Controls.Add(MarcCombBox);
            panel1.Controls.Add(StockTxtBox);
            panel1.Controls.Add(PrecTxtBox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(NomTxtBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(CodTxtBox);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1088, 631);
            panel1.TabIndex = 2;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label13.Location = new Point(668, 107);
            label13.Name = "label13";
            label13.Size = new Size(409, 21);
            label13.TabIndex = 27;
            label13.Text = "(Si necesita usar decimales, utilice comas y no puntos)";
            // 
            // CostTxtBox
            // 
            CostTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CostTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CostTxtBox.Location = new Point(398, 344);
            CostTxtBox.Name = "CostTxtBox";
            CostTxtBox.Size = new Size(248, 29);
            CostTxtBox.TabIndex = 26;
            CostTxtBox.TextChanged += CostTxtBox_TextChanged;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(398, 303);
            label12.Name = "label12";
            label12.Size = new Size(63, 25);
            label12.TabIndex = 25;
            label12.Text = "Costo";
            // 
            // StockCritTxtBox
            // 
            StockCritTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StockCritTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StockCritTxtBox.Location = new Point(756, 235);
            StockCritTxtBox.Name = "StockCritTxtBox";
            StockCritTxtBox.Size = new Size(248, 29);
            StockCritTxtBox.TabIndex = 24;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(756, 191);
            label11.Name = "label11";
            label11.Size = new Size(125, 25);
            label11.TabIndex = 23;
            label11.Text = "Stock Crítico";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label10.Location = new Point(398, 20);
            label10.Name = "label10";
            label10.Size = new Size(184, 32);
            label10.TabIndex = 22;
            label10.Text = "Nuevo Artículo";
            // 
            // GananciaTxtBox
            // 
            GananciaTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GananciaTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GananciaTxtBox.Location = new Point(756, 405);
            GananciaTxtBox.Name = "GananciaTxtBox";
            GananciaTxtBox.Size = new Size(248, 29);
            GananciaTxtBox.TabIndex = 21;
            GananciaTxtBox.TextChanged += GananciaTxtBox_TextChanged;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(756, 363);
            label9.Name = "label9";
            label9.Size = new Size(115, 25);
            label9.TabIndex = 20;
            label9.Text = "Ganancia %";
            // 
            // IVATxtBox
            // 
            IVATxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IVATxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IVATxtBox.Location = new Point(756, 318);
            IVATxtBox.Name = "IVATxtBox";
            IVATxtBox.Size = new Size(248, 29);
            IVATxtBox.TabIndex = 19;
            IVATxtBox.TextChanged += IVATxtBox_TextChanged;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(756, 277);
            label8.Name = "label8";
            label8.Size = new Size(64, 25);
            label8.TabIndex = 18;
            label8.Text = "IVA %";
            // 
            // RubroComBox
            // 
            RubroComBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RubroComBox.FormattingEnabled = true;
            RubroComBox.Location = new Point(33, 405);
            RubroComBox.Name = "RubroComBox";
            RubroComBox.Size = new Size(248, 29);
            RubroComBox.TabIndex = 16;
            // 
            // MarcCombBox
            // 
            MarcCombBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MarcCombBox.FormattingEnabled = true;
            MarcCombBox.Location = new Point(33, 322);
            MarcCombBox.Name = "MarcCombBox";
            MarcCombBox.Size = new Size(248, 29);
            MarcCombBox.TabIndex = 15;
            // 
            // StockTxtBox
            // 
            StockTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StockTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StockTxtBox.Location = new Point(398, 261);
            StockTxtBox.Name = "StockTxtBox";
            StockTxtBox.Size = new Size(248, 29);
            StockTxtBox.TabIndex = 13;
            // 
            // PrecTxtBox
            // 
            PrecTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PrecTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PrecTxtBox.Location = new Point(398, 431);
            PrecTxtBox.Name = "PrecTxtBox";
            PrecTxtBox.Size = new Size(248, 29);
            PrecTxtBox.TabIndex = 12;
            PrecTxtBox.TextChanged += PrecTxtBox_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(33, 363);
            label6.Name = "label6";
            label6.Size = new Size(68, 25);
            label6.TabIndex = 11;
            label6.Text = "Rubro";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(398, 389);
            label5.Name = "label5";
            label5.Size = new Size(68, 25);
            label5.TabIndex = 10;
            label5.Text = "Precio";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(398, 217);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 9;
            label4.Text = "Stock";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 277);
            label3.Name = "label3";
            label3.Size = new Size(67, 25);
            label3.TabIndex = 8;
            label3.Text = "Marca";
            // 
            // NomTxtBox
            // 
            NomTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NomTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NomTxtBox.Location = new Point(398, 175);
            NomTxtBox.Name = "NomTxtBox";
            NomTxtBox.Size = new Size(248, 29);
            NomTxtBox.TabIndex = 7;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(398, 127);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 6;
            label2.Text = "Nombre";
            // 
            // CodTxtBox
            // 
            CodTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CodTxtBox.Location = new Point(33, 235);
            CodTxtBox.Name = "CodTxtBox";
            CodTxtBox.Size = new Size(248, 29);
            CodTxtBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 191);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 4;
            label1.Text = "Código";
            label1.Click += label1_Click;
            // 
            // AgregarArt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(1088, 631);
            Controls.Add(panel1);
            Name = "AgregarArt";
            Text = "Agregar Artículo";
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
        private TextBox CodTxtBox;
        private TextBox NomTxtBox;
        private Label label4;
        private Label label3;
        private TextBox StockTxtBox;
        private TextBox PrecTxtBox;
        private Label label6;
        private Label label5;
        private ComboBox RubroComBox;
        private ComboBox MarcCombBox;
        private TextBox GananciaTxtBox;
        private Label label9;
        private TextBox IVATxtBox;
        private Label label8;
        private TextBox StockCritTxtBox;
        private Label label11;
        private Label label10;
        private Label label2;
        private TextBox CostTxtBox;
        private Label label12;
        private Label label13;
    }
}