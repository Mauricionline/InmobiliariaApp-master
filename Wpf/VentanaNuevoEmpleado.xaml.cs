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
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.PersonaBrl;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Wpf
{
    /// <summary>
    /// Interaction logic for VentanaNuevoEmpleado.xaml
    /// </summary>
    public partial class VentanaNuevoEmpleado : Window
    {
        public VentanaNuevoEmpleado()
        {
            InitializeComponent();
        }

        private void Btn_crear_usuario_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado();

            empleado.Nombres = txt_nombres.Text;
            empleado.PrimerApellido = txt_primer_apellido.Text;
            empleado.SegundoApellido = txt_segundo_apellido.Text;
            empleado.Cargo = byte.Parse(txt_cargo.Text); //modificar por combobox
            empleado.Carnet = txt_carnet.Text;

            EmpleadosBrl.Insertar(empleado);
            MessageBox.Show("Empleado Registrado correctamente");

            VentanaUsuarios ventanaUsuarios = new VentanaUsuarios();
            ventanaUsuarios.Show();
            this.Close();
        }
    }
}
