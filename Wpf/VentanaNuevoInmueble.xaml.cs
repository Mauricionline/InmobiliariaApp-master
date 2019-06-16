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
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.InmobiliariaBrl;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Wpf
{
    /// <summary>
    /// Lógica de interacción para VentanaNuevoInmueble.xaml
    /// </summary>
    public partial class VentanaNuevoInmueble : Window
    {
        public VentanaNuevoInmueble()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inmueble inmueble = new Inmueble();

            inmueble.estado = Convert.ToByte(txb_Estado.Text);
            inmueble.zona = txb_Zona.Text;
            inmueble.superficieSprox = txb_Superficie.Text;
            InmuebleBrl.Insertar(inmueble);
            MessageBox.Show("Inmueble Registrado correctamente");
            this.Close();
        }
    }
}
