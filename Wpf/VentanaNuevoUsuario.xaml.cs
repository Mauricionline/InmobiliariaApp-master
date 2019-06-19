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
            Telefono telefono = new Telefono();
            Cuenta cuenta = new Cuenta();
            DireccionPersona direccionPersona = new DireccionPersona();
            Email email = new Email();
            //datos de persona
            persona.Nombres = txt_nombres.Text;
            persona.PrimerApellido = txt_primer_apellido.Text;
            persona.SegundoApellido = txt_segundo_apellido.Text;
            persona.Cargo = 0;
            persona.Carnet = txt_carnet.Text;
            //datos del telefono
            telefono.NumeroTelefono = int.Parse(txt_telefono.Text);
            telefono.TipodeTelefono = byte.Parse(combo_tipo_telefono.SelectedIndex.ToString());
            //datos de la cuenta
            cuenta.Usuario = txt_usuario.Text;
            cuenta.Contrasena = psw_password.Password;
            //datos de la direccion
            direccionPersona.NombreDireccion = txt_direccion.Text;
            //datos del email
            email.CorreoEmail = txt_email.Text;


            PersonasBrl.Insertar(persona, telefono, cuenta, direccionPersona, email);
            MessageBox.Show("Usuario Registrado correctamente");

            VentanaUsuarios ventanaUsuarios = new VentanaUsuarios();
            ventanaUsuarios.Show();
            this.Close();
        }
    }
}
