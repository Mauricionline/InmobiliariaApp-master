using System;
using System.Collections.Generic;
namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase para crear objetos de la clase Atencion
    /// </summary>
    public class Atencion
    {
        #region
        /// <summary>
        /// persona la cual sera atendida
        /// </summary>
        public List<Persona> idPersona { get; set; }
        /// <summary>
        /// empleado el cual dara atencion
        /// </summary>
        public List<Empleado> idEmpleado { get; set; }
        /// <summary>
        /// fecha y hora de la atencion
        /// </summary>
        public DateTime FechaHoraAtencion { get; set; }
        /// <summary>
        /// Estado para saber si la atencion esta activa, inactiva,etc
        /// </summary>
        public byte EstadoModificacion { get; set; }
        /// <summary>
        /// Fecha de modificacion de algun dato de la atencion
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        #endregion
    }
}
