using SistemaFinal.Capa_Logica;
using SistemaFinal.Estilos;
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
    public partial class Caja : Form
    {
        CajaL caja = new CajaL();
        public Caja()
        {
            InitializeComponent();
            if (SesionActual.Rol == 0) 
            {
                button6.Enabled = false;
            }
            Estilos.Tema.AplicarEstiloCaja(this);

            cargarCaja();
        }
        private void cargarCaja()
        {


            string fecha = DateTime.Now.ToString("dd/MM/yyyy");
            if (caja.CajaCerrada(fecha))
            {
                CajaInicioTxtBox.Text = "$0,00";
                LabelFecha.Text = fecha;
                VentasEfecTxtBox.Text = "$0,00";
                OtrosEfecTxtBox.Text = "$0,00";
                CCEfecTxtBox.Text = "$0,00";
                VentasTarjTxtBox.Text = "$0,00";
                OtrosTarjTxtBox.Text = "$0,00";
                CCTarjTxtBox.Text = "$0,00";
                PagoVendEfecTxtBox.Text = "$0,00";
                RetiroOtrosEfecTxtBox.Text = "$0,00";
                PagoVendTarjTxtBox.Text = "$0,00";
                textBox1.Text = "$0,00";
                TotalTarjTxtBox.Text = "$0,00";
                TotalEfectTxtBox.Text = "$0,00";
                TotalDiaTxtBox.Text = "$0,00";
                GananciaTxtBox.Text = "$0,00";
            }
            else
            {
                CajaL cajaL = new CajaL();
                //###INGRESOS###//
                string montoInicio = cajaL.MontoInicio(fecha);
                CajaInicioTxtBox.Text = "$" + montoInicio;
                LabelFecha.Text = fecha;
                string VentasEfect = cajaL.VentasEfect(fecha);
                VentasEfecTxtBox.Text = "$" + VentasEfect;
                string OtrosEfect = cajaL.OtrosEfect(fecha);
                OtrosEfecTxtBox.Text = "$" + OtrosEfect;
                string CCEfect = cajaL.CCEfect(fecha);
                CCEfecTxtBox.Text = "$" + CCEfect;

                //########//

                string VentasTarj = cajaL.VentasTarj(fecha);
                VentasTarjTxtBox.Text = "$" + VentasTarj;
                string OtrosTarj = cajaL.OtrosTarj(fecha);
                OtrosTarjTxtBox.Text = "$" + OtrosTarj;
                string CCTarj = cajaL.CCTarj(fecha);
                CCTarjTxtBox.Text = "$" + CCTarj;

                //###EGRESOS###//

                string PagoVendEfect = cajaL.PagosVendEfect(fecha);
                PagoVendEfecTxtBox.Text = "$" + PagoVendEfect;
                string RetiroOtrosEfect = cajaL.RetiroOtrosEfect(fecha);
                RetiroOtrosEfecTxtBox.Text = "$" + RetiroOtrosEfect;

                //#########//

                string PagoVendTarj = cajaL.PagosVendTarj(fecha);
                PagoVendTarjTxtBox.Text = "$" + PagoVendTarj;
                string EgresoOtrosTarj = cajaL.EgresoOtrosTarj(fecha);
                textBox1.Text = "$" + EgresoOtrosTarj;

                //########//

                decimal sumaEfect = decimal.Parse(montoInicio) + decimal.Parse(VentasEfect) + decimal.Parse(CCEfect) + decimal.Parse(OtrosEfect);
                decimal restaEfect = decimal.Parse(PagoVendEfect) + decimal.Parse(RetiroOtrosEfect);
                decimal totalEfect = sumaEfect - restaEfect;
                decimal totalTarj = decimal.Parse(VentasTarj) + decimal.Parse(OtrosTarj) + decimal.Parse(CCTarj);
                TotalTarjTxtBox.Text = "$" + totalTarj.ToString();
                TotalEfectTxtBox.Text = "$" + totalEfect.ToString();
                TotalDiaTxtBox.Text = "$" + (sumaEfect + totalTarj - decimal.Parse(montoInicio)).ToString();

                //########//

                decimal ingresosEfect = decimal.Parse(VentasEfect) + decimal.Parse(OtrosEfect) + decimal.Parse(CCEfect);
                decimal ingresosTarj = decimal.Parse(VentasTarj) + decimal.Parse(OtrosTarj) + decimal.Parse(CCTarj);
                decimal egresosEfect = decimal.Parse(PagoVendEfect) + decimal.Parse(RetiroOtrosEfect);
                decimal egresosTarj = decimal.Parse(PagoVendTarj) + decimal.Parse(EgresoOtrosTarj);
                decimal gananciaBruta = (ingresosEfect + ingresosTarj) - (egresosEfect + egresosTarj);
                GananciaTxtBox.Text = "$" + gananciaBruta.ToString();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            Ingreso form = new Ingreso(fechaActual);
            form.DatosGuardados += cargarCaja;
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            Gasto form = new Gasto(fechaActual);
            form.DatosGuardados += cargarCaja;
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            Retiro form = new Retiro(fechaActual);
            form.DatosGuardados += cargarCaja;
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            if (caja.CajaCerrada(fecha))
            {
                MessageBox.Show("Ya se realizó un cierre de caja con anterioridad. Puedes verlo a detalle en el panel de notificaciones.");
            }
            else
            {
                string cierre = Microsoft.VisualBasic.Interaction.InputBox(
                $"Ingrese dinero en caja:",
                "Modificar Cantidad");
                if (cierre == "")
                {
                    MessageBox.Show("No se ingresó un valor, se cerrará la ventana.");
                }
                else
                {
                    decimal Cierre = decimal.Parse(cierre);

                    decimal TotalEfectivo = decimal.Parse(TotalEfectTxtBox.Text.Replace("$", "").Trim());
                    decimal TotalTarjeta = decimal.Parse(TotalTarjTxtBox.Text.Replace("$", "").Trim());
                    decimal TotalDia = decimal.Parse(TotalDiaTxtBox.Text.Replace("$", "").Trim());
                    decimal Inicio = decimal.Parse(CajaInicioTxtBox.Text.Replace("$", "").Trim());
                    var resultado = MessageBox.Show(
                       "¿Está seguro de que desea cerrar la caja?",
                       "Confirmar Cierre",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {

                        caja.CierreCaja(fecha, TotalEfectivo, TotalTarjeta, TotalDia, Cierre, Inicio);
                        caja.NotifiCierreCaja(TotalEfectivo, TotalTarjeta, TotalDia, Cierre, Inicio);
                        MessageBox.Show("Cierre de caja hecho, información guardada.");
                    }
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string CajaActual = CajaInicioTxtBox.Text;
            string CajaEditada = Microsoft.VisualBasic.Interaction.InputBox(
               $"Modificar dinero en caja:",
               "Modificar Cantidad".ToString());
            if (CajaEditada == "")
            {
                MessageBox.Show("No se ingresó un valor, se cerrará la ventana");

            }
            else
            {
                CajaInicioTxtBox.Text = CajaEditada;
                CajaL cajaL = new CajaL();
                cajaL.ModMontoInicio(CajaEditada);
                cajaL.NotifiCaja(CajaActual, CajaEditada);
                MessageBox.Show("Caja inicial modificada");
                cargarCaja();
            }
        }

        private void Caja_Load(object sender, EventArgs e)
        {

        }
    }
}
