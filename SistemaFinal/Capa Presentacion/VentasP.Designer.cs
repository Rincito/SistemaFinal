namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    partial class VentasP
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
            CliComBox = new ComboBox();
            label10 = new Label();
            CondIva = new TextBox();
            panel3 = new Panel();
            PrecBtn = new Button();
            CantBtn = new Button();
            SenaBtn = new Button();
            RetirarBtn = new Button();
            AceptBtn = new Button();
            SalirBtn = new Button();
            TxtBoxTotal = new TextBox();
            label9 = new Label();
            RecTxtBox = new TextBox();
            DescTxtBox = new TextBox();
            TxtBoxBusq = new TextBox();
            panel2 = new Panel();
            PanelArts = new Panel();
            DGVArts = new DataGridView();
            DGVCarrito = new DataGridView();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            CondPagoComBox = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            TxtBoxFecha = new TextBox();
            label3 = new Label();
            label1 = new Label();
            VendComBox = new ComboBox();
            label2 = new Label();
            TxtBoxFact = new TextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            PanelArts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVArts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGVCarrito).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.AntiqueWhite;
            panel1.Controls.Add(CliComBox);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(CondIva);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(AceptBtn);
            panel1.Controls.Add(SalirBtn);
            panel1.Controls.Add(TxtBoxTotal);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(RecTxtBox);
            panel1.Controls.Add(DescTxtBox);
            panel1.Controls.Add(TxtBoxBusq);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(CondPagoComBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(TxtBoxFecha);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(VendComBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(TxtBoxFact);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1234, 638);
            panel1.TabIndex = 0;
            panel1.PreviewKeyDown += panel1_PreviewKeyDown_1;
            // 
            // CliComBox
            // 
            CliComBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CliComBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CliComBox.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            CliComBox.FormattingEnabled = true;
            CliComBox.Location = new Point(488, 114);
            CliComBox.Name = "CliComBox";
            CliComBox.Size = new Size(164, 32);
            CliComBox.TabIndex = 27;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(400, 120);
            label10.Name = "label10";
            label10.Size = new Size(82, 24);
            label10.TabIndex = 26;
            label10.Text = "Cliente:";
            // 
            // CondIva
            // 
            CondIva.BorderStyle = BorderStyle.FixedSingle;
            CondIva.Enabled = false;
            CondIva.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            CondIva.Location = new Point(158, 64);
            CondIva.Name = "CondIva";
            CondIva.ReadOnly = true;
            CondIva.RightToLeft = RightToLeft.No;
            CondIva.Size = new Size(223, 30);
            CondIva.TabIndex = 25;
            CondIva.TabStop = false;
            CondIva.TextAlign = HorizontalAlignment.Right;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel3.Controls.Add(PrecBtn);
            panel3.Controls.Add(CantBtn);
            panel3.Controls.Add(SenaBtn);
            panel3.Controls.Add(RetirarBtn);
            panel3.Location = new Point(53, 576);
            panel3.Name = "panel3";
            panel3.Size = new Size(656, 38);
            panel3.TabIndex = 24;
            // 
            // PrecBtn
            // 
            PrecBtn.Dock = DockStyle.Right;
            PrecBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrecBtn.Location = new Point(219, 0);
            PrecBtn.Name = "PrecBtn";
            PrecBtn.Size = new Size(91, 38);
            PrecBtn.TabIndex = 29;
            PrecBtn.Text = "/";
            PrecBtn.UseVisualStyleBackColor = true;
            PrecBtn.Click += PrecBtn_Click;
            // 
            // CantBtn
            // 
            CantBtn.Dock = DockStyle.Right;
            CantBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CantBtn.Location = new Point(310, 0);
            CantBtn.Name = "CantBtn";
            CantBtn.Size = new Size(91, 38);
            CantBtn.TabIndex = 28;
            CantBtn.Text = "*";
            CantBtn.UseVisualStyleBackColor = true;
            CantBtn.Click += CantBtn_Click;
            // 
            // SenaBtn
            // 
            SenaBtn.Dock = DockStyle.Right;
            SenaBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SenaBtn.Location = new Point(401, 0);
            SenaBtn.Name = "SenaBtn";
            SenaBtn.Size = new Size(109, 38);
            SenaBtn.TabIndex = 26;
            SenaBtn.Text = "Presupuesto";
            SenaBtn.UseVisualStyleBackColor = true;
            SenaBtn.Click += SenaBtn_Click;
            // 
            // RetirarBtn
            // 
            RetirarBtn.Dock = DockStyle.Right;
            RetirarBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RetirarBtn.Location = new Point(510, 0);
            RetirarBtn.Name = "RetirarBtn";
            RetirarBtn.Size = new Size(146, 38);
            RetirarBtn.TabIndex = 24;
            RetirarBtn.Text = "Retirar Producto";
            RetirarBtn.UseVisualStyleBackColor = true;
            RetirarBtn.Click += RetirarBtn_Click;
            // 
            // AceptBtn
            // 
            AceptBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AceptBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AceptBtn.Location = new Point(961, 576);
            AceptBtn.Name = "AceptBtn";
            AceptBtn.Size = new Size(112, 38);
            AceptBtn.TabIndex = 23;
            AceptBtn.Text = "Aceptar";
            AceptBtn.UseVisualStyleBackColor = true;
            AceptBtn.Click += AceptBtn_Click;
            // 
            // SalirBtn
            // 
            SalirBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SalirBtn.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SalirBtn.Location = new Point(1089, 576);
            SalirBtn.Name = "SalirBtn";
            SalirBtn.Size = new Size(112, 38);
            SalirBtn.TabIndex = 22;
            SalirBtn.Text = "Salir";
            SalirBtn.UseVisualStyleBackColor = true;
            SalirBtn.Click += SalirBtn_Click;
            // 
            // TxtBoxTotal
            // 
            TxtBoxTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TxtBoxTotal.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxTotal.Enabled = false;
            TxtBoxTotal.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxTotal.Location = new Point(1073, 514);
            TxtBoxTotal.Name = "TxtBoxTotal";
            TxtBoxTotal.ReadOnly = true;
            TxtBoxTotal.Size = new Size(128, 30);
            TxtBoxTotal.TabIndex = 21;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(1073, 474);
            label9.Name = "label9";
            label9.Size = new Size(74, 24);
            label9.TabIndex = 16;
            label9.Text = "TOTAL:";
            // 
            // RecTxtBox
            // 
            RecTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RecTxtBox.BorderStyle = BorderStyle.FixedSingle;
            RecTxtBox.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            RecTxtBox.Location = new Point(1085, 114);
            RecTxtBox.Name = "RecTxtBox";
            RecTxtBox.Size = new Size(116, 30);
            RecTxtBox.TabIndex = 20;
            RecTxtBox.TextChanged += RecTxtBox_TextChanged;
            // 
            // DescTxtBox
            // 
            DescTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DescTxtBox.BorderStyle = BorderStyle.FixedSingle;
            DescTxtBox.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            DescTxtBox.Location = new Point(835, 113);
            DescTxtBox.Name = "DescTxtBox";
            DescTxtBox.Size = new Size(116, 30);
            DescTxtBox.TabIndex = 19;
            DescTxtBox.TextChanged += DescTxtBox_TextChanged;
            // 
            // TxtBoxBusq
            // 
            TxtBoxBusq.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxBusq.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxBusq.Location = new Point(151, 116);
            TxtBoxBusq.Name = "TxtBoxBusq";
            TxtBoxBusq.Size = new Size(230, 30);
            TxtBoxBusq.TabIndex = 18;
            TxtBoxBusq.Click += TxtBoxBusq_Click;
            TxtBoxBusq.TextChanged += TxtBoxBusq_TextChanged;
            TxtBoxBusq.KeyDown += TxtBoxBusq_KeyDown;
            TxtBoxBusq.Leave += TxtBoxBusq_Leave;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(PanelArts);
            panel2.Controls.Add(DGVCarrito);
            panel2.Location = new Point(33, 156);
            panel2.Name = "panel2";
            panel2.Size = new Size(1026, 402);
            panel2.TabIndex = 17;
            // 
            // PanelArts
            // 
            PanelArts.Controls.Add(DGVArts);
            PanelArts.Location = new Point(95, 64);
            PanelArts.Name = "PanelArts";
            PanelArts.Size = new Size(862, 324);
            PanelArts.TabIndex = 28;
            PanelArts.Leave += PanelArts_Leave;
            PanelArts.PreviewKeyDown += PanelArts_PreviewKeyDown;
            // 
            // DGVArts
            // 
            DGVArts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVArts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVArts.Location = new Point(0, 0);
            DGVArts.MultiSelect = false;
            DGVArts.Name = "DGVArts";
            DGVArts.ReadOnly = true;
            DGVArts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGVArts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVArts.Size = new Size(862, 324);
            DGVArts.TabIndex = 0;
            DGVArts.CellContentClick += DGVArts_CellContentClick;
            DGVArts.CellContentDoubleClick += DGVArts_CellContentDoubleClick;
            DGVArts.KeyDown += DGVArts_KeyDown;
            // 
            // DGVCarrito
            // 
            DGVCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVCarrito.BackgroundColor = SystemColors.ControlLight;
            DGVCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVCarrito.GridColor = SystemColors.InactiveCaptionText;
            DGVCarrito.Location = new Point(0, 0);
            DGVCarrito.Name = "DGVCarrito";
            DGVCarrito.ReadOnly = true;
            DGVCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVCarrito.Size = new Size(1026, 402);
            DGVCarrito.TabIndex = 0;
            DGVCarrito.CellValidating += DGVCarrito_CellValidating;
            DGVCarrito.CellValueChanged += DGVCarrito_CellValueChanged;
            DGVCarrito.KeyDown += DGVCarrito_KeyDown;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Trebuchet MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(19, 119);
            label8.Name = "label8";
            label8.Size = new Size(131, 27);
            label8.TabIndex = 15;
            label8.Text = "Buscar (F5):";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(996, 115);
            label7.Name = "label7";
            label7.Size = new Size(63, 24);
            label7.TabIndex = 13;
            label7.Text = "%Rec:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(748, 116);
            label6.Name = "label6";
            label6.Size = new Size(71, 24);
            label6.TabIndex = 11;
            label6.Text = "%Desc:";
            // 
            // CondPagoComBox
            // 
            CondPagoComBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CondPagoComBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CondPagoComBox.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            CondPagoComBox.FormattingEnabled = true;
            CondPagoComBox.Location = new Point(784, 62);
            CondPagoComBox.Name = "CondPagoComBox";
            CondPagoComBox.Size = new Size(181, 32);
            CondPagoComBox.TabIndex = 10;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(625, 66);
            label5.Name = "label5";
            label5.Size = new Size(153, 24);
            label5.TabIndex = 9;
            label5.Text = "Condición Pago:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 67);
            label4.Name = "label4";
            label4.Size = new Size(140, 24);
            label4.TabIndex = 7;
            label4.Text = "Condición IVA:";
            // 
            // TxtBoxFecha
            // 
            TxtBoxFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TxtBoxFecha.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxFecha.Enabled = false;
            TxtBoxFecha.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxFecha.Location = new Point(1012, 8);
            TxtBoxFecha.Name = "TxtBoxFecha";
            TxtBoxFecha.PlaceholderText = "fecha";
            TxtBoxFecha.ReadOnly = true;
            TxtBoxFecha.RightToLeft = RightToLeft.No;
            TxtBoxFecha.Size = new Size(189, 30);
            TxtBoxFecha.TabIndex = 6;
            TxtBoxFecha.TabStop = false;
            TxtBoxFecha.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(937, 9);
            label3.Name = "label3";
            label3.Size = new Size(69, 24);
            label3.TabIndex = 5;
            label3.Text = "Fecha:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(93, 24);
            label1.TabIndex = 4;
            label1.Text = "Factura B";
            // 
            // VendComBox
            // 
            VendComBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VendComBox.DropDownStyle = ComboBoxStyle.DropDownList;
            VendComBox.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            VendComBox.FormattingEnabled = true;
            VendComBox.Location = new Point(545, 12);
            VendComBox.Name = "VendComBox";
            VendComBox.Size = new Size(164, 32);
            VendComBox.TabIndex = 3;
            VendComBox.SelectedIndexChanged += VendComBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(423, 15);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 2;
            label2.Text = "Vendedor:";
            // 
            // TxtBoxFact
            // 
            TxtBoxFact.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxFact.Enabled = false;
            TxtBoxFact.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxFact.Location = new Point(111, 9);
            TxtBoxFact.Name = "TxtBoxFact";
            TxtBoxFact.ReadOnly = true;
            TxtBoxFact.RightToLeft = RightToLeft.No;
            TxtBoxFact.Size = new Size(123, 30);
            TxtBoxFact.TabIndex = 1;
            TxtBoxFact.TabStop = false;
            TxtBoxFact.TextAlign = HorizontalAlignment.Right;
            // 
            // VentasP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 638);
            Controls.Add(panel1);
            Name = "VentasP";
            Text = "Venta de Mercadería";
            Load += FormVentas_Load;
            PreviewKeyDown += panel1_PreviewKeyDown_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            PanelArts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVArts).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGVCarrito).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox TxtBoxFact;
        private ComboBox VendComBox;
        private Label label2;
        private Label label1;
        private Label label4;
        private TextBox TxtBoxFecha;
        private Label label3;
        private ComboBox CondPagoComBox;
        private Label label5;
        private Label label6;
        private Label label7;
        private Panel panel2;
        private DataGridView DGVCarrito;
        private Label label8;
        private TextBox TxtBoxBusq;
        private TextBox RecTxtBox;
        private TextBox DescTxtBox;
        private TextBox TxtBoxTotal;
        private Label label9;
        private Button SalirBtn;
        private Button AceptBtn;
        private Panel panel3;
        private Button RetirarBtn;
        private Button SenaBtn;
        private TextBox CondIva;
        private Button CantBtn;
        private Button PrecBtn;
        private ComboBox CliComBox;
        private Label label10;
        private Panel PanelArts;
        private DataGridView DGVArts;
    }
}