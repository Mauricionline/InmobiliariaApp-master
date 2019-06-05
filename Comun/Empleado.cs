using System;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que me permite crear objetos Empleado
    /// </summary>
    public class Empleado: Persona
    {
        #region propiedades
        /// <summary>
        /// Sueldo del Empleado
        /// </summary>
        public decimal Sueldo { get; set; }
        /// <summary>
        /// Fecha de contratacion del empleado
        /// </summary>
        public DateTime FechaContratacion { get; set; }

        #endregion
    }
}
