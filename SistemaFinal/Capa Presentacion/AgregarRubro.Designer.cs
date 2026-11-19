namespace SistemaFinal.Capa_Presentacion
{
    partial class AgregarRubro
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
            AgRubBtn = new Button();
            CancelBtn = new Button();
            label1 = new Label();
            NomRubTxtBox = new TextBox();
            label2 = new Label();
            BajaRubroBtn = new Button();
            dataGridView1 = new DataGridView();
            ReactRubBtn = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // AgRubBtn
            // 
            AgRubBtn.Location = new Point(334, 36);
            AgRubBtn.Name = "AgRubBtn";
            AgRubBtn.Size = new Size(122, 58);
            AgRubBtn.TabIndex = 0;
            AgRubBtn.Text = "Agregar Rubro";
            AgRubBtn.UseVisualStyleBackColor = true;
            AgRubBtn.Click += AgRubBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(334, 433);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(122, 58);
            CancelBtn.TabIndex = 1;
            CancelBtn.Text = "Cancelar";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(143, 21);
            label1.TabIndex = 2;
            label1.Text = "Nombre del Rubro:";
            // 
            // NomRubTxtBox
            // 
            NomRubTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NomRubTxtBox.Location = new Point(12, 64);
            NomRubTxtBox.Name = "NomRubTxtBox";
            NomRubTxtBox.Size = new Size(248, 29);
            NomRubTxtBox.TabIndex = 3;
            NomRubTxtBox.TextChanged += NomRubTxtBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 154);
            label2.Name = "label2";
            label2.Size = new Size(120, 21);
            label2.TabIndex = 4;
            label2.Text = "Lista de Rubros:";
            // 
            // BajaRubroBtn
            // 
            BajaRubroBtn.Location = new Point(334, 178);
            BajaRubroBtn.Name = "BajaRubroBtn";
            BajaRubroBtn.Size = new Size(122, 58);
            BajaRubroBtn.TabIndex = 6;
            BajaRubroBtn.Text = "Dar de Baja Rubro";
            BajaRubroBtn.UseVisualStyleBackColor = true;
            BajaRubroBtn.Click += BajaRubroBtn_Click;
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
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // ReactRubBtn
            // 
            ReactRubBtn.Location = new Point(334, 257);
            ReactRubBtn.Name = "ReactRubBtn";
            ReactRubBtn.Size = new Size(122, 58);
            ReactRubBtn.TabIndex = 8;
            ReactRubBtn.Text = "Reactivar Rubro";
            ReactRubBtn.UseVisualStyleBackColor = true;
            ReactRubBtn.Click += ReactRubBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ReactRubBtn);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(BajaRubroBtn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(NomRubTxtBox);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(CancelBtn);
            panel1.Controls.Add(AgRubBtn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 503);
            panel1.TabIndex = 9;
            // 
            // AgregarRubro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(482, 503);
            ControlBox = false;
            Controls.Add(panel1);
            Name = "AgregarRubro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AgregarRubro";
            Load += AgregarRubro_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button AgRubBtn;
        private Button CancelBtn;
        private Label label1;
        private TextBox NomRubTxtBox;
        private Label label2;
        private Button BajaRubroBtn;
        private DataGridView dataGridView1;
        private Button ReactRubBtn;
        private Panel panel1;
    }
}