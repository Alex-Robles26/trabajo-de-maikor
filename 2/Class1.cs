using System;
using System.Collections.Generic;
using CapaDatos;

namespace CapaNegocio
{
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        // Agregar cliente
        public void AgregarCliente(Cliente cliente)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new Exception("El nombre no puede estar vacío.");

            if (cliente.FechaAlta > DateTime.Now)
                throw new Exception("La fecha de alta no puede ser en el futuro.");

            clienteDAL.InsertarCliente(cliente);
        }

        // Listar clientes
        public List<Cliente> ObtenerTodos()
        {
            return clienteDAL.ObtenerClientes();
        }

        // Editar cliente
        public void EditarCliente(Cliente cliente)
        {
            if (cliente.ClienteID <= 0)
                throw new Exception("Cliente inválido.");

            clienteDAL.ActualizarCliente(cliente);
        }

        // Eliminar cliente
        public void EliminarCliente(int clienteID)
        {
            if (clienteID <= 0)
                throw new Exception("ID no válido.");

            clienteDAL.EliminarCliente(clienteID);
        }

        // Calcular descuento según tipo
        public decimal CalcularTotalConDescuento(Cliente cliente, decimal totalOriginal)
        {
            return cliente.AplicarDescuento(totalOriginal);
        }
    }
}
