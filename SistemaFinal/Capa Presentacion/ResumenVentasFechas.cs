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
        private string vendedorFiltro;
        public ResumenVentasFechas(string fechaInicio, string fechaFin)
            : this(fechaInicio, fechaFin, null)
        {
        }
        public ResumenVentasFechas(string fechaInicio, string fechaFin, string vendedorFiltro)
        {
            InitializeComponent();
            ConfigurarDiseño();

            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.vendedorFiltro = vendedorFiltro;

            if (string.IsNullOrEmpty(vendedorFiltro))
            {
                label1.Text = $"Resumen general desde {fechaInicio} hasta {fechaFin}";
            }
            else
            {
                label1.Text = $"Ventas de {vendedorFiltro} ({fechaInicio} a {fechaFin})";
            }

            CargarResumen();
        }

        public ResumenVentasFechas(bool esModoTarjeta)
        {
            InitializeComponent();
            ConfigurarDiseño();

            if (esModoTarjeta)
            {
                string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
                label1.Text = $"💳 Ventas con Tarjeta del Día ({fechaHoy})";
                CargarResumenTarjetas(fechaHoy);
            }
        }
        private void ConfigurarDiseño()
        {
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowCount = 0;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void CargarResumen()
        {
            VentasL ventas = new VentasL();
            Dictionary<string, List<VentaDetalle>> resumenPorFecha = ventas.CargarResumen(fechaInicio, fechaFin);
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;
            int filaActual = 0;

            foreach (var fecha in resumenPorFecha.Keys)
            {
                var listaVentas = resumenPorFecha[fecha];

                if (!string.IsNullOrEmpty(vendedorFiltro))
                {
                    listaVentas = listaVentas
                        .Where(v => v.NombreVendedor.Equals(vendedorFiltro, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                if (listaVentas.Count == 0) continue;

                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

                Label lblFecha = new Label
                {
                    Text = $"Fecha: {fecha}",
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = Color.DarkGray,
                    ForeColor = Color.White,
                    Margin = new Padding(5, 10, 5, 5),
                    
                };

                tableLayoutPanel1.Controls.Add(lblFecha, 0, filaActual);
                tableLayoutPanel1.SetColumnSpan(lblFecha, 2);
                filaActual++;

                for (int i = 0; i < listaVentas.Count; i += 2)
                {
                    tableLayoutPanel1.RowCount++;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 135F));

                    // Columna Izquierda
                    var ventaIzq = listaVentas[i];
                    string articulosIzq = FormatearArticulos(ventaIzq.DetalleArticulos);
                    Label lblVentaIzq = CrearTarjetaVenta($"Factura #{ventaIzq.NumFactura}\nArtículos:\n{articulosIzq}\nMétodo: {ventaIzq.Metodo}  |  Total: ${ventaIzq.Total:F2}  |  Vendedor: {ventaIzq.NombreVendedor}");
                    tableLayoutPanel1.Controls.Add(lblVentaIzq, 0, filaActual);

                    // Columna Derecha (Si existe)
                    if (i + 1 < listaVentas.Count)
                    {
                        var ventaDer = listaVentas[i + 1];
                        string articulosDer = FormatearArticulos(ventaDer.DetalleArticulos);
                        Label lblVentaDer = CrearTarjetaVenta($"Factura #{ventaDer.NumFactura}\nArtículos:\n{articulosDer}\nMétodo: {ventaDer.Metodo}  |  Total: ${ventaDer.Total:F2}  |  Vendedor: {ventaDer.NombreVendedor}");
                        tableLayoutPanel1.Controls.Add(lblVentaDer, 1, filaActual);
                    }

                    filaActual++;
                }
            }
        }

        public void CargarResumenTarjetas(string fechaHoy)
        {
            VentasL ventas = new VentasL();
            Dictionary<string, List<VentaDetalle>> resumenPorTarjeta = ventas.CargarResumenTarjetasDelDia(fechaHoy);

            label1.Text = $"Ventas con Tarjeta del Día ({fechaHoy})";

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;
            int filaActual = 0;

            foreach (var tarjeta in resumenPorTarjeta.Keys)
            {
                
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

                Label lblTarjeta = new Label
                {
                    Text = $"💳 Tarjeta: {tarjeta}",
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = Color.DarkSlateBlue,
                    ForeColor = Color.White,
                    Margin = new Padding(5, 10, 5, 5)
                };

                tableLayoutPanel1.Controls.Add(lblTarjeta, 0, filaActual);
                tableLayoutPanel1.SetColumnSpan(lblTarjeta, 2);
                filaActual++;

                var listaVentas = resumenPorTarjeta[tarjeta];

                
                for (int i = 0; i < listaVentas.Count; i += 2)
                {
                    tableLayoutPanel1.RowCount++;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));

                    
                    var ventaIzq = listaVentas[i];
                    string articulosIzq = FormatearArticulos(ventaIzq.DetalleArticulos);
                    Label lblVentaIzq = CrearTarjetaVenta($"Factura #{ventaIzq.NumFactura}\nArtículos:\n{articulosIzq}\nTotal: ${ventaIzq.Total:F2}  |  Vendedor: {ventaIzq.NombreVendedor}");
                    tableLayoutPanel1.Controls.Add(lblVentaIzq, 0, filaActual);

                    
                    if (i + 1 < listaVentas.Count)
                    {
                        var ventaDer = listaVentas[i + 1];
                        string articulosDer = FormatearArticulos(ventaDer.DetalleArticulos);
                        Label lblVentaDer = CrearTarjetaVenta($"Factura #{ventaDer.NumFactura}\nArtículos:\n{articulosDer}\nTotal: ${ventaDer.Total:F2}  |  Vendedor: {ventaDer.NombreVendedor}");
                        tableLayoutPanel1.Controls.Add(lblVentaDer, 1, filaActual);
                    }

                    filaActual++;
                }
            }
        }

        private Label CrearTarjetaVenta(string textoContenido)
        {
            return new Label
            {
                Text = textoContenido,
                Font = new Font("Arial", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill, // Obliga a ocupar toda la celda simétricamente
                BackColor = Color.LightSteelBlue,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5),
                Margin = new Padding(5)
            };
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

        private void ResumenVentasFechas_Load(object sender, EventArgs e)
        {

        }
    }
}
