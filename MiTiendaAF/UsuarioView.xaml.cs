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
using System.Windows.Shapes;
using MiTiendaAF.models;


namespace MiTiendaAF
{
    /// <summary>
    /// Lógica de interacción para UsuarioView.xaml
    /// </summary>
    public partial class UsuarioView : Window
    {
        public UsuarioView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        //METODO PARA AGREGAR USUARIO
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string username = txtUsuario.Text;
            string password = txtContraseña.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Usuario usuario = new Usuario(nombre, username, password);
            usuario.Guardar();
            MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            LimpiarCampos();
        }

        // METODO PARA LIMPIAR LOS TXT
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtBuscarPorUserName.Clear();
            listUsuarios.ItemsSource = null;
        }

        //METODO PARA ELIMINAR USUARIO
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsuario.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Usuario usuario = Usuario.BuscarPorUsernameAcces(username, null);
            if (usuario != null)
            {
                usuario.Eliminar();
                MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //ACTUALIZAR USUARIO
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string username = txtUsuario.Text;
            string password = txtContraseña.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Buscar usuario por username
            Usuario usuario = Usuario.buscarUsuarioPorUser(username);
            if (usuario != null)
            {
                // Actualizar los valores del usuario
                usuario.Nombre = nombre;
                usuario.Password = password;

                // Llamar al método Actualizar()
                usuario.Actualizar();
                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            List<Usuario> usuarios = Usuario.ObtenerTodos();
            listUsuarios.ItemsSource = usuarios.Select(u => $"ID: {u.Id}, Nombre: {u.Nombre}, Usuario: {u.Username}").ToList();
        }


        //BUSCAR USUARIO POR USERNAME
        private void btnBuscarPorUserName_Click(object sender, RoutedEventArgs e)
        {
            string username = txtBuscarPorUserName.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario para buscar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Usuario usuario = Usuario.BuscarPorUsernameAcces(username, null);
            if (usuario != null)
            {
                txtNombre.Text = usuario.Nombre;
                txtUsuario.Text = usuario.Username;
                txtContraseña.Text = usuario.Password;
                MessageBox.Show("Usuario encontrado.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnUsIrHome_Click(object sender, RoutedEventArgs e)
        {
            HomeView pantalla = new HomeView();
            pantalla.Show();
            this.Close();
        }
    }
}
