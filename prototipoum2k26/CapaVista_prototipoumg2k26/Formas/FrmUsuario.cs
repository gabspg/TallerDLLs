using System;
using System.Linq;
using System.Windows.Forms;
using CapaControlador_prototipoumg2k26;

namespace CapaVista_prototipoumg2k26.Formas
{
    public partial class FrmUsuario : Form
    {
        private ModeloUsuario usuario = new ModeloUsuario();

        public FrmUsuario()
        {
            InitializeComponent();
            panIngresoDatos.Enabled = false;
            CargarDatos();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            listaUsuarios();
        }

        private void listaUsuarios()
        {
            try
            {
                dgvUsuario.DataSource = usuario.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvUsuario.DataSource = null;
            dgvUsuario.DataSource = usuario.FindbyId(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvUsuario.DataSource = null;
            dgvUsuario.DataSource = usuario.FindbyId(txtSearch.Text).ToList();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            usuario.NombreUsuario = txtNombre.Text;
            usuario.ContrasenaUsuario = txtContraseña.Text;

            // CORRECCIÓN: Se accede al ComboBox contenido dentro del UserControl comboI1
            var cboInterno = comboI1.Controls.OfType<ComboBox>().FirstOrDefault();
            if (cboInterno != null && cboInterno.SelectedValue != null)
            {
                usuario.IdRolUsuario = Convert.ToInt32(cboInterno.SelectedValue);
            }

            bool valido = new Ayudas.ValidacionDatos(usuario).Validar();

            if (valido == true)
            {
                string resultado = usuario.GrabarCambios();

                MessageBox.Show(resultado);

                listaUsuarios();

                Reinicio();
            }
        }

        private void Reinicio()
        {
            panIngresoDatos.Enabled = false;

            txtNombre.Clear();
            txtContraseña.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panIngresoDatos.Enabled = true;

            usuario.Estado = EstadoEntidad.Added;

            txtNombre.Clear();
            txtContraseña.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count > 0 && dgvUsuario.CurrentRow != null)
            {
                panIngresoDatos.Enabled = true;

                usuario.Estado = EstadoEntidad.Modified;

                if (dgvUsuario.CurrentRow.Cells[0].Value != null)
                {
                    usuario.IdPK = Convert.ToInt32(dgvUsuario.CurrentRow.Cells[0].Value);
                }

                if (dgvUsuario.CurrentRow.Cells[1].Value != null)
                {
                    txtNombre.Text = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
                }

                if (dgvUsuario.CurrentRow.Cells[2].Value != null)
                {
                    txtContraseña.Text = dgvUsuario.CurrentRow.Cells[2].Value.ToString();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count > 0 && dgvUsuario.CurrentRow != null)
            {
                usuario.Estado = EstadoEntidad.Deleted;

                if (dgvUsuario.CurrentRow.Cells[0].Value != null)
                {
                    usuario.IdPK = Convert.ToInt32(dgvUsuario.CurrentRow.Cells[0].Value);
                }

                string resultado = usuario.GrabarCambios();

                MessageBox.Show(resultado);

                listaUsuarios();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void CargarDatos()
        {
            comboI1.llenarCombo(
                "Tbl_Rol",
                "IdRol",
                "NombreRol"
            );
        }
    }
}