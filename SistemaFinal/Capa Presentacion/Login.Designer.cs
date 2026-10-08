namespace SistemaFinal.Capa_Presentacion
{
    partial class Login
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
            label2 = new Label();
            ComboBoxRol = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            ContraTxtBox = new TextBox();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(190, 41);
            label2.Name = "label2";
            label2.Size = new Size(553, 45);
            label2.TabIndex = 8;
            label2.Text = "Bienvenido ¿Cómo deseas ingresar?";
            label2.Click += label2_Click;
            // 
            // ComboBoxRol
            // 
            ComboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxRol.Font = new Font("Trebuchet MS", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ComboBoxRol.FormattingEnabled = true;
            ComboBoxRol.Location = new Point(330, 184);
            ComboBoxRol.Name = "ComboBoxRol";
            ComboBoxRol.Size = new Size(283, 43);
            ComboBoxRol.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(346, 124);
            label1.Name = "label1";
            label1.Size = new Size(250, 45);
            label1.TabIndex = 12;
            label1.Text = "Tipo de acceso:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(371, 248);
            label3.Name = "label3";
            label3.Size = new Size(197, 45);
            label3.TabIndex = 13;
            label3.Text = "Contraseña:";
            // 
            // ContraTxtBox
            // 
            ContraTxtBox.BorderStyle = BorderStyle.FixedSingle;
            ContraTxtBox.Font = new Font("Trebuchet MS", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ContraTxtBox.Location = new Point(330, 309);
            ContraTxtBox.Name = "ContraTxtBox";
            ContraTxtBox.PasswordChar = '*';
            ContraTxtBox.Size = new Size(283, 39);
            ContraTxtBox.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(143, 514);
            label4.Name = "label4";
            label4.Size = new Size(655, 45);
            label4.TabIndex = 21;
            label4.Text = "¿Olvidaste tu contraseña? Recuperala aquí:";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            linkLabel1.Location = new Point(246, 570);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(444, 45);
            linkLabel1.TabIndex = 22;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Recuperación de Contraseña";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            button1.Location = new Point(381, 396);
            button1.Name = "button1";
            button1.Size = new Size(178, 58);
            button1.TabIndex = 23;
            button1.Text = "Iniciar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BackgroundImage = Properties.Resources.view;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(619, 309);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 39);
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.descargar;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(960, 667);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(ContraTxtBox);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(ComboBoxRol);
            Controls.Add(label2);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ComboBox ComboBoxRol;
        private Label label1;
        private Label label3;
        private TextBox ContraTxtBox;
        private Label label4;
        private LinkLabel linkLabel1;
        private Button button1;
        private PictureBox pictureBox1;
    }
}