using System;
using System.Collections.Generic;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que permie crear un objeto Email
    /// </summary>
    public class Email
    {
        #region
        /// <summary>
        /// identificador del email
        /// </summary>
        public int idEmail { get; set; }

        /// <summary>
        /// correo electronico
        /// </summary>
        public string CorreoEmail { get; set; }

        /// <summary>
        /// identificador de la persona a la cual pertenece el email
        /// </summary>
        public Persona idPersona { get; set; }

        /// <summary>
        /// Estado para saber si el email es activo, inactivo,etc
        /// </summary>
        public byte EstadoModificacion { get; set; }

        /// <summary>
        /// Fecha de modificacion de algun dato del email
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        #endregion
    }
}
