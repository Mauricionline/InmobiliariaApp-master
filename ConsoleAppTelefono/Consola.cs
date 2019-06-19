using System;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.ConsoleAppTelefono
{
    class TelefonoConsola
    {
        static void Main(string[] args)
        {
            Empleado persona = new Empleado()
            {
                Nombres = "Completo",
                PrimerApellido = "completo",
                SegundoApellido = "completo",
                Carnet = "444123",
                Cargo = 1,
                Sexo = 1,
                EstadoModificacion = 0,
                Sueldo = 1000,
            };

            Telefono telefono = new Telefono()
            {
                NumeroTelefono = 123,
                IdPersona = 1,
                TipodeTelefono = 1,
                EstadoModificacion = 0
            };

            Cuenta cuenta = new Cuenta()
            {
                Usuario = "completo",
                Contrasena = "12345",
            };

            DireccionPersona direccionPersona = new DireccionPersona()
            {
                NombreDireccion = "Av.Solomeo Paredes",
            };

            Email email = new Email()
            {
                CorreoEmail = "SolomeoParedes@gmail.com"
            };

            PersonaBrl.EmpleadosBrl.Insertar(persona, telefono, cuenta, direccionPersona, email);

            //PersonaBrl.TelefonoBrl.Insertar(telefono);

            //PersonaBrl.PersonaBrl.Insertar(persona);
            //PersonaBrl.PersonaBrl.Eliminar(5);
            //Persona persona_devolver = PersonaBrl.PersonaBrl.Obtener(4);
            //persona_devolver.Nombres = "Alejandro";
            //persona_devolver.PrimerApellido = "Fernandez";
            //persona_devolver.SegundoApellido = "Galindo";
            //PersonaBrl.PersonaBrl.Actualizar(persona_devolver);


            //Console.WriteLine(persona_devolver.Nombres);
            //Console.WriteLine(persona_devolver.PrimerApellido);
            //Console.WriteLine(persona_devolver.SegundoApellido);
            //Console.ReadKey();
            //    Telefono telefono = new Telefono()
            //    {
            //        NumeroTelefono = 4444444,
            //        TipodeTelefono = 1,
            //        IdPersona = new Persona()
            //        {
            //            IdPersona = 2,
            //        },
            //        EstadoModificacion = 1,
            //    };

            //    PersonaBrl.TelefonoBrl.Insertar(telefono);

            //    Telefono telefono_actualizado = new Telefono
            //    {
            //        IdTelefono = 27,
            //        NumeroTelefono = 8888888,
            //    };
            //    PersonaBrl.TelefonoBrl.Actualizar(telefono_actualizado);
            //    PersonaBrl.TelefonoBrl.Eliminar(27);
            //}
            //static void Main(string[] args)
            //{
            //    //Email email = new Email()
            //    //{
            //    //    CorreoEmail = "Prueba@hotmail.com",
            //    //    idPersona = new Persona()
            //    //    {
            //    //        IdPersona = 4,
            //    //    },
            //    //    EstadoModificacion = 1,
            //    //};

            //    //PersonaBrl.EmailBrl.Insertar(email);

            //    //PersonaBrl.EmailBrl.Eliminar(2);

            //    Email email_actualizado = new Email()
            //    {
            //        idEmail = 2,
            //        CorreoEmail = "Prueba12345@hotmail.com",
            //        idPersona = new Persona()
            //        {
            //            IdPersona = 4,
            //        },               
            //    };
            //    PersonaBrl.EmailBrl.Actualizar(email_actualizado);
            //}
            /*static void Main(string[] args)
            {
                Persona persona = new Persona()
                {
                    Nombres = "Jose Cristian",
                    PrimerApellido = "Almaraz",
                    SegundoApellido = "Sejas",
                    Carnet = "12345678",
                };

                //PersonaBrl.PersonaBrl.Insertar(persona);
                //PersonaBrl.PersonaBrl.Eliminar(5);
                Persona persona_devolver = PersonaBrl.PersonaBrl.Obtener(4);
                persona_devolver.Nombres = "Alejandro";
                persona_devolver.PrimerApellido = "Fernandez";
                persona_devolver.SegundoApellido = "Galindo";
                PersonaBrl.PersonaBrl.Actualizar(persona_devolver);


                //Console.WriteLine(persona_devolver.Nombres);
                //Console.WriteLine(persona_devolver.PrimerApellido);
                //Console.WriteLine(persona_devolver.SegundoApellido);
                //Console.ReadKey();
            }*/


            //static void Main(string[] args)
            //{



            //    ///Empleado CRUD
            //    //DateTime date = new DateTime(2000, 05, 20);
            //    //Empleado empleado = new Empleado()
            //    //{
            //    //    Nombres = "Pedro",
            //    //    PrimerApellido = "Nogales",
            //    //    SegundoApellido = "Alarcon",
            //    //    Carnet = "6547981",
            //    //    Sexo = 0,
            //    //    Cargo = 1,
            //    //    Sueldo = 5000,
            //    //    //FechaContratacion = date
            //    //};

            //    //PersonaBrl.EmpleadosBrl.Insertar(empleado);
            //    //Empleado empleado_devuelto = PersonaBrl.EmpleadosBrl.Obtener(33);

            //    //Console.WriteLine(empleado_devuelto.Nombres);
            //    //Console.WriteLine(empleado_devuelto.PrimerApellido);
            //    //Console.WriteLine(empleado_devuelto.SegundoApellido);
            //    //Console.WriteLine(empleado_devuelto.Cargo);
            //    //Console.WriteLine(empleado_devuelto.Sueldo);
            //    //Console.ReadLine();


            //    //PersonaBrl.PersonaBrl.Insertar(persona);
            //    //PersonaBrl.PersonaBrl.Eliminar(5);
            //    //      Persona persona_devolver = PersonaBrl.PersonaBrl.Obtener(4);
            //    //persona_devolver.Nombres = "Alejandro";
            //    //persona_devolver.PrimerApellido = "Fernandez";
            //    //persona_devolver.SegundoApellido = "Galindo";
            //    //PersonaBrl.PersonaBrl.Actualizar(persona_devolver);


            //    //Console.WriteLine(persona_devolver.Nombres);
            //    //Console.WriteLine(persona_devolver.PrimerApellido);
            //    //Console.WriteLine(persona_devolver.SegundoApellido);            
            //}


            //static void Main(string[] args)
            //{
            //    Cuenta cuenta = new Cuenta()
            //    {
            //        Usuario = "Mauricionline",
            //        Contrasena = "12345",
            //        idPersona = new Persona()
            //        {
            //            IdPersona = 2,
            //        },
            //    };

            //    PersonaBrl.CuentaBrl.Insertar(cuenta);
            //}

            //static void Main(string[] args)
            //{
            //   /* Direccion direccion = new Direccion()
            //    {
            //        NombreDireccion = "Av. Aroma",               

            //        IdPersona = new Persona()
            //        {
            //            IdPersona = 2,
            //        },       

            //    };

            //    PersonaBrl.DireccionPersonaBrl.Insertar(direccion);*/
            //}

            //static void Main(string[] args)
            //{
            //    //DireccionPersona direccion_persona = new DireccionPersona()
            //    //{
            //    //    NombreDireccion = "Av. Aroma",
            //    //    IdDireccion = 8,
            //    //    IdPersona = new Persona()
            //    //    {
            //    //        IdPersona = 2,
            //    //    },

            //    //};

            //    //PersonaBrl.DireccionPersonaBrl.Insertar(direccion_persona);
            //}
        }
    }
}

