using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiTiendaAF.Concexion;
using MySql.Data.MySqlClient;

namespace MiTiendaAF.models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nombre {  get; set; }
        public String Username {  get; set; }
        public String Password {  get; set; }


        //Constructores /*Vacio y con inicializadores*/
        public Usuario() { }

        public Usuario(string nombre, string username, string password)
        {
            Nombre = nombre;
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return "ID " + Id + " " + Nombre + " " + Username;
        }

        //Crear (INSERT) /*ok*/
        public Usuario Guardar()
        {
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "INSERT INTO usuario (nombre, username, password) VALUES (@nombre, @username, @password)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@password", Password);

            cmd.ExecuteNonQuery();

            //Obtener el ID generado
            Id = (int)cmd.LastInsertedId;

            conexion.cerrar();
            return this;
        }

        //BUSCAR USUARIO POR ID 
        public static Usuario BuscarPorId(int id)
        {
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "SELECT * FROM usuario WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            Usuario usuario = null;

            if (reader.Read()) 
            {
                usuario = new Usuario //requiere constructor vacio para crear este objeto
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString()
                };
            }

            reader.Close();
            conexion.cerrar();

            return usuario;
        }

        //ACTUALIZAR DATOS DE TABLA USUARIO
        public Usuario Actualizar()
        {
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "UPDATE usuario SET nombre = @nombre, username = @username, password = @password WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@username", Username);
            cmd.Parameters.AddWithValue("@password", Password);
            cmd.Parameters.AddWithValue("@id", Id);

            cmd.ExecuteNonQuery();
            conexion.cerrar();

            return this;
        }

        //ELIMINAR USUARIO DE TABLA USANDO ID
        public bool Eliminar() 
        {
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "DELETE FROM usuario WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Id);

            int rowsAffected = cmd.ExecuteNonQuery();
            conexion.cerrar();

            return rowsAffected > 0;
        }

        //OBTENER TODOS LOS REGISTROS DE TABLA
        public static List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = "SELECT * FROM usuario";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Usuario user = new Usuario()
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString()
                };
                lista.Add(user);
            }

            reader.Close();
            conexion.cerrar();

            return lista;
        }

        //SOLO BUSCAR USUARIO POR ID

        public static Usuario buscarUsuarioPorUser(string username) 
        {
            Conn conexion = new Conn();
            var conn = conexion.conectar();

            // Consulta SQL para buscar usuario por username
            string query = "SELECT * FROM usuario WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);

            MySqlDataReader reader = cmd.ExecuteReader();
            Usuario usuario = null;

            if (reader.Read())
            {
                usuario = new Usuario
                {
                    Id = Convert.ToInt32(reader["id"]), // Id sigue siendo necesario para actualizar
                    Nombre = reader["nombre"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString()
                };
            }

            reader.Close();
            conexion.cerrar();

            return usuario;
        }


        //BUSCAR USUARIO POR USERNAME PARA CONFIRMAR ACCESO A APP
        //Solo es como muestra ya que las contraseñas deben ser resguardadas en ddbb

        public static Usuario BuscarPorUsernameAcces(string username,string password)
        {

            Conn conexion = new Conn();
            var conn = conexion.conectar();

            string query = password == null
                ? "SELECT * FROM usuario WHERE username = @username"
                : "SELECT * FROM usuario WHERE username = @username AND password = @password";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            if (password != null)
            {
                cmd.Parameters.AddWithValue("@password", password);
            }

            MySqlDataReader reader = cmd.ExecuteReader();

            Usuario usuario = null;

            if (reader.Read())
            {
                usuario = new Usuario
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nombre = reader["nombre"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString()
                };
            }

            reader.Close();
            conexion.cerrar();

            return usuario;
        }
    }
}
