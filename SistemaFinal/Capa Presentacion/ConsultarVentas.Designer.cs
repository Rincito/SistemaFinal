namespace SistemaFinal.Capa_Presentacion
{
    partial class ConsultarVentas
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
            PanelVentas = new Panel();
            ReactivarBtn = new Button();
            TarjetaBtn = new Button();
            EfectivoBtn = new Button();
            AnularVenta = new Button();
            SalirBtn = new Button();
            ImprimBtn = new Button();
            AnuladosBtn = new Button();
            ComprobantesBtn = new Button();
            dataGridView1 = new DataGridView();
            PanelDetalles = new Panel();
            TxtBoxTotal = new TextBox();
            label4 = new Label();
            dataGridView2 = new DataGridView();
            TxtBoxCliente = new TextBox();
            label10 = new Label();
            TxtBoxCondPago = new TextBox();
            label5 = new Label();
            TxtBoxFecha = new TextBox();
            label3 = new Label();
            TxtBoxVendedor = new TextBox();
            label2 = new Label();
            label1 = new Label();
            TxtBoxFact = new TextBox();
            PanelVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            PanelDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // PanelVentas
            // 
            PanelVentas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelVentas.BackColor = SystemColors.Control;
            PanelVentas.Controls.Add(ReactivarBtn);
            PanelVentas.Controls.Add(TarjetaBtn);
            PanelVentas.Controls.Add(EfectivoBtn);
            PanelVentas.Controls.Add(AnularVenta);
            PanelVentas.Controls.Add(SalirBtn);
            PanelVentas.Controls.Add(ImprimBtn);
            PanelVentas.Controls.Add(AnuladosBtn);
            PanelVentas.Controls.Add(ComprobantesBtn);
            PanelVentas.Controls.Add(dataGridView1);
            PanelVentas.Location = new Point(8, 3);
            PanelVentas.Name = "PanelVentas";
            PanelVentas.Size = new Size(1193, 266);
            PanelVentas.TabIndex = 0;
            // 
            // ReactivarBtn
            // 
            ReactivarBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ReactivarBtn.BackgroundImageLayout = ImageLayout.Center;
            ReactivarBtn.ImageAlign = ContentAlignment.MiddleLeft;
            ReactivarBtn.Location = new Point(1061, 86);
            ReactivarBtn.Name = "ReactivarBtn";
            ReactivarBtn.Size = new Size(129, 40);
            ReactivarBtn.TabIndex = 10;
            ReactivarBtn.Text = "Reactivar";
            ReactivarBtn.UseVisualStyleBackColor = true;
            ReactivarBtn.Click += ReactivarBtn_Click;
            // 
            // TarjetaBtn
            // 
            TarjetaBtn.Location = new Point(214, 0);
            TarjetaBtn.Name = "TarjetaBtn";
            TarjetaBtn.Size = new Size(95, 21);
            TarjetaBtn.TabIndex = 9;
            TarjetaBtn.Text = "Tarjeta";
            TarjetaBtn.UseVisualStyleBackColor = true;
            TarjetaBtn.Click += TarjetaBtn_Click;
            // 
            // EfectivoBtn
            // 
            EfectivoBtn.Location = new Point(113, 0);
            EfectivoBtn.Name = "EfectivoBtn";
            EfectivoBtn.Size = new Size(95, 21);
            EfectivoBtn.TabIndex = 8;
            EfectivoBtn.Text = "Efectivo";
            EfectivoBtn.UseVisualStyleBackColor = true;
            EfectivoBtn.Click += EfectivoBtn_Click;
            // 
            // AnularVenta
            // 
            AnularVenta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AnularVenta.BackgroundImageLayout = ImageLayout.Center;
            AnularVenta.ImageAlign = ContentAlignment.MiddleLeft;
            AnularVenta.Location = new Point(1061, 147);
            AnularVenta.Name = "AnularVenta";
            AnularVenta.Size = new Size(129, 40);
            AnularVenta.TabIndex = 7;
            AnularVenta.Text = "Anular";
            AnularVenta.UseVisualStyleBackColor = true;
            AnularVenta.Click += AnularVenta_Click;
            // 
            // SalirBtn
            // 
            SalirBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SalirBtn.Location = new Point(1061, 214);
            SalirBtn.Name = "SalirBtn";
            SalirBtn.Size = new Size(129, 40);
            SalirBtn.TabIndex = 6;
            SalirBtn.Text = "Salir";
            SalirBtn.UseVisualStyleBackColor = true;
            SalirBtn.Click += SalirBtn_Click;
            // 
            // ImprimBtn
            // 
            ImprimBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ImprimBtn.BackgroundImageLayout = ImageLayout.Center;
            ImprimBtn.ImageAlign = ContentAlignment.MiddleLeft;
            ImprimBtn.Location = new Point(1061, 21);
            ImprimBtn.Name = "ImprimBtn";
            ImprimBtn.Size = new Size(129, 40);
            ImprimBtn.TabIndex = 3;
            ImprimBtn.Text = "Imprimir";
            ImprimBtn.UseVisualStyleBackColor = true;
            ImprimBtn.Click += ImprimBtn_Click;
            // 
            // AnuladosBtn
            // 
            AnuladosBtn.Location = new Point(315, 0);
            AnuladosBtn.Name = "AnuladosBtn";
            AnuladosBtn.Size = new Size(95, 21);
            AnuladosBtn.TabIndex = 2;
            AnuladosBtn.Text = "Anulados";
            AnuladosBtn.UseVisualStyleBackColor = true;
            AnuladosBtn.Click += AnuladosBtn_Click;
            // 
            // ComprobantesBtn
            // 
            ComprobantesBtn.Location = new Point(12, 0);
            ComprobantesBtn.Name = "ComprobantesBtn";
            ComprobantesBtn.Size = new Size(95, 21);
            ComprobantesBtn.TabIndex = 1;
            ComprobantesBtn.Text = "Comprobantes";
            ComprobantesBtn.UseVisualStyleBackColor = true;
            ComprobantesBtn.Click += ComprobantesBtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.ControlDarkDark;
            dataGridView1.Location = new Point(12, 21);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1043, 241);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEnter += dataGridView1_CellEnter;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // PanelDetalles
            // 
            PanelDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelDetalles.BackColor = SystemColors.Control;
            PanelDetalles.Controls.Add(TxtBoxTotal);
            PanelDetalles.Controls.Add(label4);
            PanelDetalles.Controls.Add(dataGridView2);
            PanelDetalles.Controls.Add(TxtBoxCliente);
            PanelDetalles.Controls.Add(label10);
            PanelDetalles.Controls.Add(TxtBoxCondPago);
            PanelDetalles.Controls.Add(label5);
            PanelDetalles.Controls.Add(TxtBoxFecha);
            PanelDetalles.Controls.Add(label3);
            PanelDetalles.Controls.Add(TxtBoxVendedor);
            PanelDetalles.Controls.Add(label2);
            PanelDetalles.Controls.Add(label1);
            PanelDetalles.Controls.Add(TxtBoxFact);
            PanelDetalles.Location = new Point(8, 275);
            PanelDetalles.Name = "PanelDetalles";
            PanelDetalles.Size = new Size(1193, 360);
            PanelDetalles.TabIndex = 1;
            // 
            // TxtBoxTotal
            // 
            TxtBoxTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TxtBoxTotal.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxTotal.Enabled = false;
            TxtBoxTotal.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxTotal.Location = new Point(911, 67);
            TxtBoxTotal.Name = "TxtBoxTotal";
            TxtBoxTotal.ReadOnly = true;
            TxtBoxTotal.RightToLeft = RightToLeft.No;
            TxtBoxTotal.Size = new Size(123, 30);
            TxtBoxTotal.TabIndex = 31;
            TxtBoxTotal.TabStop = false;
            TxtBoxTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(843, 73);
            label4.Name = "label4";
            label4.Size = new Size(62, 24);
            label4.TabIndex = 30;
            label4.Text = "Total:";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Enabled = false;
            dataGridView2.GridColor = SystemColors.ControlDarkDark;
            dataGridView2.Location = new Point(14, 100);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.ScrollBars = ScrollBars.Vertical;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(1172, 257);
            dataGridView2.TabIndex = 29;
            // 
            // TxtBoxCliente
            // 
            TxtBoxCliente.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxCliente.Enabled = false;
            TxtBoxCliente.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxCliente.Location = new Point(102, 67);
            TxtBoxCliente.Name = "TxtBoxCliente";
            TxtBoxCliente.ReadOnly = true;
            TxtBoxCliente.RightToLeft = RightToLeft.No;
            TxtBoxCliente.Size = new Size(123, 30);
            TxtBoxCliente.TabIndex = 28;
            TxtBoxCliente.TabStop = false;
            TxtBoxCliente.TextAlign = HorizontalAlignment.Right;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(14, 73);
            label10.Name = "label10";
            label10.Size = new Size(82, 24);
            label10.TabIndex = 27;
            label10.Text = "Cliente:";
            // 
            // TxtBoxCondPago
            // 
            TxtBoxCondPago.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtBoxCondPago.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxCondPago.Enabled = false;
            TxtBoxCondPago.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxCondPago.Location = new Point(590, 67);
            TxtBoxCondPago.Name = "TxtBoxCondPago";
            TxtBoxCondPago.ReadOnly = true;
            TxtBoxCondPago.RightToLeft = RightToLeft.No;
            TxtBoxCondPago.Size = new Size(123, 30);
            TxtBoxCondPago.TabIndex = 12;
            TxtBoxCondPago.TabStop = false;
            TxtBoxCondPago.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(431, 73);
            label5.Name = "label5";
            label5.Size = new Size(153, 24);
            label5.TabIndex = 11;
            label5.Text = "Condición Pago:";
            // 
            // TxtBoxFecha
            // 
            TxtBoxFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TxtBoxFecha.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxFecha.Enabled = false;
            TxtBoxFecha.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxFecha.Location = new Point(918, 13);
            TxtBoxFecha.Name = "TxtBoxFecha";
            TxtBoxFecha.PlaceholderText = "fecha";
            TxtBoxFecha.ReadOnly = true;
            TxtBoxFecha.RightToLeft = RightToLeft.No;
            TxtBoxFecha.Size = new Size(189, 30);
            TxtBoxFecha.TabIndex = 10;
            TxtBoxFecha.TabStop = false;
            TxtBoxFecha.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(843, 14);
            label3.Name = "label3";
            label3.Size = new Size(69, 24);
            label3.TabIndex = 9;
            label3.Text = "Fecha:";
            // 
            // TxtBoxVendedor
            // 
            TxtBoxVendedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtBoxVendedor.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxVendedor.Enabled = false;
            TxtBoxVendedor.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxVendedor.Location = new Point(539, 10);
            TxtBoxVendedor.Name = "TxtBoxVendedor";
            TxtBoxVendedor.ReadOnly = true;
            TxtBoxVendedor.RightToLeft = RightToLeft.No;
            TxtBoxVendedor.Size = new Size(123, 30);
            TxtBoxVendedor.TabIndex = 8;
            TxtBoxVendedor.TabStop = false;
            TxtBoxVendedor.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(431, 12);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 7;
            label2.Text = "Vendedor:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 10);
            label1.Name = "label1";
            label1.Size = new Size(114, 24);
            label1.TabIndex = 6;
            label1.Text = "Factura Nro";
            // 
            // TxtBoxFact
            // 
            TxtBoxFact.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxFact.Enabled = false;
            TxtBoxFact.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxFact.Location = new Point(134, 8);
            TxtBoxFact.Name = "TxtBoxFact";
            TxtBoxFact.ReadOnly = true;
            TxtBoxFact.RightToLeft = RightToLeft.No;
            TxtBoxFact.Size = new Size(123, 30);
            TxtBoxFact.TabIndex = 5;
            TxtBoxFact.TabStop = false;
            TxtBoxFact.TextAlign = HorizontalAlignment.Right;
            // 
            // ConsultarVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1213, 638);
            Controls.Add(PanelDetalles);
            Controls.Add(PanelVentas);
            Name = "ConsultarVentas";
            Text = "ConsultarVentas";
            Load += ConsultarVentas_Load;
            PanelVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            PanelDetalles.ResumeLayout(false);
            PanelDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelVentas;
        private Panel PanelDetalles;
        private Button ComprobantesBtn;
        private DataGridView dataGridView1;
        private Button SalirBtn;
        private Button BorrarBtn;
        private Button button2;
        private Button ImprimBtn;
        private Button AnuladosBtn;
        private Button AnularVenta;
        private Button TarjetaBtn;
        private Button EfectivoBtn;
        private Button ReactivarBtn;
        private Label label1;
        private TextBox TxtBoxFact;
        private TextBox TxtBoxVendedor;
        private Label label2;
        private TextBox TxtBoxFecha;
        private Label label3;
        private TextBox TxtBoxCondPago;
        private Label label5;
        private TextBox TxtBoxCliente;
        private Label label10;
        private DataGridView dataGridView2;
        private TextBox TxtBoxTotal;
        private Label label4;
    }
}