namespace SistemaFinal.Capa_Presentacion
{
    partial class AgregarTarjeta
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
            label1 = new Label();
            NomTarjTxtBox = new TextBox();
            AgTarjBtn = new Button();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            BajaTarjBtn = new Button();
            ReactTarjBtn = new Button();
            CancelBtn = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(157, 21);
            label1.TabIndex = 4;
            label1.Text = "Nombre de la Tarjeta:";
            // 
            // NomTarjTxtBox
            // 
            NomTarjTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NomTarjTxtBox.Location = new Point(12, 63);
            NomTarjTxtBox.Name = "NomTarjTxtBox";
            NomTarjTxtBox.Size = new Size(248, 29);
            NomTarjTxtBox.TabIndex = 5;
            NomTarjTxtBox.TextChanged += NomTarjTxtBox_TextChanged;
            // 
            // AgTarjBtn
            // 
            AgTarjBtn.Location = new Point(329, 34);
            AgTarjBtn.Name = "AgTarjBtn";
            AgTarjBtn.Size = new Size(122, 58);
            AgTarjBtn.TabIndex = 6;
            AgTarjBtn.Text = "Agregar Tarjeta";
            AgTarjBtn.UseVisualStyleBackColor = true;
            AgTarjBtn.Click += AgTarjBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 159);
            label2.Name = "label2";
            label2.Size = new Size(122, 21);
            label2.TabIndex = 7;
            label2.Text = "Lista de Tarjetas:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 183);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(301, 313);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // BajaTarjBtn
            // 
            BajaTarjBtn.Location = new Point(338, 171);
            BajaTarjBtn.Name = "BajaTarjBtn";
            BajaTarjBtn.Size = new Size(122, 58);
            BajaTarjBtn.TabIndex = 10;
            BajaTarjBtn.Text = "Dar de baja Tarjeta";
            BajaTarjBtn.UseVisualStyleBackColor = true;
            BajaTarjBtn.Click += BajaTarjBtn_Click;
            // 
            // ReactTarjBtn
            // 
            ReactTarjBtn.Location = new Point(338, 266);
            ReactTarjBtn.Name = "ReactTarjBtn";
            ReactTarjBtn.Size = new Size(122, 58);
            ReactTarjBtn.TabIndex = 11;
            ReactTarjBtn.Text = "Reactivar Tarjeta";
            ReactTarjBtn.UseVisualStyleBackColor = true;
            ReactTarjBtn.Click += ReactTarjBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(338, 433);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(122, 58);
            CancelBtn.TabIndex = 12;
            CancelBtn.Text = "Cancelar";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(NomTarjTxtBox);
            panel1.Controls.Add(AgTarjBtn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(BajaTarjBtn);
            panel1.Controls.Add(ReactTarjBtn);
            panel1.Controls.Add(CancelBtn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 503);
            panel1.TabIndex = 13;
            // 
            // AgregarTarjeta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(482, 503);
            ControlBox = false;
            Controls.Add(panel1);
            Name = "AgregarTarjeta";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Tarjetas";
            Deactivate += AgregarTarjeta_Deactivate;
            Load += AgregarTarjeta_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox NomTarjTxtBox;
        private Button AgTarjBtn;
        private Label label2;
        private DataGridView dataGridView1;
        private Button BajaTarjBtn;
        private Button ReactTarjBtn;
        private Button CancelBtn;
        private Panel panel1;
    }
}