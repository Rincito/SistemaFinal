using Punto_de_venta___Prácticas_profesionales.Presentación;
using SistemaFinal.Capa_Logica;




namespace SistemaFinal.Capa_Presentacion
{

    public partial class Inicio : Form
    {
        private System.Windows.Forms.Timer timer;
        private HttpClient httpClient;
        private System.Windows.Forms.Timer inactividadTimer;
        private DateTime ultimaInteraccion;
        private Form loginForm;

        public Inicio(Form login)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Inicio_KeyDown);
            timer = new System.Windows.Forms.Timer();
            UpdateDollarPriceAsync();
            this.loginForm = login;

        }
        private void ConfigurarTemporizadorReloj()
        {
            timer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // 1 segundo
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void ConfigurarTemporizadorInactividad()
        {
            ultimaInteraccion = DateTime.Now;

            inactividadTimer = new System.Windows.Forms.Timer
            {
                Interval = 5 * 60 * 1000 // 5 minutos
            };
            inactividadTimer.Tick += InactividadTimer_Tick;
            inactividadTimer.Start();

            // Asignar eventos de interacción
            this.MouseMove += RegistrarInteraccion;
            this.KeyDown += RegistrarInteraccion;
            this.Click += RegistrarInteraccion;
        }

        private void RegistrarInteraccion(object sender, EventArgs e)
        {

            if ((DateTime.Now - ultimaInteraccion).TotalSeconds >= 1)
            {
                ReiniciarTemporizador();
            }

            ultimaInteraccion = DateTime.Now;
        }

        private void ReiniciarTemporizador()
        {
            inactividadTimer.Stop();
            inactividadTimer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Fecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }
        private async void UpdateDollarPriceAsync()
        {
            try
            {

                string url = "https://api.exchangerate-api.com/v4/latest/USD";
                var response = await httpClient.GetStringAsync(url);


                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                double dollarPrice = json.rates.ARS;
                Dolar.Text = $"Precio del Dólar: {dollarPrice} ARS";
            }
            catch (Exception e)
            {
                Dolar.Text = "Error al obtener el precio del dólar.";
            }
        }
        private void InactividadTimer_Tick(object sender, EventArgs e)
        {
            CerrarFormularioEnPanel();
            panel2.Controls.Clear();
        }
        private void CerrarFormularioEnPanel()
        {
            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl is Form formulario)
                {

                    formulario.Close();
                    break;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fecha_Click(object sender, EventArgs e)
        {

        }



        private void ArtBtn_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ArticulosP formulario = new ArticulosP();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel2.Controls.Add(formulario);
            formulario.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClientBtn_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ClientesP formulario = new ClientesP();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel2.Controls.Add(formulario);
            formulario.Show();

        }

        private void ArtBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ArtBtn.PerformClick();

            }
            if (e.KeyCode == Keys.F2)
            {
                ClientBtn.PerformClick();
            }
            if (e.KeyCode == Keys.F3)
            {
                VentBtn.PerformClick();
            }
            if (e.KeyCode == Keys.F4)
            {
                ConsVenBtn.PerformClick();
            }
        }



        private void VentBtn_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            VentasP formulario = new VentasP();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel2.Controls.Add(formulario);
            formulario.Show();
        }

        private void panel2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                panel2.Focus();
            }


        }

        private void agregarRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarRubro formulario = new AgregarRubro(this);
            formulario.Show();
        }

        private void agregarMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarMarca formulario = new AgregarMarca(this);
            formulario.Show();
        }

        private void agregarModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarVendedor formulario = new AgregarVendedor(this);
            formulario.Show();
        }

        private void agregarTarjetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarTarjeta formulario = new AgregarTarjeta(this);
            formulario.Show();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            ActualizarMenuNotificaciones();
            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
            CajaL caja = new CajaL();
            if (!caja.CajaInicialExistente(fechaActual))
            {
                CajaInicio montoForm = new CajaInicio(fechaActual);
                montoForm.ShowDialog();
            }
        }

        private void ConsVenBtn_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ConsultarVentas formulario = new ConsultarVentas();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel2.Controls.Add(formulario);
            formulario.Show();
        }
        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Caja venta = new Caja();
            venta.ShowDialog();
        }

        private void agregarGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarGasto form = new AgregarGasto(this);
            form.Show();
        }

        private void resumenEntreFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SeleccionFechas seleccionFechasForm = new SeleccionFechas())
            {
                if (seleccionFechasForm.ShowDialog() == DialogResult.OK)
                {
                    string fechaInicio = seleccionFechasForm.FechaInicio;
                    string fechaFin = seleccionFechasForm.FechaFin;
                    ResumenVentasFechas formulario = new ResumenVentasFechas(fechaInicio, fechaFin);
                    panel2.Controls.Clear();
                    formulario.TopLevel = false;
                    formulario.FormBorderStyle = FormBorderStyle.None;
                    formulario.Dock = DockStyle.Fill;
                    panel2.Controls.Add(formulario);
                    formulario.Show();
                }
            }
        }


        private void pagoAVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PagoVendedores formulario = new PagoVendedores();
            formulario.Show();

        }

        private void ventasPorVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (VentasXVend ventasXVendForm = new VentasXVend())
            {
                if (ventasXVendForm.ShowDialog() == DialogResult.OK)
                {
                    string fechaInicio = ventasXVendForm.FechaInicio;
                    string fechaFin = ventasXVendForm.FechaFin;
                    string vendedorSeleccionado = ventasXVendForm.VendedorSeleccionado;

                    // Se abre EL MISMO ResumenVentasFechas, pero filtrará automáticamente por ese vendedor
                    ResumenVentasFechas formulario = new ResumenVentasFechas(fechaInicio, fechaFin, vendedorSeleccionado);

                    panel2.Controls.Clear();
                    formulario.TopLevel = false;
                    formulario.FormBorderStyle = FormBorderStyle.None;
                    formulario.Dock = DockStyle.Fill;
                    panel2.Controls.Add(formulario);
                    formulario.Show();
                }
            }
        }

        private void gestiónUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios formulario = new Usuarios(this);
            formulario.Show();
        }
        public void ActualizarMenuNotificaciones()
        {
            NotificacionL notifL = new NotificacionL();
            int noLeidas = notifL.ObtenerCantidadNoLeidas();

            // Reemplazá 'notificacionesToolStripMenuItem' por el Name real de tu menú padre de notificaciones
            if (noLeidas > 0)
            {
                notificacionesToolStripMenuItem.Text = $"🔔 Notificaciones ({noLeidas})";
                notificacionesToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                notificacionesToolStripMenuItem.Text = "🔔 Notificaciones";
                notificacionesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void ventasConTarjetaDelDíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResumenVentasFechas formulario = new ResumenVentasFechas(esModoTarjeta: true);
            panel2.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel2.Controls.Add(formulario);
            formulario.Show();
        }

        private void notificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelNotificaciones formNotif = new PanelNotificaciones("Todas");
            formNotif.ShowDialog();
            ActualizarMenuNotificaciones();
        }

        private void cajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PanelNotificaciones formNotif = new PanelNotificaciones("Caja");
            formNotif.ShowDialog();
            ActualizarMenuNotificaciones();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelNotificaciones formNotif = new PanelNotificaciones("Productos");
            formNotif.ShowDialog();
            ActualizarMenuNotificaciones();
        }

        private void gastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelNotificaciones formNotif = new PanelNotificaciones("Gastos");
            formNotif.ShowDialog();
            ActualizarMenuNotificaciones();
        }
    }
}
