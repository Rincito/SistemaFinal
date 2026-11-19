namespace SistemaFinal.Capa_Presentacion
{
    partial class AgregarMarca
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
            NomMarcaTxtBox = new TextBox();
            AgMarBtn = new Button();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            BajaMarcaBtn = new Button();
            ReactMarBtn = new Button();
            CancelBtn = new Button();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // NomMarcaTxtBox
            // 
            NomMarcaTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NomMarcaTxtBox.Location = new Point(12, 62);
            NomMarcaTxtBox.Name = "NomMarcaTxtBox";
            NomMarcaTxtBox.Size = new Size(248, 29);
            NomMarcaTxtBox.TabIndex = 4;
            NomMarcaTxtBox.TextChanged += NomMarcaTxtBox_TextChanged;
            // 
            // AgMarBtn
            // 
            AgMarBtn.Location = new Point(331, 33);
            AgMarBtn.Name = "AgMarBtn";
            AgMarBtn.Size = new Size(122, 58);
            AgMarBtn.TabIndex = 5;
            AgMarBtn.Text = "Agregar Marca";
            AgMarBtn.UseVisualStyleBackColor = true;
            AgMarBtn.Click += AgMarBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 154);
            label2.Name = "label2";
            label2.Size = new Size(120, 21);
            label2.TabIndex = 6;
            label2.Text = "Lista de Marcas:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 178);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(301, 313);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // BajaMarcaBtn
            // 
            BajaMarcaBtn.Location = new Point(331, 178);
            BajaMarcaBtn.Name = "BajaMarcaBtn";
            BajaMarcaBtn.Size = new Size(122, 58);
            BajaMarcaBtn.TabIndex = 9;
            BajaMarcaBtn.Text = "Dar de baja Marca";
            BajaMarcaBtn.UseVisualStyleBackColor = true;
            BajaMarcaBtn.Click += BajaMarcaBtn_Click;
            // 
            // ReactMarBtn
            // 
            ReactMarBtn.Location = new Point(331, 254);
            ReactMarBtn.Name = "ReactMarBtn";
            ReactMarBtn.Size = new Size(122, 58);
            ReactMarBtn.TabIndex = 10;
            ReactMarBtn.Text = "Reactivar Marca";
            ReactMarBtn.UseVisualStyleBackColor = true;
            ReactMarBtn.Click += ReactMarBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(331, 433);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(122, 58);
            CancelBtn.TabIndex = 11;
            CancelBtn.Text = "Cancelar";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(155, 21);
            label1.TabIndex = 3;
            label1.Text = "Nombre de la Marca:";
            // 
            // panel1
            // 
            panel1.Controls.Add(CancelBtn);
            panel1.Controls.Add(ReactMarBtn);
            panel1.Controls.Add(BajaMarcaBtn);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(AgMarBtn);
            panel1.Controls.Add(NomMarcaTxtBox);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 503);
            panel1.TabIndex = 12;
            // 
            // AgregarMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(482, 503);
            ControlBox = false;
            Controls.Add(panel1);
            Name = "AgregarMarca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AgregarMarca";
            Load += AgregarMarca_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox NomMarcaTxtBox;
        private Button AgMarBtn;
        private Label label2;
        private DataGridView dataGridView1;
        private Button BajaMarcaBtn;
        private Button ReactMarBtn;
        private Button CancelBtn;
        private Label label1;
        private Panel panel1;
    }
}