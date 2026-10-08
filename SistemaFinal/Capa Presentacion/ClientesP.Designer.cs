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
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            panel2.Location = new Point(134, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(666, 450);
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
            dataGridView1.Size = new Size(666, 450);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // ClientesP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            Name = "ClientesP";
            Text = "ClientesP";
            Load += ClientesP_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
    }
}