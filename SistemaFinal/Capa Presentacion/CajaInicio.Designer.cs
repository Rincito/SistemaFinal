namespace SistemaFinal.Capa_Presentacion
{
    partial class CajaInicio
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(123, 9);
            label1.Name = "label1";
            label1.Size = new Size(186, 24);
            label1.TabIndex = 7;
            label1.Text = "Ingrese Caja Inicial:";
            // 
            // TxtBoxFact
            // 
            TxtBoxFact.BorderStyle = BorderStyle.FixedSingle;
            TxtBoxFact.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold);
            TxtBoxFact.Location = new Point(114, 46);
            TxtBoxFact.Name = "TxtBoxFact";
            TxtBoxFact.RightToLeft = RightToLeft.No;
            TxtBoxFact.Size = new Size(195, 30);
            TxtBoxFact.TabIndex = 8;
            TxtBoxFact.TabStop = false;
            TxtBoxFact.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(171, 114);
            button1.Name = "button1";
            button1.Size = new Size(85, 33);
            button1.TabIndex = 10;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CajaInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 159);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(TxtBoxFact);
            Controls.Add(label1);
            Name = "CajaInicio";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CajaInicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TxtBoxFact;
        private Button button1;
    }
}