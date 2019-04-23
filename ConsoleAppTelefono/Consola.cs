using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.ConsoleAppTelefono
{
    class TelefonoConsola
    {
        /*static void Main(string[] args)
        {
            Telefono telefono = new Telefono()
            {
                NumeroTelefono = 4444444,
                TipodeTelefono = 1,
                IdPersona = new Persona()
                {
                    IdPersona = 2,
                },
                EstadoModificacion = 1,
            };

            PersonaBrl.TelefonoBrl.Insertar(telefono);
        }*/
        /*static void Main(string[] args)
        {
        Email email = new Email()
            {
                CorreoEmail = "Maurialejandro8@hotmail.com",
                idPersona = new Persona()
                {
                    IdPersona = 2,
                },
                EstadoModificacion = 1,
            };

            PersonaBrl.EmailBrl.Insertar(email);
        }*/
        /*static void Main(string[] args)
        {
            Persona persona  = new Persona()
            {
               Nombres  = "Daniel Cristian",
               PrimerApellido = "Escobar",
               SegundoApellido = "Sejas",
               Carnet = "8036500",               
            };

            PersonaBrl.PersonaBrl.Insertar(persona);
        }*/
        static void Main(string[] args)
        {
            Cuenta cuenta = new Cuenta()
            {
               Usuario  = "Mauricionline",
               Contrasena = "12345",
                idPersona = new Persona()
                {
                    IdPersona = 2,
                },
            };

            PersonaBrl.CuentaBrl.Insertar(cuenta);
        }
    }
}
