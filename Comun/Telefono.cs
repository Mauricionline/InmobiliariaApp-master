using System;
using System.Collections.Generic;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que permie crear un objeto Telefono
    /// </summary>
    public class Telefono
    {
        #region
        /// <summary>
        /// identificador del telefono
        /// </summary>
        public int IdTelefono { get; set; }

        /// <summary>
        /// Numero del telefono
        /// </summary>        
        public int NumeroTelefono { get; set; }

        /// <summary>
        /// tipo de telefono
        /// </summary>      
        public byte TipodeTelefono { get; set; }

        /// <summary>
        /// identificador de Persona
        /// </summary>
        public int IdPersona { get; set; }

        /// <summary>
        /// Estado para sabes si es activo, inactivo,etc
        /// </summary>
        public byte EstadoModificacion { get; set; }

        /// <summary>
        /// Fecha de modificacion de algun dato del email
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        #endregion
    }
}
