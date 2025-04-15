using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace MiTiendaAF.Concexion
{//FORMA ANTIGUA
    internal class Conn
    {
        MySqlConnection conn = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "tiendadb";
        static string usuario = "root";
        static string password = "root";
        static string puerto = "3306";

        //Metodo para esstableces concexion con base de datos
        public MySqlConnection conectar()
        {
            string conexionString = $"server={servidor}; database={bd}; UID={usuario}; password={password}; port={puerto}";

            try
            {
                conn.ConnectionString = conexionString;
                conn.Open();
                //MessageBox.Show("Estas conectado a tiendadb");//Solo para probar
                Console.WriteLine("conectado a DB");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show("No se conceto a tiendadb.");//Solo para probar
                Console.WriteLine("Concexión a db fallida.");
            }

            return conn;
        }

        public void cerrar()
        {
            conn.Close();
            Console.WriteLine("cerrado...");
            //MessageBox.Show("Conexión a base de datos cerrada.");//Solo para probar
        }

    }

}

