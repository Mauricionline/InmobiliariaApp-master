using System;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que me sirve para crear objetos Persona
    /// </summary>
    public class Persona
    {
        #region atributos y propiedades
        /// <summary>
        /// identficador de la persona
        /// </summary>
        public int IdPersona { get; set; }
        /// <summary>
        /// Nombre de la persona
        /// </summary>
        public string Nombres { get; set; }
        /// <summary>
        /// Primer apellido de la persona
        /// </summary>
        public string PrimerApellido { get; set; }
        /// <summary>
        /// Segundo apellido de la persona
        /// </summary>
        public string SegundoApellido { get; set; }
        /// <summary>
        /// cargo de la persona
        /// </summary>
        public byte Cargo { get; set; }
        /// <summary>
        /// carnet de la persona
        /// </summary>
        public string Carnet { get; set; }
        /// <summary>
        /// Estado para sabes si es activo, inactivo,etc
        /// </summary>
        public byte EstadoModificacion { get; set; }
        /// <summary>
        /// Fecha de modificacion de algun dato de la persona
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        #endregion
    }
}
