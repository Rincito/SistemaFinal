namespace SistemaFinal.Capa_Presentacion
{
    partial class PagoCuenCo
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
            label3 = new Label();
            TxtBoxCli = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 24);
            label1.TabIndex = 7;
            label1.Text = "Cobro:";
            // 
            // TxtBoxFact
            // 
            TxtBoxFact.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxFact.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxFact.Location = new Point(11, 36);
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
            button1.Location = new Point(135, 114);
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
            label2.Location = new Point(188, 9);
            label2.Name = "label2";
            label2.Size = new Size(159, 24);
            label2.TabIndex = 11;
            label2.Text = "Forma de Cobro:";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(190, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(170, 32);
            comboBox1.TabIndex = 12;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(325, 114);
            button2.Name = "button2";
            button2.Size = new Size(85, 33);
            button2.TabIndex = 13;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(366, 9);
            label3.Name = "label3";
            label3.Size = new Size(82, 24);
            label3.TabIndex = 14;
            label3.Text = "Cliente:";
            // 
            // TxtBoxCli
            // 
            TxtBoxCli.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxCli.Enabled = false;
            TxtBoxCli.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxCli.Location = new Point(366, 36);
            TxtBoxCli.Name = "TxtBoxCli";
            TxtBoxCli.RightToLeft = RightToLeft.No;
            TxtBoxCli.Size = new Size(173, 30);
            TxtBoxCli.TabIndex = 15;
            TxtBoxCli.TabStop = false;
            TxtBoxCli.TextAlign = HorizontalAlignment.Center;
            // 
            // PagoCuenCo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 159);
            ControlBox = false;
            Controls.Add(TxtBoxCli);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(TxtBoxFact);
            Controls.Add(label1);
            Name = "PagoCuenCo";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo Pago";
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
        private Label label3;
        private TextBox TxtBoxCli;
    }
}