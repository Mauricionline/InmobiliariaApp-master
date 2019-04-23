using System;
using System.Collections.Generic;
namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que me permite crear objetos de la clase Cuenta
    /// </summary>
    public class Cuenta
    {
        #region propiedades
        /// <summary>
        /// identificador de la cuenta
        /// </summary>
        public int idCuenta { get; set; }
        /// <summary>
        /// usuario de la persona
        /// </summary>
        public string Usuario { get; set; }
        /// <summary>
        /// contraseña de la persona
        /// </summary>
        public string Contrasena { get; set; }
        /// <summary>
        /// Persona a la cual pertenece la cuenta
        /// </summary>
        public Persona idPersona { get; set; }
        /// <summary>
        /// Estado para sabes si es activo, inactivo,etc
        /// </summary>
        public byte EstadoModificacion { get; set; }
        /// <summary>
        /// Fecha de modificacion de algun dato de la cuenta
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        #endregion
    }
}
