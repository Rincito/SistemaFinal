using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class PanelNotificaciones : Form
    {
        private NotificacionL notifL = new NotificacionL();
        private string categoriaFiltro;
        public PanelNotificaciones(string categoria)
        {
            InitializeComponent();
            this.categoriaFiltro = categoria;
        }

        private void PanelNotificaciones_Load(object sender, EventArgs e)
        {
            
            this.Width = 350;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Y;
            this.Location = new Point(x, y);
            
            CargarNotificaciones(categoriaFiltro);

            notifL.MarcarTodasComoLeidas();
        }
        public void CargarNotificaciones(string categoria)
        {
            List<Notificacion> lista = notifL.ObtenerNotificaciones(categoria);

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;

            
            bool hayNoLeidas = lista.Exists(n => n.Leido == 0);

            
            if (!hayNoLeidas)
            {
                Label lblEstado = new Label
                {
                    Text = "✔ No hay notificaciones pendientes.",
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Italic),
                    TextAlign = ContentAlignment.MiddleLeft, 
                    AutoSize = false,
                    Width = flowLayoutPanel1.ClientSize.Width - 25,
                    Height = 30,
                    ForeColor = Color.DarkGray,
                    Margin = new Padding(5, 5, 5, 10)
                };
                flowLayoutPanel1.Controls.Add(lblEstado);
            }

            if (lista.Count == 0) return;

            foreach (var item in lista)
            {
                bool esNueva = (item.Leido == 0);

                
                Color colorFondo = esNueva ? Color.AliceBlue : Color.FromArgb(245, 245, 245); 
                Color colorTexto = esNueva ? Color.FromArgb(30, 30, 30) : Color.DimGray;       
                Color colorBorde = esNueva ? Color.SteelBlue : Color.LightGray;               
                FontStyle estiloFuente = esNueva ? FontStyle.Bold : FontStyle.Regular;

                int anchoTarjeta = flowLayoutPanel1.ClientSize.Width - 25;

                Label lblCard = new Label
                {
                    Text = $"[{item.Tema.ToUpper()}] {item.Titulo}\n" +
                           $"{item.FechayHora:dd/MM/yyyy HH:mm}\n\n" +
                           $"{item.Descripcion}",
                    Font = new Font("Segoe UI", 8.5f, estiloFuente),
                    TextAlign = ContentAlignment.TopLeft, 
                    AutoSize = true,
                    MaximumSize = new Size(anchoTarjeta, 0),
                    MinimumSize = new Size(anchoTarjeta, 100),
                    
                    BackColor = colorFondo,
                    ForeColor = colorTexto,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10, 8, 10, 8),
                    Margin = new Padding(0, 3, 0, 3)
                };

                flowLayoutPanel1.Controls.Add(lblCard);
            }

        }
    }
}
