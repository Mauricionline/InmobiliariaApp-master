using System;
using System.Collections.Generic;
using System.Data;
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
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.PersonaBrl;

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

        public List<Persona> obtener_empleados_primer_apellido(string primer_apellido)
        {
            List<Persona> personas_encontradas = PersonasBrl.buscar_persona_por_primer_apellido(primer_apellido);
            return personas_encontradas;
        }

        private void Btn_buscar_usuario_Click(object sender, RoutedEventArgs e)
        {
            string primer_apellido = txt_primer_apellido.Text;
            List<Persona> personas_encontradas = obtener_empleados_primer_apellido(primer_apellido);

            datagrid_Usuarios.ItemsSource = personas_encontradas;
            
        }

        private void btn_eliminar_usuario_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            string nombre_usuario = dataRowView[1].ToString();
            MessageBox.Show("hiciste click en " + nombre_usuario);
        }
    }
}
