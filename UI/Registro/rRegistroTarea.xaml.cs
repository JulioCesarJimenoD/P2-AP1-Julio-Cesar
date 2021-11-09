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
using P2_AP1_Julio_Cesar.BLL;
using P2_AP1_Julio_Cesar.Entidades;


namespace P2_AP1_Julio_Cesar.UI.Registro
{
    /// <summary>
    /// Interaction logic for rRegistroTarea.xaml
    /// </summary>
    public partial class rRegistroTarea : Window

    {
        private Proyectos proyecto = new Proyectos();
        public ProyectosDetalle detalle = new ProyectosDetalle();

        public rRegistroTarea()
        {
            InitializeComponent();
            this.DataContext = proyecto;

            TipoTareaComboBox.ItemsSource = TiposTareasBLL.GetTiposTarea();
            TipoTareaComboBox.SelectedValuePath = "TipoTareaId";
            TipoTareaComboBox.DisplayMemberPath = "DescripcionTipoTarea";

            TotalTextBox.Text = "0";
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyecto;
        }
        private void Limpiar()
        {
            this.proyecto = new Proyectos();
            this.DataContext = proyecto;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Proyectos esValido = ProyectoBLL.Buscar(proyecto.ProyectoId);

            return (esValido != null);
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos encontrado = ProyectoBLL.Buscar(proyecto.ProyectoId);

            if (encontrado != null)
            {
                proyecto = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Proyecto no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            proyecto.Detalle.Add(new ProyectosDetalle(Convert.ToInt32(ProyectoIdTextBox.Text), (int)TipoTareaComboBox.SelectedValue,
                 RequerimientoTextBox.Text, int.Parse(TiempoTextBox.Text), (TiposTareas)TipoTareaComboBox.SelectedItem, proyecto));

            TotalTextBox.Text = proyecto.Total.ToString();
            Cargar();


            TotalTextBox.Focus();
            TotalTextBox.Clear();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                proyecto.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                proyecto.Total -= int.Parse(TotalTextBox.Text);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (proyecto.ProyectoId == 0)
            {
                paso = ProyectoBLL.Guardar(proyecto);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = ProyectoBLL.Guardar(proyecto);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "ERROR");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos existe = ProyectoBLL.Buscar(proyecto.ProyectoId);

            if (existe == null)
            {
                MessageBox.Show("No existe el grupo en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                ProyectoBLL.Eliminar(proyecto.ProyectoId);
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }
    }
}
