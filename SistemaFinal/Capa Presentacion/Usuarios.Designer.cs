namespace SistemaFinal.Capa_Presentacion
{
    partial class Usuarios
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
            EmailTxtBox = new TextBox();
            AgUsuBtn = new Button();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            BajaUsuBtn = new Button();
            ReactUsuBtn = new Button();
            CancelBtn = new Button();
            ContraTxtBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ComboBoxRol = new ComboBox();
            ModUsuBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(51, 21);
            label1.TabIndex = 4;
            label1.Text = "Email:";
            // 
            // EmailTxtBox
            // 
            EmailTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmailTxtBox.Location = new Point(12, 33);
            EmailTxtBox.Name = "EmailTxtBox";
            EmailTxtBox.Size = new Size(202, 29);
            EmailTxtBox.TabIndex = 5;
            // 
            // AgUsuBtn
            // 
            AgUsuBtn.Location = new Point(338, 84);
            AgUsuBtn.Name = "AgUsuBtn";
            AgUsuBtn.Size = new Size(122, 58);
            AgUsuBtn.TabIndex = 6;
            AgUsuBtn.Text = "Agregar Usuario";
            AgUsuBtn.UseVisualStyleBackColor = true;
            AgUsuBtn.Click += AgUsuBtn_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 182);
            label2.Name = "label2";
            label2.Size = new Size(131, 21);
            label2.TabIndex = 7;
            label2.Text = "Lista de Usuarios:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 206);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(301, 252);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // BajaUsuBtn
            // 
            BajaUsuBtn.Location = new Point(338, 247);
            BajaUsuBtn.Name = "BajaUsuBtn";
            BajaUsuBtn.Size = new Size(122, 58);
            BajaUsuBtn.TabIndex = 10;
            BajaUsuBtn.Text = "Desactivar Usuario";
            BajaUsuBtn.UseVisualStyleBackColor = true;
            BajaUsuBtn.Click += BajaUsuBtn_Click;
            // 
            // ReactUsuBtn
            // 
            ReactUsuBtn.Location = new Point(338, 330);
            ReactUsuBtn.Name = "ReactUsuBtn";
            ReactUsuBtn.Size = new Size(122, 58);
            ReactUsuBtn.TabIndex = 11;
            ReactUsuBtn.Text = "Reactivar Usuario";
            ReactUsuBtn.UseVisualStyleBackColor = true;
            ReactUsuBtn.Click += ReactUsuBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(338, 438);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(122, 58);
            CancelBtn.TabIndex = 12;
            CancelBtn.Text = "Cancelar";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // ContraTxtBox
            // 
            ContraTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ContraTxtBox.Location = new Point(12, 89);
            ContraTxtBox.Name = "ContraTxtBox";
            ContraTxtBox.Size = new Size(202, 29);
            ContraTxtBox.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 65);
            label3.Name = "label3";
            label3.Size = new Size(92, 21);
            label3.TabIndex = 13;
            label3.Text = "Contraseña:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 121);
            label4.Name = "label4";
            label4.Size = new Size(36, 21);
            label4.TabIndex = 15;
            label4.Text = "Rol:";
            // 
            // ComboBoxRol
            // 
            ComboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxRol.Font = new Font("Segoe UI", 12F);
            ComboBoxRol.FormattingEnabled = true;
            ComboBoxRol.Location = new Point(12, 145);
            ComboBoxRol.Name = "ComboBoxRol";
            ComboBoxRol.Size = new Size(202, 29);
            ComboBoxRol.TabIndex = 16;
            // 
            // ModUsuBtn
            // 
            ModUsuBtn.Location = new Point(338, 165);
            ModUsuBtn.Name = "ModUsuBtn";
            ModUsuBtn.Size = new Size(122, 58);
            ModUsuBtn.TabIndex = 17;
            ModUsuBtn.Text = "Modificar Usuario";
            ModUsuBtn.UseVisualStyleBackColor = true;
            ModUsuBtn.Click += ModUsuBtn_Click;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(482, 503);
            ControlBox = false;
            Controls.Add(ModUsuBtn);
            Controls.Add(ComboBoxRol);
            Controls.Add(label4);
            Controls.Add(ContraTxtBox);
            Controls.Add(label3);
            Controls.Add(CancelBtn);
            Controls.Add(ReactUsuBtn);
            Controls.Add(BajaUsuBtn);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(AgUsuBtn);
            Controls.Add(EmailTxtBox);
            Controls.Add(label1);
            Name = "Usuarios";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            Load += Usuarios_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox EmailTxtBox;
        private Button AgUsuBtn;
        private Label label2;
        private DataGridView dataGridView1;
        private Button BajaUsuBtn;
        private Button ReactUsuBtn;
        private Button CancelBtn;
        private TextBox ContraTxtBox;
        private Label label3;
        private Label label4;
        private ComboBox ComboBoxRol;
        private Button ModUsuBtn;
    }
}