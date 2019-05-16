using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.EmpleadoTest
{
    [TestClass]
    public class TelefonoTest
    {
        [TestMethod]
        public void TestInsertar()
        {
            //Arrange
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
            //Act
            PersonaBrl.TelefonoBrl.Insertar(telefono);
            //Assert

            //Assert.
        }
    }
}
