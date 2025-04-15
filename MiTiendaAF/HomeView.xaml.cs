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

namespace MiTiendaAF
{
  
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();
            this.Background = Brushes.LightGray;

        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {//función para cambiar de ventana y cerrar esta.
            MainWindow ventana= new MainWindow();
            ventana.Show();
            this.Close();
        }

        private void btnAdminUsuarios_Click(object sender, RoutedEventArgs e)
        {
            UsuarioView ventana = new UsuarioView();
            ventana.Show();
            this.Close();
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            ProductoView ventana = new ProductoView();
            ventana.Show();
            this.Close();
        }
    }
}
