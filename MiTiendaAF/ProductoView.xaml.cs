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
    /// Lógica de interacción para ProductoView.xaml
    /// </summary>
    public partial class ProductoView : Window
    {
        public ProductoView()
        {
            InitializeComponent();
        }

        //ELIMINAR PRODUCTO
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int codigo;
            if (!int.TryParse(txtCodigo.Text, out codigo))
            {
                MessageBox.Show("Debe ingresar un código válido para eliminar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Producto producto = Producto.BuscarPorCodigo(codigo);
            if (producto != null)
            {
                producto.Eliminar();
                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //AGREGAR PRODUCTO
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            int codigo;
            string nombre = txtNombreRepuesto.Text;
            double precio;
            int stock;

            // Validar campos vacíos y tipos de datos
            if (!int.TryParse(txtCodigo.Text, out codigo) ||
                string.IsNullOrEmpty(nombre) ||
                !double.TryParse(txtPrecio.Text, out precio) ||
                !int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Todos los campos son obligatorios y deben tener el formato correcto.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Comprobar si el producto ya existe
            Producto productoExistente = Producto.BuscarPorCodigo(codigo);
            if (productoExistente != null)
            {
                MessageBox.Show("El producto con el código especificado ya existe.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Crear y guardar el producto
            Producto producto = new Producto(codigo, nombre, precio, stock);
            producto.Guardar();
            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            LimpiarCampos();
        }

        //ACTUALIZAR PRODUCTO
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            int codigo;
            string nombre = txtNombreRepuesto.Text;
            double precio;
            int stock;

            if (!int.TryParse(txtCodigo.Text, out codigo) ||
                string.IsNullOrEmpty(nombre) ||
                !double.TryParse(txtPrecio.Text, out precio) ||
                !int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Todos los campos son obligatorios y deben tener el formato correcto.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Producto producto = Producto.BuscarPorCodigo(codigo);
            if (producto != null)
            {
                producto.Nombre = nombre;
                producto.Precio = precio;
                producto.Stock = stock;
                producto.Actualizar();
                MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //BUSCAR PRODUCTO POR USERNAME
        private void btnBuscarPorUserName_Click(object sender, RoutedEventArgs e)
        {
            int codigo;
            if (!int.TryParse(txtBuscarPorUserName.Text, out codigo))
            {
                MessageBox.Show("Debe ingresar un código válido para buscar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Producto producto = Producto.BuscarPorCodigo(codigo);
            if (producto != null)
            {
                txtCodigo.Text = producto.Codigo.ToString();
                txtNombreRepuesto.Text = producto.Nombre;
                txtPrecio.Text = producto.Precio.ToString();
                txtStock.Text = producto.Stock.ToString();
                MessageBox.Show("Producto encontrado.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //LISTAR PRODUCTOS
        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            List<Producto> productos = Producto.ObtenerTodos();
            listproductos.ItemsSource = productos.Select(p => $"Código: {p.Codigo}, Nombre: {p.Nombre}, Precio: {p.Precio}, Stock: {p.Stock}").ToList();
        }

        private void btnProIrHome_Click(object sender, RoutedEventArgs e)
        {
            HomeView pantalla = new HomeView();
            pantalla.Show();
            this.Close();
        }

        //LIMPIAR IMPUTS
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombreRepuesto.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtBuscarPorUserName.Clear();
            listproductos.ItemsSource = null;
        }
    }
}
