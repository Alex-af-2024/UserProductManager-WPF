using System;
using System.Collections.Generic;
using MiTiendaAF.Concexion;
using MySql.Data.MySqlClient;

namespace MiTiendaAF.models
{
    public class Producto
    {
        public int Codigo { get; set; } // sin autoincremental, es pkey
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        // Constructores
        public Producto() { }

        public Producto(int codigo, string nombre, double precio, int stock)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        // Crear (INSERT)
        public Producto Guardar()
        {
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "INSERT INTO producto (codigo, nombre, precio, stock) VALUES (@codigo, @nombre, @precio, @stock)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@codigo", Codigo);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@precio", Precio);
            cmd.Parameters.AddWithValue("@stock", Stock);

            cmd.ExecuteNonQuery();
            conexion.cerrar();

            return this;
        }

        // Buscar producto por codigo
        public static Producto BuscarPorCodigo(int codigo)
        {
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "SELECT * FROM producto WHERE codigo = @codigo";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@codigo", codigo);

            MySqlDataReader reader = cmd.ExecuteReader();
            Producto producto = null;

            if (reader.Read())
            {
                producto = new Producto
                {
                    Codigo = Convert.ToInt32(reader["codigo"]),
                    Nombre = reader["nombre"].ToString(),
                    Precio = Convert.ToDouble(reader["precio"]),
                    Stock = Convert.ToInt32(reader["stock"])
                };
            }

            reader.Close();
            conexion.cerrar();

            return producto;
        }

        // Actualizar datos del producto
        public Producto Actualizar()
        {
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "UPDATE producto SET nombre = @nombre, precio = @precio, stock = @stock WHERE codigo = @codigo";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@precio", Precio);
            cmd.Parameters.AddWithValue("@stock", Stock);
            cmd.Parameters.AddWithValue("@codigo", Codigo);

            cmd.ExecuteNonQuery();
            conexion.cerrar();

            return this;
        }

        // Eliminar producto por codigo
        public bool Eliminar()
        {
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "DELETE FROM producto WHERE codigo = @codigo";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@codigo", Codigo);

            int rowsAffected = cmd.ExecuteNonQuery();
            conexion.cerrar();

            return rowsAffected > 0;
        }

        // Obtener todos los registros de la tabla producto
        public static List<Producto> ObtenerTodos()
        {
            List<Producto> lista = new List<Producto>();
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "SELECT * FROM producto";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Producto producto = new Producto
                {
                    Codigo = Convert.ToInt32(reader["codigo"]),
                    Nombre = reader["nombre"].ToString(),
                    Precio = Convert.ToDouble(reader["precio"]),
                    Stock = Convert.ToInt32(reader["stock"])
                };
                lista.Add(producto);
            }

            reader.Close();
            conexion.cerrar();

            return lista;
        }
    }
}
