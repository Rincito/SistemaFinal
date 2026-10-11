namespace SistemaFinal.Capa_Presentacion
{
    partial class ClientesP
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
            BuscCliBtn = new Button();
            CliActBtn = new Button();
            ModCliBtn = new Button();
            AgCliBtn = new Button();
            panel2 = new Panel();
            BusquedaTxtBox = new TextBox();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            panelPaginacion = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            siguienteBtn = new Button();
            anteriorBtn = new Button();
            paginacionLbl = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            panelPaginacion.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(BuscCliBtn);
            panel1.Controls.Add(CliActBtn);
            panel1.Controls.Add(ModCliBtn);
            panel1.Controls.Add(AgCliBtn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(134, 450);
            panel1.TabIndex = 0;
            // 
            // BuscCliBtn
            // 
            BuscCliBtn.Dock = DockStyle.Top;
            BuscCliBtn.Location = new Point(0, 165);
            BuscCliBtn.Name = "BuscCliBtn";
            BuscCliBtn.Size = new Size(134, 55);
            BuscCliBtn.TabIndex = 7;
            BuscCliBtn.Text = "Buscar x Nombre - F5";
            BuscCliBtn.UseVisualStyleBackColor = true;
            BuscCliBtn.Click += BuscCliBtn_Click;
            BuscCliBtn.KeyDown += BuscCliBtn_KeyDown;
            // 
            // CliActBtn
            // 
            CliActBtn.Dock = DockStyle.Top;
            CliActBtn.Location = new Point(0, 110);
            CliActBtn.Name = "CliActBtn";
            CliActBtn.Size = new Size(134, 55);
            CliActBtn.TabIndex = 6;
            CliActBtn.Text = "Pago de Cuenta Corriente";
            CliActBtn.UseVisualStyleBackColor = true;
            CliActBtn.Click += CliActBtn_Click;
            // 
            // ModCliBtn
            // 
            ModCliBtn.Dock = DockStyle.Top;
            ModCliBtn.Location = new Point(0, 55);
            ModCliBtn.Name = "ModCliBtn";
            ModCliBtn.Size = new Size(134, 55);
            ModCliBtn.TabIndex = 2;
            ModCliBtn.Text = "Modificar";
            ModCliBtn.UseVisualStyleBackColor = true;
            ModCliBtn.Click += ModCliBtn_Click;
            // 
            // AgCliBtn
            // 
            AgCliBtn.Dock = DockStyle.Top;
            AgCliBtn.Location = new Point(0, 0);
            AgCliBtn.Name = "AgCliBtn";
            AgCliBtn.Size = new Size(134, 55);
            AgCliBtn.TabIndex = 1;
            AgCliBtn.Text = "Agregar";
            AgCliBtn.UseVisualStyleBackColor = true;
            AgCliBtn.Click += AgCliBtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(BusquedaTxtBox);
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(666, 329);
            panel2.TabIndex = 1;
            panel2.PreviewKeyDown += panel2_PreviewKeyDown;
            // 
            // BusquedaTxtBox
            // 
            BusquedaTxtBox.Location = new Point(181, 218);
            BusquedaTxtBox.Name = "BusquedaTxtBox";
            BusquedaTxtBox.Size = new Size(323, 23);
            BusquedaTxtBox.TabIndex = 2;
            BusquedaTxtBox.TextChanged += BusquedaTxtBox_TextChanged;
            BusquedaTxtBox.KeyDown += BusquedaTxtBox_KeyDown;
            BusquedaTxtBox.Leave += BusquedaTxtBox_Leave;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(666, 329);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(panelPaginacion);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(134, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(666, 450);
            panel3.TabIndex = 2;
            // 
            // panelPaginacion
            // 
            panelPaginacion.BackColor = SystemColors.GradientActiveCaption;
            panelPaginacion.Controls.Add(tableLayoutPanel1);
            panelPaginacion.Dock = DockStyle.Bottom;
            panelPaginacion.Location = new Point(0, 329);
            panelPaginacion.Name = "panelPaginacion";
            panelPaginacion.Size = new Size(666, 121);
            panelPaginacion.TabIndex = 7;
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
            tableLayoutPanel1.Size = new Size(666, 121);
            tableLayoutPanel1.TabIndex = 6;
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
            // 
            // ClientesP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            Name = "ClientesP";
            Text = "ClientesP";
            Load += ClientesP_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panelPaginacion.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button AgCliBtn;
        private Button ModCliBtn;
        private Button CliActBtn;
        private DataGridView dataGridView1;
        private Button BuscCliBtn;
        private TextBox BusquedaTxtBox;
        private Panel panel3;
        private Panel panelPaginacion;
        private TableLayoutPanel tableLayoutPanel1;
        private Button siguienteBtn;
        private Button anteriorBtn;
        private Label paginacionLbl;
    }
}