using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;
using System.Drawing.Printing;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class FactCompra : Form
    {
        private int numeroFactura;
        private List<DetalleArticulo> detalles;
        private Venta venta;

        public FactCompra(int numFactura, string proveedor, decimal total, string metodo, DateTime fechahora)
        {
            InitializeComponent();
            numeroFactura = numFactura;
            CargarFactura(numFactura, proveedor, total, metodo, fechahora);
        }

        private void CargarFactura(int numFactura, string proveedor, decimal total, string metodo, DateTime fechahora)
        {
            VentasL ventasL = new VentasL();
            detalles = ventasL.ObtenerDetalleCompra(numFactura);

            // Obtener los datos generales de la venta (incluyendo la fecha)
            venta = ventasL.ObtenerVenta(numFactura);

            // Mostrar los datos de la venta en labels
            label1.Text = "Factura #: " + numFactura.ToString();
            label2.Text = "Proveedor: " + proveedor;
            label3.Text = "Razón Social: Salomón Zaga";
            label4.Text = "Total: " + total.ToString("C");
            label5.Text = "Método de Pago: " + metodo;
            label6.Text = "Fecha de Emisión: " + fechahora.ToString("dd/MM/yyyy HH:mm");

            panelDetalles.Controls.Clear();

            int startX = 10;
            int offsetY = 10;
            int rowHeight = 25;
            int colWidth1 = 50;
            int colWidth2 = 70;
            int colWidth3 = 80;
            int colWidth4 = 80;

            string[] headers = { "Cant:", "Detalle:", "Costo:", "SubTotal:" };
            int[] colWidths = { colWidth1, colWidth2, colWidth3, colWidth4 };

            int currentX = startX;
            for (int i = 0; i < headers.Length; i++)
            {
                var headerLabel = new System.Windows.Forms.Label
                {
                    Text = headers[i],
                    AutoSize = false,
                    Width = colWidths[i],
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    Location = new Point(currentX, offsetY),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                panelDetalles.Controls.Add(headerLabel);
                currentX += colWidths[i];
            }

            offsetY += rowHeight; // Mover a la siguiente fila

            // Añadir los detalles
            foreach (var detalle in detalles)
            {
                currentX = startX;

                // Crear las etiquetas para cada columna
                string[] valores = {
                    detalle.Cantidad.ToString(),
                    detalle.Nombre,
                    detalle.Precio.ToString("C"),
                    detalle.Subtotal.ToString("C")
                };

                for (int i = 0; i < valores.Length; i++)
                {
                    var detalleLabel = new System.Windows.Forms.Label
                    {
                        Text = valores[i],
                        AutoSize = false,
                        Width = colWidths[i],
                        Font = new Font("Arial", 8, FontStyle.Regular),
                        Location = new Point(currentX, offsetY),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    panelDetalles.Controls.Add(detalleLabel);
                    currentX += colWidths[i];
                }

                offsetY += rowHeight;
            }
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
                MessageBox.Show("Factura impresa con éxito");
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            e.Graphics.DrawImage(bmp, 50, 50);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}