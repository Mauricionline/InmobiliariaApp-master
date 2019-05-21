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
    /// Interaction logic for VentanaNuevoUsuario.xaml
    /// </summary>
    public partial class VentanaNuevoUsuario : Window
    {
        public VentanaNuevoUsuario()
        {
            InitializeComponent();
        }

        private void Btn_crear_usuario_Click(object sender, RoutedEventArgs e)
        {
            Persona persona = new Persona();

            persona.Nombres = txt_nombres.Text;
            persona.PrimerApellido = txt_primer_apellido.Text;
            persona.SegundoApellido = txt_segundo_apellido.Text;
            persona.Cargo = byte.Parse(txt_cargo.Text); //modificar por combobox
            persona.Carnet = txt_carnet.Text;

            PersonasBrl.Insertar(persona);
            MessageBox.Show("Usuario Registrado correctamente");

            VentanaUsuarios ventanaUsuarios = new VentanaUsuarios();
            ventanaUsuarios.Show();
            this.Close();
        }
    }
}
