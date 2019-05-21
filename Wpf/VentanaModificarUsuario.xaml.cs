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
    /// Interaction logic for VentanaModificarUsuario.xaml
    /// </summary>
    public partial class VentanaModificarUsuario : Window
    {
        Persona persona;
        public VentanaModificarUsuario(Persona persona)
        {
            InitializeComponent();
            txt_nombres.Text = persona.Nombres;
            txt_primer_apellido.Text = persona.PrimerApellido;
            txt_segundo_apellido.Text = persona.SegundoApellido;
            txt_cargo.Text = persona.Cargo.ToString(); //modificar por combobox
            txt_carnet.Text = persona.Carnet;
            this.persona = persona;
        }

        private void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            persona.Nombres = txt_nombres.Text;
            persona.PrimerApellido = txt_primer_apellido.Text;
            persona.SegundoApellido = txt_segundo_apellido.Text;
            persona.Cargo = byte.Parse(txt_cargo.Text); //modificar por combobox
            persona.Carnet = txt_carnet.Text;


            PersonasBrl.Actualizar(persona);
            MessageBox.Show("Datos Modificados");
            VentanaUsuarios ventanaUsuarios = new VentanaUsuarios();
            ventanaUsuarios.Show();
            this.Close();
        }
    }
}
