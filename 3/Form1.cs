using CapaDatos;
using CapaNegocio;

namespace _3
{
    public partial class Form1 : Form
    {
        private ClienteBLL clienteBLL = new ClienteBLL();
        private int clienteIDSeleccionado = -1;
        public Form1()
        {
            InitializeComponent();
            cmbTipoCliente.Items.AddRange(new string[] { "Regular", "VIP" });
            cmbTipoCliente.SelectedIndex = 0;
            CargarClientes();
            dgvClientes.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clienteBLL.ObtenerTodos();
        }
        private Cliente CrearClienteDesdeFormulario()
        {
            string tipo = cmbTipoCliente.SelectedItem.ToString();
            Cliente cliente = tipo == "VIP" ? new ClienteVIP() : new ClienteRegular();

            cliente.Nombre = txtNombre.Text.Trim();
            cliente.Telefono = txtTelefono.Text.Trim();
            cliente.FechaAlta = dtpFechaAlta.Value;
            cliente.TipoCliente = tipo;
            cliente.ClienteID = clienteIDSeleccionado;

            return cliente;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevo = CrearClienteDesdeFormulario();
                clienteBLL.AgregarCliente(nuevo);
                MessageBox.Show("Cliente agregado correctamente");
                CargarClientes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona una fila para editar.");
                    return;
                }

                // Obtener fila seleccionada
                DataGridViewRow fila = dgvClientes.SelectedRows[0];
                int id = Convert.ToInt32(fila.Cells["ClienteID"].Value);

                // Crear cliente actualizado desde los controles
                string tipo = cmbTipoCliente.SelectedItem.ToString();
                Cliente cliente = tipo == "VIP" ? new ClienteVIP() : new ClienteRegular();

                cliente.ClienteID = id;
                cliente.Nombre = txtNombre.Text.Trim();
                cliente.Telefono = txtTelefono.Text.Trim();
                cliente.FechaAlta = dtpFechaAlta.Value;
                cliente.TipoCliente = tipo;

                clienteBLL.EditarCliente(cliente);
                MessageBox.Show("Cliente actualizado correctamente.");
                CargarClientes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona una fila para eliminar.");
                    return;
                }

                // Obtener la fila seleccionada
                DataGridViewRow fila = dgvClientes.SelectedRows[0];

                // Obtener el ID del cliente desde la celda
                int id = Convert.ToInt32(fila.Cells["ClienteID"].Value);

                // Confirmación
                var confirm = MessageBox.Show("¿Estás seguro de eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    clienteBLL.EliminarCliente(id);
                    MessageBox.Show("Cliente eliminado exitosamente.");
                    CargarClientes(); // Refresca la grilla
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtMonto.Text, out decimal monto))
                {
                    MessageBox.Show("Ingresa un monto válido.");
                    return;
                }

                Cliente cliente = CrearClienteDesdeFormulario();
                decimal totalConDescuento = clienteBLL.CalcularTotalConDescuento(cliente, monto);
                lblTotalConDescuento.Text = $"Total con descuento: {totalConDescuento:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            clienteIDSeleccionado = -1;
            cmbTipoCliente.SelectedIndex = 0;
            dtpFechaAlta.Value = DateTime.Today;
            lblTotalConDescuento.Text = "";
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                // Obtener valores de la fila seleccionada
                clienteIDSeleccionado = Convert.ToInt32(fila.Cells["ClienteID"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                dtpFechaAlta.Value = Convert.ToDateTime(fila.Cells["FechaAlta"].Value);
                cmbTipoCliente.SelectedItem = fila.Cells["TipoCliente"].Value.ToString();
            }
        }
    }
}
