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
        List<Persona> personas_encontradas;
        public VentanaUsuarios()
        {
            InitializeComponent();
            mostrar_usuarios();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();            
        }

        public void obtener_empleados_primer_apellido(string primer_apellido)
        {
            personas_encontradas = PersonasBrl.buscar_persona_por_primer_apellido(primer_apellido);
            datagrid_Usuarios.ItemsSource = personas_encontradas;
        }

        private void Btn_buscar_usuario_Click(object sender, RoutedEventArgs e)
        {
            string primer_apellido = txt_primer_apellido.Text;
            obtener_empleados_primer_apellido(primer_apellido);                        
        }

        private void btn_eliminar_usuario_Click(object sender, RoutedEventArgs e)
        {
            Persona persona_boton = (Persona)((Button)e.Source).DataContext;
            string nombre_usuario = persona_boton.Nombres.ToString();
            PersonasBrl.Eliminar(persona_boton.IdPersona);
            MessageBox.Show(string.Format("Eliminaste a {0}",nombre_usuario));
            string primer_apellido = txt_primer_apellido.Text;
            obtener_empleados_primer_apellido(primer_apellido);
        }

        private void btn_modificar_usuario_Click(object sender, RoutedEventArgs e)
        {
            Persona persona_boton = (Persona)((Button)e.Source).DataContext;
            VentanaModificarUsuario ventanaModificarUsuario = new VentanaModificarUsuario(persona_boton);
            ventanaModificarUsuario.Show();
            
        }

        private void btn_detalle_usuario_Click(object sender, RoutedEventArgs e)
        {
            Persona persona_boton = (Persona)((Button)e.Source).DataContext;
        }

        private void Btn_nuevo_usuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevoUsuario ventanaNuevoUsuario = new VentanaNuevoUsuario();
            ventanaNuevoUsuario.Show();
            
        }

        private void Btn_nuevo_Empleado_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevoEmpleado ventanaNuevoEmpleado = new VentanaNuevoEmpleado();
            ventanaNuevoEmpleado.Show();
            
        }

        private void mostrar_usuarios()
        {
            personas_encontradas = PersonasBrl.mostrar_todo_los_empleados();
            datagrid_Usuarios.ItemsSource = personas_encontradas;
        }
    }
}
