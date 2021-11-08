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
namespace P2_AP1_Julio_Cesar.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cTiposTarea.xaml
    /// </summary>
    public partial class cTiposTarea : Window
    {
        public cTiposTarea()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<TiposTareas>();

            switch (FiltroComboBox.SelectedIndex)
            {
                case 0: //Listado
                    listado = TiposTareasBLL.GetTiposTarea();
                    break;
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
