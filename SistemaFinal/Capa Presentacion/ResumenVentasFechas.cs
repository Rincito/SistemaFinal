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
    public partial class ResumenVentasFechas : Form
    {
        private string fechaInicio;
        private string fechaFin;
        public ResumenVentasFechas(string fechaInicio, string fechaFin)
        {
            InitializeComponent();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Dock = DockStyle.None;
            flowLayoutPanel1.Anchor = AnchorStyles.Top;
            flowLayoutPanel1.Left = (this.ClientSize.Width - flowLayoutPanel1.Width) / 2;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            label1.Text = $"Resumen desde {fechaInicio} hasta {fechaFin}";
            CargarResumen();
        }

        private void CargarResumen()
        {
            VentasL ventas = new VentasL();
            Dictionary<string, List<VentaDetalle>> resumenPorFecha = ventas.CargarResumen(fechaInicio, fechaFin);

            flowLayoutPanel1.Controls.Clear(); 
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;


            foreach (var fecha in resumenPorFecha.Keys)
            {
                // Label para la fecha
                Label lblFecha = new Label
                {
                    Text = $"Fecha: {fecha}",
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Height = 35,
                    Width = flowLayoutPanel1.ClientSize.Width - 60,
                    BackColor = Color.DarkGray,
                    ForeColor = Color.White,
                    Margin = new Padding(0, 10, 0, 10),
                    Anchor = AnchorStyles.Top
                };
                flowLayoutPanel1.Controls.Add(lblFecha);

                // Labels para las facturas
                foreach (var venta in resumenPorFecha[fecha])
                {
                    string articulosFormateados = FormatearArticulos(venta.DetalleArticulos);

                    Label lblVenta = new Label
                    {
                        Text = $"Factura #{venta.NumFactura}\n" +
                               $"Artículos:\n{articulosFormateados}\n" +
                               $"Método: {venta.Metodo}  |  Total: ${venta.Total:F2}  |  Vendedor: {venta.NombreVendedor}",
                        Font = new Font("Arial", 10, FontStyle.Regular),
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = false,
                        Height = 120,
                        BackColor = Color.LightSteelBlue,
                        ForeColor = Color.Black,
                        BorderStyle = BorderStyle.FixedSingle,
                        Padding = new Padding(10),
                        Margin = new Padding(0, 5, 0, 5),
                        Width = flowLayoutPanel1.ClientSize.Width - 20,
                        Anchor = AnchorStyles.Top
                    };

                    flowLayoutPanel1.Controls.Add(lblVenta);
                }
            }
        }

        private string FormatearArticulos(string detalleArticulos)
        {
            try
            {
                var articulos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(detalleArticulos);
                List<string> articulosFormateados = new List<string>();

                foreach (var articulo in articulos)
                {
                    string nombre = articulo["Nombre"].ToString();
                    string cantidad = articulo["Cantidad"].ToString();
                    string precio = articulo["Precio"].ToString();
                    string subtotal = articulo["Subtotal"].ToString();

                    articulosFormateados.Add($"{nombre} x{cantidad} (${precio}) - Subtotal: ${subtotal}");
                }

                return string.Join("\n", articulosFormateados);
            }
            catch
            {
                return detalleArticulos;
            }
        }

        
    }
}
