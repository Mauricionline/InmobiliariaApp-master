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

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Wpf
{
    /// <summary>
    /// Interaction logic for VentanaUsuarios.xaml
    /// </summary>
    public partial class VentanaUsuarios : Window
    {
        public VentanaUsuarios()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Close();
        }

        public void obtener_empleados()
        {

        }

        private void Btn_buscar_usuario_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
