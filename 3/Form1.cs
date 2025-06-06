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
                if (clienteIDSeleccionado == -1)
                {
                    MessageBox.Show("Selecciona un cliente para editar.");
                    return;
                }

                Cliente actualizado = CrearClienteDesdeFormulario();
                clienteBLL.EditarCliente(actualizado);
                MessageBox.Show("Cliente actualizado correctamente");
                CargarClientes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteIDSeleccionado == -1)
                {
                    MessageBox.Show("Selecciona un cliente para eliminar.");
                    return;
                }

                clienteBLL.EliminarCliente(clienteIDSeleccionado);
                MessageBox.Show("Cliente eliminado");
                CargarClientes();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvClientes.Rows[e.RowIndex];
                clienteIDSeleccionado = Convert.ToInt32(fila.Cells["ClienteID"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                dtpFechaAlta.Value = Convert.ToDateTime(fila.Cells["FechaAlta"].Value);
                cmbTipoCliente.SelectedItem = fila.Cells["TipoCliente"].Value.ToString();
            }
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
    }
}
