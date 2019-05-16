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
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.PersonaBrl;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Wpf;

namespace Wpf
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

        private void Btn_ingresar_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_Login.Text;
            string password = txt_password.Password;

            Cuenta cuenta_login = new Cuenta();
            cuenta_login.Usuario = username;
            cuenta_login.Contrasena = password;

            int estado = CuentaBrl.verificar_cuenta(cuenta_login);

            if (estado == 0)
            {
                Inicio inicio = new Inicio();
                inicio.Show();
                this.Close();                
            }
            if (estado == 1)
            {
                MessageBox.Show("Usuario no encontrado");
            }
            if (estado == 2)
            {
                MessageBox.Show("Contraseña incorrecta");
            }
            if (estado == 3)
            {
                MessageBox.Show("La cuenta esta inhabilitada");
            }

        }
    }
}
