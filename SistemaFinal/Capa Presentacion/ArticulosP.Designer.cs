namespace SistemaFinal.Capa_Presentacion
{
    partial class ArticulosP
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
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            BuscarArtBtn = new Button();
            StockActual = new Button();
            DadosBaja = new Button();
            ReactArtBtn = new Button();
            BajaArtBtn = new Button();
            ModArtBtn = new Button();
            AgArtBtn = new Button();
            panel2 = new Panel();
            BusquedaTxtBox = new TextBox();
            siguienteBtn = new Button();
            anteriorBtn = new Button();
            panelPaginacion = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            paginacionLbl = new Label();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelPaginacion.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(666, 360);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(BuscarArtBtn);
            panel1.Controls.Add(StockActual);
            panel1.Controls.Add(DadosBaja);
            panel1.Controls.Add(ReactArtBtn);
            panel1.Controls.Add(BajaArtBtn);
            panel1.Controls.Add(ModArtBtn);
            panel1.Controls.Add(AgArtBtn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(134, 457);
            panel1.TabIndex = 1;
            // 
            // BuscarArtBtn
            // 
            BuscarArtBtn.Dock = DockStyle.Top;
            BuscarArtBtn.Location = new Point(0, 330);
            BuscarArtBtn.Name = "BuscarArtBtn";
            BuscarArtBtn.Size = new Size(134, 55);
            BuscarArtBtn.TabIndex = 6;
            BuscarArtBtn.Text = "Buscar x Nombre - F5";
            BuscarArtBtn.UseVisualStyleBackColor = true;
            BuscarArtBtn.Click += BuscarArtBtn_Click_1;
            BuscarArtBtn.KeyDown += BuscarArtBtn_KeyDown_1;
            // 
            // StockActual
            // 
            StockActual.Dock = DockStyle.Top;
            StockActual.Location = new Point(0, 275);
            StockActual.Name = "StockActual";
            StockActual.Size = new Size(134, 55);
            StockActual.TabIndex = 5;
            StockActual.Text = "Stock Actual (Activos)";
            StockActual.UseVisualStyleBackColor = true;
            StockActual.Click += StockActual_Click;
            // 
            // DadosBaja
            // 
            DadosBaja.Dock = DockStyle.Top;
            DadosBaja.Location = new Point(0, 220);
            DadosBaja.Name = "DadosBaja";
            DadosBaja.Size = new Size(134, 55);
            DadosBaja.TabIndex = 4;
            DadosBaja.Text = "Ver Dados de Baja";
            DadosBaja.UseVisualStyleBackColor = true;
            DadosBaja.Click += DadosBaja_Click;
            // 
            // ReactArtBtn
            // 
            ReactArtBtn.Dock = DockStyle.Top;
            ReactArtBtn.Location = new Point(0, 165);
            ReactArtBtn.Name = "ReactArtBtn";
            ReactArtBtn.Size = new Size(134, 55);
            ReactArtBtn.TabIndex = 3;
            ReactArtBtn.Text = "Reactivar";
            ReactArtBtn.UseVisualStyleBackColor = true;
            ReactArtBtn.Click += BuscarArtBtn_Click;
            ReactArtBtn.KeyDown += BuscarArtBtn_KeyDown;
            // 
            // BajaArtBtn
            // 
            BajaArtBtn.Dock = DockStyle.Top;
            BajaArtBtn.Location = new Point(0, 110);
            BajaArtBtn.Name = "BajaArtBtn";
            BajaArtBtn.Size = new Size(134, 55);
            BajaArtBtn.TabIndex = 2;
            BajaArtBtn.Text = "Dar de Baja ";
            BajaArtBtn.UseVisualStyleBackColor = true;
            BajaArtBtn.Click += BajaArtBtn_Click;
            // 
            // ModArtBtn
            // 
            ModArtBtn.Dock = DockStyle.Top;
            ModArtBtn.Location = new Point(0, 55);
            ModArtBtn.Name = "ModArtBtn";
            ModArtBtn.Size = new Size(134, 55);
            ModArtBtn.TabIndex = 1;
            ModArtBtn.Text = "Modificar";
            ModArtBtn.UseVisualStyleBackColor = true;
            ModArtBtn.Click += ModArtBtn_Click;
            // 
            // AgArtBtn
            // 
            AgArtBtn.Dock = DockStyle.Top;
            AgArtBtn.Location = new Point(0, 0);
            AgArtBtn.Name = "AgArtBtn";
            AgArtBtn.Size = new Size(134, 55);
            AgArtBtn.TabIndex = 0;
            AgArtBtn.Text = "Agregar";
            AgArtBtn.UseVisualStyleBackColor = true;
            AgArtBtn.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(BusquedaTxtBox);
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(666, 360);
            panel2.TabIndex = 2;
            panel2.PreviewKeyDown += panel2_PreviewKeyDown;
            // 
            // BusquedaTxtBox
            // 
            BusquedaTxtBox.Location = new Point(33, 139);
            BusquedaTxtBox.Name = "BusquedaTxtBox";
            BusquedaTxtBox.Size = new Size(323, 23);
            BusquedaTxtBox.TabIndex = 1;
            BusquedaTxtBox.TextChanged += BusquedaTxtBox_TextChanged;
            BusquedaTxtBox.KeyDown += BusquedaTxtBox_KeyDown;
            BusquedaTxtBox.Leave += BusquedaTxtBox_Leave;
            // 
            // siguienteBtn
            // 
            siguienteBtn.Anchor = AnchorStyles.Top;
            siguienteBtn.Location = new Point(496, 10);
            siguienteBtn.Margin = new Padding(3, 10, 3, 3);
            siguienteBtn.Name = "siguienteBtn";
            siguienteBtn.Size = new Size(167, 50);
            siguienteBtn.TabIndex = 3;
            siguienteBtn.Text = "Siguiente ▶";
            siguienteBtn.UseVisualStyleBackColor = true;
            siguienteBtn.Click += siguienteBtn_Click;
            // 
            // anteriorBtn
            // 
            anteriorBtn.Anchor = AnchorStyles.Top;
            anteriorBtn.Location = new Point(3, 10);
            anteriorBtn.Margin = new Padding(3, 10, 3, 3);
            anteriorBtn.Name = "anteriorBtn";
            anteriorBtn.Size = new Size(167, 50);
            anteriorBtn.TabIndex = 4;
            anteriorBtn.Text = "◀ Anterior";
            anteriorBtn.UseVisualStyleBackColor = true;
            anteriorBtn.Click += anteriorBtn_Click;
            // 
            // panelPaginacion
            // 
            panelPaginacion.BackColor = SystemColors.GradientActiveCaption;
            panelPaginacion.Controls.Add(tableLayoutPanel1);
            panelPaginacion.Dock = DockStyle.Bottom;
            panelPaginacion.Location = new Point(0, 360);
            panelPaginacion.Name = "panelPaginacion";
            panelPaginacion.Size = new Size(666, 97);
            panelPaginacion.TabIndex = 6;
            panelPaginacion.Paint += panelPaginacion_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(siguienteBtn, 2, 0);
            tableLayoutPanel1.Controls.Add(anteriorBtn, 0, 0);
            tableLayoutPanel1.Controls.Add(paginacionLbl, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(666, 97);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // paginacionLbl
            // 
            paginacionLbl.Anchor = AnchorStyles.Top;
            paginacionLbl.AutoSize = true;
            paginacionLbl.Location = new Point(294, 30);
            paginacionLbl.Margin = new Padding(3, 30, 3, 0);
            paginacionLbl.Name = "paginacionLbl";
            paginacionLbl.Size = new Size(77, 15);
            paginacionLbl.TabIndex = 5;
            paginacionLbl.Text = "Página 1 de 1";
            paginacionLbl.TextAlign = ContentAlignment.MiddleCenter;
            paginacionLbl.Click += paginacionLbl_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(panelPaginacion);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(134, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(666, 457);
            panel3.TabIndex = 7;
            // 
            // ArticulosP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 457);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "ArticulosP";
            Text = "ArticulosP";
            WindowState = FormWindowState.Maximized;
            Load += ArticulosP_Load;
            KeyDown += ArticulosP_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelPaginacion.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Panel panel2;
        private Button ReactArtBtn;
        private Button BajaArtBtn;
        private Button ModArtBtn;
        private Button AgArtBtn;
        private Button DadosBaja;
        private TextBox BusquedaTxtBox;
        private Button StockActual;
        private Button BuscarArtBtn;
        private Button siguienteBtn;
        private Button anteriorBtn;
        private Panel panelPaginacion;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Label paginacionLbl;
    }
}