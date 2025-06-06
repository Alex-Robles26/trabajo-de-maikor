using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


namespace CapaDatos
{
    // Clase base
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }
        public string TipoCliente { get; set; }

        public virtual decimal AplicarDescuento(decimal total)
        {
            return total; // Sin descuento
        }
    }

    // Clase hija: ClienteRegular
    public class ClienteRegular : Cliente
    {
        public override decimal AplicarDescuento(decimal total)
        {
            return total * 0.95m;
        }
    }

    // Clase hija: ClienteVIP
    public class ClienteVIP : Cliente
    {
        public override decimal AplicarDescuento(decimal total)
        {
            return total * 0.85m;
        }
    }

    // Acceso a datos
    public class ClienteDAL
    {
        private readonly string conexion = "Server=.;Database=GestionClientes;Integrated Security=true;TrustServerCertificate=True;";

        // Crear
        public void InsertarCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                string query = "INSERT INTO Cliente (Nombre, Telefono, FechaAlta, TipoCliente) VALUES (@Nombre, @Telefono, @FechaAlta, @TipoCliente)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@FechaAlta", cliente.FechaAlta);
                cmd.Parameters.AddWithValue("@TipoCliente", cliente.TipoCliente);
                cmd.ExecuteNonQuery();
            }
        }

        // Leer
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                string query = "SELECT * FROM Cliente";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader["TipoCliente"].ToString();
                    Cliente cliente = tipo == "VIP" ? new ClienteVIP() :
                                      tipo == "Regular" ? new ClienteRegular() :
                                      new Cliente();

                    cliente.ClienteID = Convert.ToInt32(reader["ClienteID"]);
                    cliente.Nombre = reader["Nombre"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    cliente.FechaAlta = Convert.ToDateTime(reader["FechaAlta"]);
                    cliente.TipoCliente = tipo;

                    lista.Add(cliente);
                }
            }

            return lista;
        }

        // Actualizar
        public void ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                string query = "UPDATE Cliente SET Nombre = @Nombre, Telefono = @Telefono, FechaAlta = @FechaAlta, TipoCliente = @TipoCliente WHERE ClienteID = @ClienteID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@FechaAlta", cliente.FechaAlta);
                cmd.Parameters.AddWithValue("@TipoCliente", cliente.TipoCliente);
                cmd.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar
        public void EliminarCliente(int clienteID)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                string query = "DELETE FROM Cliente WHERE ClienteID = @ClienteID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
