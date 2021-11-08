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
using P2_AP1_Julio_Cesar.UI.Consultas;
using P2_AP1_Julio_Cesar.UI.Registro;

namespace P2_AP1_Julio_Cesar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRegistroTarea proyecto = new rRegistroTarea();
            proyecto.Show();
        }

        private void TiposTareasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cTiposTarea tarea = new cTiposTarea();
            tarea.Show();
        }

        private void ProyectoCMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cRegistroTarea registroTarea = new cRegistroTarea();
            registroTarea.Show();

        }
    }
}
