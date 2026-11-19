using SistemaFinal.Capa_Logica;
using System.Data;
using static SistemaFinal.Capa_Datos.LoginD;
using static SistemaFinal.Capa_Datos.UsuarioD;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class Usuarios : Form
    {
        private bool datosModificados;
        private bool cerrarPorPerderFoco = true;
        private Dictionary<string, bool> ordenAscendente = new Dictionary<string, bool>();

        
        private UsuarioL usuarioL = new UsuarioL();

        public Usuarios(Form padre)
        {
            InitializeComponent();
            this.Owner = padre;
            datosModificados = false;
            this.ShowInTaskbar = false;
            this.Deactivate += Usuarios_Deactivate;
            EmailTxtBox.TextChanged += CamposTxtBox_TextChanged;
            ContraTxtBox.TextChanged += CamposTxtBox_TextChanged;
            MostDgv();
            Estilos.Tema.AplicarEstiloUsuarios(this);
        }


        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MostDgv()
        {
            var listaUsuarios = usuarioL.ListarUsuarios()
        .Where(u => u.ID != 1)
        .Select(u => new
        {
            u.ID, 
            Email = u.Email,
            Rol = u.Rol == 1 ? "Administrador" : "Vendedor",
            Estado = u.Activo == 1 ? "Activo" : "Inactivo",
            u.Activo 
        })
        .ToList();

            dataGridView1.DataSource = listaUsuarios;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
            if (dataGridView1.Columns["ID"] != null)
                dataGridView1.Columns["ID"].Visible = false;

            if (dataGridView1.Columns["Activo"] != null)
                dataGridView1.Columns["Activo"].Visible = false;

            if (dataGridView1.Columns["ContraHash"] != null)
                dataGridView1.Columns["ContraHash"].Visible = false;
        }

        private void CamposTxtBox_TextChanged(object sender, EventArgs e)
        {
            datosModificados = true;
        }

        private void GuardarDatos()
        {
            try
            {
                string email = EmailTxtBox.Text.Trim();
                string contra = ContraTxtBox.Text;
                string rolTexto = ComboBoxRol.SelectedItem.ToString();
                int rol = (rolTexto == "Administrador") ? 1 : 0;

                // Delegamos el guardado y el hasheado a la Capa de Lógica
                if (usuarioL.GuardarUsuario(email, contra, rol))
                {
                    MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar controles
                    EmailTxtBox.Clear();
                    ContraTxtBox.Clear();
                    ComboBoxRol.SelectedIndex = 0;

                    datosModificados = false;
                    MostDgv();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario. Verifique si el correo ya está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var fila = dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if (fila != null)
            {
                var tipoFila = fila.GetType();
                var valorActivo = tipoFila.GetProperty("Activo")?.GetValue(fila)?.ToString();

                if (!string.IsNullOrEmpty(valorActivo))
                {
                    if (valorActivo == "1")
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(204, 255, 255);
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 182);
                    }
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (!ordenAscendente.ContainsKey(columnName))
            {
                ordenAscendente[columnName] = true;
            }

            if (dataGridView1.DataSource is List<Capa_Datos.UsuarioD.UsuarioDTO> usuarios && usuarios.Count > 0)
            {
                bool ascending = ordenAscendente[columnName];
                usuarios = ascending
                    ? usuarios.OrderBy(r => r.GetType().GetProperty(columnName)?.GetValue(r)).ToList()
                    : usuarios.OrderByDescending(r => r.GetType().GetProperty(columnName)?.GetValue(r)).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = usuarios;
                ordenAscendente[columnName] = !ascending;
                dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = ascending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
            }
        }

        private void Usuarios_Deactivate(object sender, EventArgs e)
        {
            if (cerrarPorPerderFoco)
            {
                if (this.Owner != null && !this.Owner.Focused)
                {
                    if (datosModificados)
                    {
                        var result = MessageBox.Show(
                            "Tienes cambios sin guardar. ¿Deseas guardarlos antes de cerrar?",
                            "Confirmación",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            GuardarDatos();
                            this.Close();
                        }
                        else if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }

        private void ReactUsuBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int idUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);

                    if (activo == 0)
                    {
                        bool exito = usuarioL.CambiarEstadoUsuario(idUsuario, 1);

                        if (exito)
                        {
                            MostDgv();
                            MessageBox.Show("El usuario se reactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo reactivar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya está activo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cerrarPorPerderFoco = true;
            }
        }

        private void BajaUsuBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int idUsuario = Convert.ToInt32(filaSeleccionada.Cells["ID"].Value);
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);

                    if (activo == 1)
                    {
                        bool exito = usuarioL.CambiarEstadoUsuario(idUsuario, 0);

                        if (exito)
                        {
                            MostDgv();
                            MessageBox.Show("El usuario se desactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo desactivar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya se encuentra inactivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cerrarPorPerderFoco = true;
            }
        }

        private void AgUsuBtn_Click_1(object sender, EventArgs e)
        {
            cerrarPorPerderFoco = false;

            if (!string.IsNullOrWhiteSpace(EmailTxtBox.Text) && !string.IsNullOrWhiteSpace(ContraTxtBox.Text))
            {
                GuardarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, complete los campos de Email y Contraseña.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrWhiteSpace(EmailTxtBox.Text)) EmailTxtBox.Focus();
                else ContraTxtBox.Focus();
            }

            cerrarPorPerderFoco = true;
        }

        private void Usuarios_Load_1(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);

            ComboBoxRol.Items.Clear();
            ComboBoxRol.Items.Add("Administrador");
            ComboBoxRol.Items.Add("Vendedor");
            if (ComboBoxRol.Items.Count > 0)
            {
                ComboBoxRol.SelectedIndex = 0;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                EmailTxtBox.Text = fila.Cells["Email"].Value?.ToString() ?? "";

                string rolTexto = fila.Cells["Rol"].Value?.ToString();
                ComboBoxRol.SelectedItem = rolTexto;

                ContraTxtBox.Clear();
            }
        }

        private void ModUsuBtn_Click(object sender, EventArgs e)
        {
            cerrarPorPerderFoco = false;
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un usuario de la lista para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idUsuario = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                string email = EmailTxtBox.Text.Trim();
                string contraNueva = ContraTxtBox.Text; 
                int rol = (ComboBoxRol.SelectedItem?.ToString() == "Administrador") ? 1 : 0;

                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("El campo de Email no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (usuarioL.ModificarUsuario(idUsuario, email, rol, contraNueva))
                {
                    MessageBox.Show("Usuario actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datosModificados = false;
                    EmailTxtBox.Clear();
                    ContraTxtBox.Clear();
                    ComboBoxRol.SelectedIndex = 0;

                    MostDgv();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cerrarPorPerderFoco = true;
            }
        }
    }
}
