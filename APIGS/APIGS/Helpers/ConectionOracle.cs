using APIGS.Controllers;
using APIGS.Modelo;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Net.NetworkInformation;

namespace APIGS.Helpers
{
    public class ConectionOracle
    {
        private readonly string connectionString;

        public ConectionOracle(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("OracleDbConnection");
        }

        public OracleConnection OpenConnection()
        {
            OracleConnection connection = new OracleConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa a la base de datos Oracle.");
                return connection;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de Oracle: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectarse: {ex.Message}");
                return null;
            }
        }

        // Método para cerrar la conexión
        public void CloseConnection(OracleConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                    Console.WriteLine("Conexión cerrada.");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Error al cerrar la conexión: {ex.Message}");
                }
            }
        }

        public List<Cliente> GetClienteList(string query) {
            List<Cliente> client = new List<Cliente>();
            using (OracleConnection connection = OpenConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("No se pudo abrir la conexión.");
                    return client;
                }

                try
                {
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente c = new Cliente
                        {
                            CLIENTE_ID = Convert.ToInt32(reader["CLIENTE_ID"]),
                            CLAVE = reader["CLAVE"].ToString(),
                            NOMBRE = reader["NOMBRE"].ToString(),
                            ESTATUS = reader["ESTATUS"].ToString(),
                        };

                        client.Add(c);
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Error en la consulta: {ex.Message}");
                }
                finally
                {
                    CloseConnection(connection);
                }
            }

            return client;
        }


        public void InsertaVenta(int clienteid, int producto, int cantidad)
        {

            using (OracleConnection connection = OpenConnection())
            {
                try
                {
                    // Crear comando para ejecutar el SP InsertaVenta
                    OracleCommand command = new OracleCommand("InsertaVenta", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Agregar el parámetro de entrada
                    command.Parameters.Add("p_ClienteId", OracleDbType.Int32).Value = clienteid;
                    command.Parameters.Add("p_ProductoId", OracleDbType.Int32).Value = producto;
                    command.Parameters.Add("p_Cantidad", OracleDbType.Int32).Value = cantidad;

                    // Ejecutar el SP
                    command.ExecuteNonQuery();
                    Console.WriteLine("Venta insertada correctamente.");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Error en la inserción de la venta: {ex.Message}");
                }
                finally
                {
                    CloseConnection(connection);
                }
            }
        }



        public List<Producto> GetProductos(string query)
        {
            List<Producto> productos = new List<Producto>();

            using (OracleConnection connection = OpenConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("No se pudo abrir la conexión.");
                    return productos;
                }

                try
                {
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            PRODUCTO_ID = Convert.ToInt32(reader["PRODUCTO_ID"]),
                            DESCRIPCION = reader["DESCRIPCION"].ToString(),
                            COSTO_UNITARIO = Convert.ToDecimal(reader["COSTO_UNITARIO"]),
                            ESTATUS = reader["ESTATUS"].ToString(),
                        };

                        productos.Add(producto);
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Error en la consulta: {ex.Message}");
                }
                finally
                {
                    CloseConnection(connection);
                }
            }

            return productos;
        }


        public List<DeTalleVentas> DeTalleVentas(string query)
        {
            List<DeTalleVentas> DetVenta = new List<DeTalleVentas>();

            using (OracleConnection connection = OpenConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("No se pudo abrir la conexión.");
                    return DetVenta;
                }

                try
                {
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DeTalleVentas producto = new DeTalleVentas
                        {
                            IdVenta = Convert.ToInt32(reader["VENTA_ID"]),
                            Descripcion = reader["DESCRIPCION"].ToString(),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            CostoUnitario = Convert.ToDecimal(reader["Costo_Unitario"]),
                            Total = Convert.ToDecimal(reader["Total"]),
                        };

                        DetVenta.Add(producto);
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Error en la consulta: {ex.Message}");
                }
                finally
                {
                    CloseConnection(connection);
                }
            }

            return DetVenta;
        }

        public List<VentasCliente> GetventasClientes(string query)
        {
            List<VentasCliente> ventascleinte = new List<VentasCliente>();

            using (OracleConnection connection = OpenConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("No se pudo abrir la conexión.");
                    return ventascleinte;
                }

                try
                {
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VentasCliente vc = new VentasCliente
                        {
                            clave = reader["CLAVE"].ToString(),
                            Nombre = reader["NOMBRE"].ToString(),
                            Mail = reader["Mail"].ToString(),
                            Fechaventa = Convert.ToDateTime(reader["Fechaventa"]),
                            TotalVenta = Convert.ToDecimal(reader["TotalVenta"]),
                            IdVenta = Convert.ToInt32(reader["VENTA_ID"])
                        };

                        ventascleinte.Add(vc);
                    }
                }
                catch (OracleException ex)
                {
                    Console.WriteLine($"Error en la consulta: {ex.Message}");
                }
                finally
                {
                    CloseConnection(connection);
                }
            }
            return ventascleinte;
        }


    }
}
