using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinal.Estilos
{
    internal class Tema
    {
        public static readonly Color FondoMenuOscuro = Color.FromArgb(26, 29, 32);       
        public static readonly Color AmarilloMonkey = Color.FromArgb(255, 214, 0);       
        public static readonly Color TealAuriculares = Color.FromArgb(0, 188, 212);      
        public static readonly Color FondoTrabajo = Color.FromArgb(244, 246, 248);       
        public static readonly Color BlancoTarjetas = Color.White;
        public static readonly Color TextoOscuro = Color.FromArgb(33, 37, 41);
        public static readonly Color TextoClaro = Color.White;
        public static readonly Color FilaActiva = Color.FromArgb(230, 247, 238);         
        public static readonly Color FilaInactiva = Color.FromArgb(253, 237, 237);       

        public static void AplicarEstructura(Form form, bool esFormHijo = false)
        {
            form.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            if (esFormHijo)
            {
                form.BackColor = FondoTrabajo;
            }
            else
            {
                form.BackColor = BlancoTarjetas;
            }

            EstilarControles(form.Controls);
        }

        private static void EstilarControles(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (c is Panel p)
                {
                    if (p.Name.ToLower().Contains("panel1") || p.Name.ToLower().Contains("menu") || p.Name.ToLower().Contains("lateral"))
                    {
                        p.BackColor = FondoMenuOscuro;
                    }
                    else if (p.Name.ToLower().Contains("paginacion"))
                    {
                        p.BackColor = Color.FromArgb(233, 236, 239);
                    }
                    else if (p.Dock == DockStyle.Fill || p.Name.ToLower().Contains("panel2"))
                    {
                        p.BackColor = FondoTrabajo;
                    }
                }

                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                    string nombre = btn.Name.ToLower();

                    if (nombre.Contains("save") || nombre.Contains("guardar") || nombre.Contains("ag") || nombre.Contains("agregar"))
                    {
                        btn.BackColor = AmarilloMonkey;
                        btn.ForeColor = TextoOscuro;
                    }
                    else if (nombre.Contains("buscar") || nombre.Contains("react") || nombre.Contains("reactivar") || nombre.Contains("stock"))
                    {
                        btn.BackColor = TealAuriculares;
                        btn.ForeColor = TextoClaro;
                    }
                    else if (nombre.Contains("cancel") || nombre.Contains("baja"))
                    {
                        btn.BackColor = Color.FromArgb(220, 53, 69);
                        btn.ForeColor = TextoClaro;
                    }
                    else
                    {
                        btn.BackColor = Color.Transparent;
                        btn.ForeColor = TextoClaro;
                        btn.FlatAppearance.MouseOverBackColor = TealAuriculares;
                    }
                }

                if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = BlancoTarjetas;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgv.GridColor = Color.FromArgb(222, 226, 230);

                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = FondoMenuOscuro;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextoClaro;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    dgv.ColumnHeadersHeight = 35;

                    dgv.DefaultCellStyle.SelectionBackColor = TealAuriculares;
                    dgv.DefaultCellStyle.SelectionForeColor = TextoClaro;
                    dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
                    dgv.RowTemplate.Height = 30;
                }

                if (c is TextBox || c is ComboBox)
                {
                    c.Font = new Font("Segoe UI", 10.5F);
                    c.BackColor = BlancoTarjetas;
                    c.ForeColor = TextoOscuro;
                }

                if (c is Label lbl)
                {
                    if (lbl.Parent is Panel pan && pan.BackColor == FondoMenuOscuro)
                    {
                        lbl.ForeColor = TextoClaro;
                    }
                    else
                    {
                        lbl.ForeColor = TextoOscuro;
                    }
                }

                if (c.HasChildren)
                {
                    EstilarControles(c.Controls);
                }
            }
        }

        public static void AplicarEstiloCaja(Form form)
        {
            AplicarEstructura(form, esFormHijo: true);

            form.BackColor = FondoMenuOscuro;

            Color tarjetaOscura = Color.FromArgb(33, 37, 41);

            if (form.Controls.Find("panel1", true).FirstOrDefault() is Panel p1) { p1.BackColor = tarjetaOscura; foreach (Control c in p1.Controls) if (c is Label) c.ForeColor = Color.White; }
            if (form.Controls.Find("panel2", true).FirstOrDefault() is Panel p2) { p2.BackColor = tarjetaOscura; foreach (Control c in p2.Controls) if (c is Label) c.ForeColor = Color.White; }
            if (form.Controls.Find("panel3", true).FirstOrDefault() is Panel p3) { p3.BackColor = tarjetaOscura; foreach (Control c in p3.Controls) if (c is Label) c.ForeColor = Color.White; }
            if (form.Controls.Find("panel4", true).FirstOrDefault() is Panel p4) { p4.BackColor = tarjetaOscura; foreach (Control c in p4.Controls) if (c is Label) c.ForeColor = Color.White; }

            if (form.Controls.Find("label1", true).FirstOrDefault() is Label l1) l1.ForeColor = Color.White;
            if (form.Controls.Find("label2", true).FirstOrDefault() is Label l2) l2.ForeColor = Color.White;
            if (form.Controls.Find("LabelFecha", true).FirstOrDefault() is Label lFecha) lFecha.ForeColor = Color.White;
            if (form.Controls.Find("label22", true).FirstOrDefault() is Label l22) l22.ForeColor = Color.White;
            if (form.Controls.Find("label21", true).FirstOrDefault() is Label l21) l21.ForeColor = Color.White;
            if (form.Controls.Find("label18", true).FirstOrDefault() is Label l18) l18.ForeColor = Color.White;

            if (form.Controls.Find("button1", true).FirstOrDefault() is Button b1) { b1.BackColor = TealAuriculares; b1.ForeColor = Color.White; }
            if (form.Controls.Find("button2", true).FirstOrDefault() is Button b2) { b2.BackColor = Color.FromArgb(108, 117, 125); b2.ForeColor = Color.White; }
            if (form.Controls.Find("button3", true).FirstOrDefault() is Button b3) { b3.BackColor = Color.FromArgb(108, 117, 125); b3.ForeColor = Color.White; }
            if (form.Controls.Find("button4", true).FirstOrDefault() is Button b4) { b4.BackColor = AmarilloMonkey; b4.ForeColor = TextoOscuro; }
            if (form.Controls.Find("button5", true).FirstOrDefault() is Button b5) { b5.BackColor = Color.FromArgb(220, 53, 69); b5.ForeColor = Color.White; }

            if (form.Controls.Find("TotalDiaTxtBox", true).FirstOrDefault() is TextBox txtTotal)
            {
                txtTotal.BackColor = AmarilloMonkey;
                txtTotal.ForeColor = TextoOscuro;
                txtTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }

            if (form.Controls.Find("button6", true).FirstOrDefault() is Button b6)
            {
                b6.BackColor = TealAuriculares;
                b6.ForeColor = Color.White;
                b6.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
        }

        public static void AplicarEstiloClientesP(Form form)
        {
            AplicarEstructura(form, esFormHijo: true);

            form.BackColor = FondoMenuOscuro;

            if (form.Controls.Find("panel1", true).FirstOrDefault() is Panel pMenu)
            {
                pMenu.BackColor = FondoMenuOscuro;
                foreach (Control c in pMenu.Controls)
                {
                    if (c is Button btn)
                    {
                        string nombreBtn = btn.Name.ToLower();

                        if (nombreBtn.Contains("ag") || nombreBtn.Contains("agregar"))
                        {
                            btn.BackColor = AmarilloMonkey;
                            btn.ForeColor = TextoOscuro;
                        }
                        else if (nombreBtn.Contains("mod"))
                        {
                            btn.BackColor = Color.FromArgb(70, 130, 180); 
                            btn.ForeColor = Color.White;
                        }
                        else if (nombreBtn.Contains("pago") || nombreBtn.Contains("cta") || nombreBtn.Contains("corriente"))
                        {
                            btn.BackColor = TealAuriculares;
                            btn.ForeColor = Color.White;
                        }
                        else
                        {
                            btn.BackColor = Color.FromArgb(90, 95, 105);
                            btn.ForeColor = Color.White;
                        }

                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                }
            }

            if (form.Controls.Find("panel2", true).FirstOrDefault() is Panel pTabla) pTabla.BackColor = FondoTrabajo;
            if (form.Controls.Find("panel3", true).FirstOrDefault() is Panel pContenedor) pContenedor.BackColor = FondoTrabajo;
        }
        public static void AplicarEstiloModalCliente(Form form)
        {
            AplicarEstructura(form, esFormHijo: false);

            form.BackColor = FondoMenuOscuro;

            if(form.Controls.Find("panel1", true).FirstOrDefault() is Panel pForm)
            {
                pForm.BackColor = Color.FromArgb(33, 37, 41); 
                foreach (Control c in pForm.Controls)
                {
                    if (c is Label lbl) lbl.ForeColor = Color.White;
                }
            }
            else
            {
                foreach (Control c in form.Controls)
                {
                    if (c is Label lbl) lbl.ForeColor = Color.White;
                }
            }

            foreach (Control c in form.Controls)
            {
                if (c is Label lbl) lbl.ForeColor = Color.White;
            }

            if (form.Controls.Find("SaveBtn", true).FirstOrDefault() is Button bSave) { bSave.BackColor = AmarilloMonkey; bSave.ForeColor = TextoOscuro; bSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); }
            if (form.Controls.Find("button1", true).FirstOrDefault() is Button b1) { b1.BackColor = AmarilloMonkey; b1.ForeColor = TextoOscuro; b1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); }

            if (form.Controls.Find("CancelBtn", true).FirstOrDefault() is Button bCancel) { bCancel.BackColor = Color.FromArgb(220, 53, 69); bCancel.ForeColor = Color.White; bCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); }
            if (form.Controls.Find("button2", true).FirstOrDefault() is Button b2) { b2.BackColor = Color.FromArgb(220, 53, 69); b2.ForeColor = Color.White; b2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); }
        }

        public static void AplicarEstiloVentasP(Form form)
        {
            AplicarEstructura(form, esFormHijo: true);
            form.BackColor = FondoMenuOscuro;
            if (form.Controls.Find("panel1", true).FirstOrDefault() is Panel p1)
            {
                p1.BackColor = FondoMenuOscuro;
                foreach (Control c in p1.Controls)
                {
                    if (c is Label lbl) lbl.ForeColor = Color.White;
                }
            }

            if (form.Controls.Find("panel2", true).FirstOrDefault() is Panel p2)
            {
                p2.BackColor = FondoTrabajo;
                foreach (Control c in p2.Controls)
                {
                    if (c is Label lbl) lbl.ForeColor = TextoOscuro;
                }
            }

            if (form.Controls.Find("PanelArts", true).FirstOrDefault() is Panel pArts)
            {
                pArts.BackColor = FondoTrabajo;
            }

            if (form.Controls.Find("panel3", true).FirstOrDefault() is Panel p3)
            {
                p3.BackColor = FondoMenuOscuro;
            }

            string[] botonesEdicion = { "PrecBtn", "CantBtn", "SenaBtn", "RetirarBtn" };
            foreach (string nombreBtn in botonesEdicion)
            {
                if (form.Controls.Find(nombreBtn, true).FirstOrDefault() is Button btn)
                {
                    btn.BackColor = (nombreBtn == "RetirarBtn") ? Color.FromArgb(220, 53, 69) : TealAuriculares;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
            if (form.Controls.Find("AceptBtn", true).FirstOrDefault() is Button bAcept)
            {
                bAcept.BackColor = AmarilloMonkey;
                bAcept.ForeColor = TextoOscuro;
                bAcept.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }

            if (form.Controls.Find("SalirBtn", true).FirstOrDefault() is Button bSalir)
            {
                bSalir.BackColor = Color.FromArgb(108, 117, 125); 
                bSalir.ForeColor = Color.White;
                bSalir.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
            if (form.Controls.Find("TxtBoxTotal", true).FirstOrDefault() is TextBox txtTotal)
            {
                txtTotal.BackColor = AmarilloMonkey;
                txtTotal.ForeColor = TextoOscuro;
                txtTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            }
        }

        public static void AplicarEstiloConsultarVentas(Form form)
        {
            AplicarEstructura(form, esFormHijo: true);
            form.BackColor = FondoMenuOscuro;

            if (form.Controls.Find("PanelVentas", true).FirstOrDefault() is Panel pVentas)
            {
                pVentas.BackColor = FondoMenuOscuro;

                string[] botonesTeal = { "EfectivoBtn", "TarjetaBtn", "ComprobantesBtn", "ImprimBtn" };
                foreach (string nom in botonesTeal)
                {
                    if (pVentas.Controls.Find(nom, true).FirstOrDefault() is Button b)
                    {
                        b.BackColor = TealAuriculares;
                        b.ForeColor = Color.White;
                        b.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                }

                if (pVentas.Controls.Find("AnularVenta", true).FirstOrDefault() is Button bAnular)
                {
                    bAnular.BackColor = Color.FromArgb(220, 53, 69); // Rojo
                    bAnular.ForeColor = Color.White;
                    bAnular.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }

                if (pVentas.Controls.Find("ReactivarBtn", true).FirstOrDefault() is Button bReac)
                {
                    bReac.BackColor = AmarilloMonkey;
                    bReac.ForeColor = TextoOscuro;
                    bReac.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }

                if (pVentas.Controls.Find("SalirBtn", true).FirstOrDefault() is Button bSalir)
                {
                    bSalir.BackColor = Color.FromArgb(108, 117, 125); 
                    bSalir.ForeColor = Color.White;
                    bSalir.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }

            if (form.Controls.Find("PanelDetalles", true).FirstOrDefault() is Panel pDetalles)
            {
                pDetalles.BackColor = Color.FromArgb(33, 37, 41); 
                foreach (Control c in pDetalles.Controls)
                {
                    if (c is Label lbl) lbl.ForeColor = Color.White;
                }

                if (pDetalles.Controls.Find("TxtBoxTotal", true).FirstOrDefault() is TextBox txtTotDetalle)
                {
                    txtTotDetalle.BackColor = AmarilloMonkey;
                    txtTotDetalle.ForeColor = TextoOscuro;
                    txtTotDetalle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                }
            }
        }

        public static void AplicarEstiloPanelNotificaciones(Form form)
        {
            form.BackColor = FondoMenuOscuro;

            if (form.Controls.Find("flowLayoutPanel1", true).FirstOrDefault() is FlowLayoutPanel flp)
            {
                flp.BackColor = FondoMenuOscuro;
            }
        }

        public static void AplicarEstiloAgregarVendedor(Form form)
        {
            AplicarEstructura(form, esFormHijo: true);
            form.BackColor = FondoMenuOscuro;
            if (form.Controls.Find("panel1", true).FirstOrDefault() is Panel p1)
            {
                p1.BackColor = Color.FromArgb(33, 37, 41); 

                foreach (Control c in p1.Controls)
                {
                    if (c is Label lbl)
                    {
                        lbl.ForeColor = Color.White;
                    }
                }
            }

            foreach (Control c in form.Controls)
            {
                if (c is Label lbl) lbl.ForeColor = Color.White;
            }

            if (form.Controls.Find("AgVenBtn", true).FirstOrDefault() is Button bAg)
            {
                bAg.BackColor = AmarilloMonkey;
                bAg.ForeColor = TextoOscuro;
                bAg.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            if (form.Controls.Find("ModVenBtn", true).FirstOrDefault() is Button bMod)
            {
                bMod.BackColor = TealAuriculares;
                bMod.ForeColor = Color.White;
                bMod.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            if (form.Controls.Find("ReactVenBtn", true).FirstOrDefault() is Button bReact)
            {
                bReact.BackColor = TealAuriculares;
                bReact.ForeColor = Color.White;
                bReact.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            if (form.Controls.Find("BajaVenBtn", true).FirstOrDefault() is Button bBaja)
            {
                bBaja.BackColor = Color.FromArgb(220, 53, 69); 
                bBaja.ForeColor = Color.White;
                bBaja.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            if (form.Controls.Find("CancelBtn", true).FirstOrDefault() is Button bCancel)
            {
                bCancel.BackColor = Color.FromArgb(108, 117, 125); 
                bCancel.ForeColor = Color.White;
                bCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
        }

        public static void AplicarEstiloUsuarios(Form form)
        {
            AplicarEstructura(form, esFormHijo: true);
            form.BackColor = FondoMenuOscuro;

            foreach (Control c in form.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = Color.White;
                }
            }

            if (form.Controls.Find("AgUsuBtn", true).FirstOrDefault() is Button bAg)
            {
                bAg.BackColor = AmarilloMonkey;
                bAg.ForeColor = TextoOscuro;
                bAg.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            if (form.Controls.Find("ModUsuBtn", true).FirstOrDefault() is Button bMod)
            {
                bMod.BackColor = TealAuriculares;
                bMod.ForeColor = Color.White;
                bMod.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            if (form.Controls.Find("ReactUsuBtn", true).FirstOrDefault() is Button bReact)
            {
                bReact.BackColor = TealAuriculares;
                bReact.ForeColor = Color.White;
                bReact.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            if (form.Controls.Find("BajaUsuBtn", true).FirstOrDefault() is Button bBaja)
            {
                bBaja.BackColor = Color.FromArgb(220, 53, 69); 
                bBaja.ForeColor = Color.White;
                bBaja.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            if (form.Controls.Find("CancelBtn", true).FirstOrDefault() is Button bCancel)
            {
                bCancel.BackColor = Color.FromArgb(108, 117, 125);
                bCancel.ForeColor = Color.White;
                bCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
        }

        public static void AplicarEstiloPagoVendedores(Form form)
        {
            // 1. Estructura general base
            AplicarEstructura(form, esFormHijo: false);
            form.BackColor = FondoMenuOscuro;

            // 2. Asegurar que todas las etiquetas sueltas se vean blancas
            foreach (Control c in form.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = Color.White;
                }
            }

            // 3. Botón principal de acción (ej. Pagar / Aceptar -> button1) en Amarillo Monkey
            if (form.Controls.Find("button1", true).FirstOrDefault() is Button b1)
            {
                b1.BackColor = AmarilloMonkey;
                b1.ForeColor = TextoOscuro;
                b1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            // 4. Botón de cancelar / salir (button2) en rojo institucional
            if (form.Controls.Find("button2", true).FirstOrDefault() is Button b2)
            {
                b2.BackColor = Color.FromArgb(220, 53, 69); // Rojo
                b2.ForeColor = Color.White;
                b2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
        }
        public static void AplicarEstiloResumenVentas(Form form)
        {
            // 1. Estructura general base
            AplicarEstructura(form, esFormHijo: true);
            form.BackColor = FondoMenuOscuro;

            // 2. Estilizar el panel principal como tarjeta oscura elegante si existe
            if (form.Controls.Find("panel1", true).FirstOrDefault() is Panel p1)
            {
                p1.BackColor = Color.FromArgb(33, 37, 41); // Tarjeta gris oscuro
                foreach (Control c in p1.Controls)
                {
                    if (c is Label lbl) lbl.ForeColor = Color.White;
                }
            }

            // 3. Asegurar que las etiquetas sueltas del formulario se vean blancas
            foreach (Control c in form.Controls)
            {
                if (c is Label lbl) lbl.ForeColor = Color.White;
            }
        }
        public static void AplicarEstiloVentasXVend(Form form)
        {
            // 1. Estructura general base
            AplicarEstructura(form, esFormHijo: false);
            form.BackColor = FondoMenuOscuro;

            // 2. Poner todas las etiquetas en blanco
            foreach (Control c in form.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = Color.White;
                    lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }

            // 3. Botón principal (SaveBtn / Generar / Aceptar) en Amarillo Monkey
            if (form.Controls.Find("SaveBtn", true).FirstOrDefault() is Button bSave)
            {
                bSave.BackColor = AmarilloMonkey;
                bSave.ForeColor = TextoOscuro;
                bSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            // 4. Botón secundario / cancelar (button1) en Teal o gris
            if (form.Controls.Find("button1", true).FirstOrDefault() is Button b1)
            {
                b1.BackColor = TealAuriculares;
                b1.ForeColor = Color.White;
                b1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
        }
        public static void AplicarEstiloLogin(Form form)
        {
            // 1. Estructura general base
            AplicarEstructura(form, esFormHijo: false);
            form.BackColor = FondoMenuOscuro;

            // 3. Jerarquía inteligente de etiquetas
            foreach (Control c in form.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = Color.White;

                    // Si es el título principal de bienvenida, lo hacemos destacar y ocupar espacio con elegancia
                    if (lbl.Text.Contains("Bienvenido") || lbl.Text.Contains("ingresar"))
                    {
                        lbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        // Etiquetas de campos más grandes y legibles
                        lbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                    }
                }
            }

            foreach (Control c in form.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.Font = new Font("Segoe UI", 18F, FontStyle.Regular);
                }
                else if (c is ComboBox cmb)
                {
                    cmb.Font = new Font("Segoe UI", 18F, FontStyle.Regular);
                }
            }

            // 4. Botón principal de Ingresar (button1) más contundente
            if (form.Controls.Find("button1", true).FirstOrDefault() is Button btnLogin)
            {
                btnLogin.BackColor = AmarilloMonkey;
                btnLogin.ForeColor = TextoOscuro;
                btnLogin.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
                btnLogin.FlatStyle = FlatStyle.Flat;
                btnLogin.FlatAppearance.BorderSize = 0;
            }

            // 5. LinkLabel en Teal con tamaño más cómodo
            if (form.Controls.Find("linkLabel1", true).FirstOrDefault() is LinkLabel link)
            {
                link.LinkColor = TealAuriculares;
                link.ActiveLinkColor = AmarilloMonkey;
                link.VisitedLinkColor = TealAuriculares;
                link.Font = new Font("Segoe UI", 22F, FontStyle.Regular);
                link.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
        public static void AplicarEstiloRecuperacion(Form form)
        {
            // 1. Estructura general base (es una ventana modal/independiente)
            AplicarEstructura(form, esFormHijo: false);
            form.BackColor = FondoMenuOscuro;

            // 2. Etiquetas en blanco nítido y con buen tamaño
            foreach (Control c in form.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = Color.White;
                    lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                }
                // 3. Agrandar el campo de texto del correo para que tenga mejor presencia
                else if (c is TextBox txt)
                {
                    txt.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
                }
            }

            // 4. Botón principal de enviar/recuperar (button1) en Amarillo Monkey protagónico
            if (form.Controls.Find("button1", true).FirstOrDefault() is Button btnRecuperar)
            {
                btnRecuperar.BackColor = AmarilloMonkey;
                btnRecuperar.ForeColor = TextoOscuro;
                btnRecuperar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                btnRecuperar.FlatStyle = FlatStyle.Flat;
                btnRecuperar.FlatAppearance.BorderSize = 0;
            }
        }
    }
}

