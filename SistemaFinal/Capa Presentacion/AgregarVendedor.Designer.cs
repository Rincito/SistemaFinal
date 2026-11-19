namespace SistemaFinal.Capa_Presentacion
{
    partial class AgregarVendedor
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
            NomVenTxtBox = new TextBox();
            label2 = new Label();
            TelTxtBox = new TextBox();
            DomTxtBox = new TextBox();
            label3 = new Label();
            AgVenBtn = new Button();
            ModVenBtn = new Button();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            BajaVenBtn = new Button();
            ReactVenBtn = new Button();
            CancelBtn = new Button();
            label5 = new Label();
            label6 = new Label();
            ApeTxtBox = new TextBox();
            CUILTxtBox = new TextBox();
            emailTxtBox = new TextBox();
            label7 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(167, 21);
            label1.TabIndex = 4;
            label1.Text = "Nombre del Vendedor:";
            // 
            // NomVenTxtBox
            // 
            NomVenTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NomVenTxtBox.Location = new Point(12, 47);
            NomVenTxtBox.Name = "NomVenTxtBox";
            NomVenTxtBox.Size = new Size(183, 29);
            NomVenTxtBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(239, 89);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 6;
            label2.Text = "Teléfono:";
            // 
            // TelTxtBox
            // 
            TelTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TelTxtBox.Location = new Point(239, 113);
            TelTxtBox.Name = "TelTxtBox";
            TelTxtBox.Size = new Size(183, 29);
            TelTxtBox.TabIndex = 7;
            // 
            // DomTxtBox
            // 
            DomTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DomTxtBox.Location = new Point(12, 182);
            DomTxtBox.Name = "DomTxtBox";
            DomTxtBox.Size = new Size(183, 29);
            DomTxtBox.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 158);
            label3.Name = "label3";
            label3.Size = new Size(79, 21);
            label3.TabIndex = 9;
            label3.Text = "Domicilio:";
            // 
            // AgVenBtn
            // 
            AgVenBtn.Location = new Point(469, 23);
            AgVenBtn.Name = "AgVenBtn";
            AgVenBtn.Size = new Size(130, 58);
            AgVenBtn.TabIndex = 10;
            AgVenBtn.Text = "Agregar Vendedor";
            AgVenBtn.UseVisualStyleBackColor = true;
            AgVenBtn.Click += AgVenBtn_Click;
            // 
            // ModVenBtn
            // 
            ModVenBtn.Location = new Point(469, 114);
            ModVenBtn.Name = "ModVenBtn";
            ModVenBtn.Size = new Size(130, 58);
            ModVenBtn.TabIndex = 11;
            ModVenBtn.Text = "Modificar Vendedor";
            ModVenBtn.UseVisualStyleBackColor = true;
            ModVenBtn.Click += ModVenBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 223);
            label4.Name = "label4";
            label4.Size = new Size(152, 21);
            label4.TabIndex = 12;
            label4.Text = "Lista de Vendedores:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 247);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(436, 269);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // BajaVenBtn
            // 
            BajaVenBtn.Location = new Point(469, 249);
            BajaVenBtn.Name = "BajaVenBtn";
            BajaVenBtn.Size = new Size(137, 58);
            BajaVenBtn.TabIndex = 14;
            BajaVenBtn.Text = "Dar de baja Vendedor";
            BajaVenBtn.UseVisualStyleBackColor = true;
            BajaVenBtn.Click += BajaVenBtn_Click;
            // 
            // ReactVenBtn
            // 
            ReactVenBtn.Location = new Point(469, 333);
            ReactVenBtn.Name = "ReactVenBtn";
            ReactVenBtn.Size = new Size(137, 58);
            ReactVenBtn.TabIndex = 15;
            ReactVenBtn.Text = "Reactivar Vendedor";
            ReactVenBtn.UseVisualStyleBackColor = true;
            ReactVenBtn.Click += ReactVenBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(469, 448);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(137, 58);
            CancelBtn.TabIndex = 16;
            CancelBtn.Text = "Cancelar";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(239, 23);
            label5.Name = "label5";
            label5.Size = new Size(46, 21);
            label5.TabIndex = 17;
            label5.Text = "CUIL:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 89);
            label6.Name = "label6";
            label6.Size = new Size(70, 21);
            label6.TabIndex = 18;
            label6.Text = "Apellido:";
            // 
            // ApeTxtBox
            // 
            ApeTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ApeTxtBox.Location = new Point(12, 113);
            ApeTxtBox.Name = "ApeTxtBox";
            ApeTxtBox.Size = new Size(183, 29);
            ApeTxtBox.TabIndex = 19;
            ApeTxtBox.TextChanged += ApeTxtBox_TextChanged;
            // 
            // CUILTxtBox
            // 
            CUILTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CUILTxtBox.Location = new Point(239, 47);
            CUILTxtBox.Name = "CUILTxtBox";
            CUILTxtBox.Size = new Size(183, 29);
            CUILTxtBox.TabIndex = 20;
            CUILTxtBox.TextChanged += CUILTxtBox_TextChanged;
            // 
            // emailTxtBox
            // 
            emailTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailTxtBox.Location = new Point(239, 182);
            emailTxtBox.Name = "emailTxtBox";
            emailTxtBox.Size = new Size(183, 29);
            emailTxtBox.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(239, 158);
            label7.Name = "label7";
            label7.Size = new Size(51, 21);
            label7.TabIndex = 21;
            label7.Text = "Email:";
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(AgVenBtn);
            panel1.Controls.Add(ModVenBtn);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(BajaVenBtn);
            panel1.Controls.Add(ReactVenBtn);
            panel1.Controls.Add(CancelBtn);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(ApeTxtBox);
            panel1.Controls.Add(CUILTxtBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(emailTxtBox);
            panel1.Controls.Add(DomTxtBox);
            panel1.Controls.Add(TelTxtBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(NomVenTxtBox);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 528);
            panel1.TabIndex = 23;
            // 
            // AgregarVendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(630, 528);
            ControlBox = false;
            Controls.Add(panel1);
            Name = "AgregarVendedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Vendedor";
            Deactivate += AgregarProveedor_Deactivate;
            Load += AgregarVendedor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox NomVenTxtBox;
        private Label label2;
        private TextBox TelTxtBox;
        private TextBox DomTxtBox;
        private Label label3;
        private Button AgVenBtn;
        private Button ModVenBtn;
        private Label label4;
        private DataGridView dataGridView1;
        private Button BajaVenBtn;
        private Button ReactVenBtn;
        private Button CancelBtn;
        private Label label5;
        private Label label6;
        private TextBox ApeTxtBox;
        private TextBox CUILTxtBox;
        private TextBox emailTxtBox;
        private Label label7;
        private Panel panel1;
    }
}