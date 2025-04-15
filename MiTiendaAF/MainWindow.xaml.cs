using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MiTiendaAF.Concexion;
using MiTiendaAF.models;

namespace MiTiendaAF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Hacer concexión con instancia y medoto Concetar de clase Conn.
            Conn conn = new Conn();
            conn.conectar();

            this.Background = Brushes.LightGray;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {

            // Obtener los valores de los campos de texto
            string usernameIngresado = txtUsuarioM.Text;
            string passwordIngresado = txtContrasenaM.Text;

            // Verificar campos vacíos
            if (string.IsNullOrEmpty(usernameIngresado) || string.IsNullOrEmpty(passwordIngresado))
            {
                MessageBox.Show("Favor de ingresar ambos campos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Llamar a la base de datos para buscar el usuario
            Usuario usuarioValido = Usuario.BuscarPorUsernameAcces(usernameIngresado, passwordIngresado);

            if (usuarioValido != null)
            {
                // Si el usuario es válido, abrir la nueva ventana
                HomeView ventana = new HomeView();
                ventana.Show();
                this.Close();
            }
            else
            {
                // Si no es válido, mostrar un mensaje de error
                MessageBox.Show("Usuario o contraseña incorrecta.", "Acceso denegado", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsuarioM.Clear();
                txtContrasenaM.Clear();
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {   //btnSalir consulta salida con condiciones con Switch case
            MessageBoxResult result = MessageBox.Show(
                "¿Desea guardar los cambios antes de salir?",
                "Confirmar Salida",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    //Llamar a una función para guardar cambios
                    guardarCambios();
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.No:
                    //Cerrar sin guardar
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.Cancel:
                    //Cancelar el cierre
                    break;
            }
        }

        private void guardarCambios()
        {
            //Funcion muestra mensaje y tipo de respuesta ok.
            MessageBox.Show("Cambios guardados con éxito", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);  
        }

    }
}
