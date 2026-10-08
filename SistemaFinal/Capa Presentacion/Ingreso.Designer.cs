namespace SistemaFinal.Capa_Presentacion
{
    partial class Ingreso
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
            TxtBoxFact = new TextBox();
            button1 = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 9);
            label1.Name = "label1";
            label1.Size = new Size(173, 24);
            label1.TabIndex = 7;
            label1.Text = "Ingreso de dinero:";
            // 
            // TxtBoxFact
            // 
            TxtBoxFact.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxFact.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxFact.Location = new Point(22, 47);
            TxtBoxFact.Name = "TxtBoxFact";
            TxtBoxFact.RightToLeft = RightToLeft.No;
            TxtBoxFact.Size = new Size(173, 30);
            TxtBoxFact.TabIndex = 8;
            TxtBoxFact.TabStop = false;
            TxtBoxFact.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(85, 114);
            button1.Name = "button1";
            button1.Size = new Size(85, 33);
            button1.TabIndex = 10;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(257, 9);
            label2.Name = "label2";
            label2.Size = new Size(170, 24);
            label2.TabIndex = 11;
            label2.Text = "Forma de Ingreso:";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(257, 45);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(170, 32);
            comboBox1.TabIndex = 12;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(245, 114);
            button2.Name = "button2";
            button2.Size = new Size(85, 33);
            button2.TabIndex = 13;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Ingreso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 159);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(TxtBoxFact);
            Controls.Add(label1);
            Name = "Ingreso";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo Ingreso";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TxtBoxFact;
        private Button button1;
        private Label label2;
        private ComboBox comboBox1;
        private Button button2;
    }
}