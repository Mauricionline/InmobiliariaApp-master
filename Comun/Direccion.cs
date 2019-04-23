using System;
using System.Collections.Generic;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que me permite crear un objeto de la clase Direccion
    /// </summary>
    public class Direccion
    {
        #region
        /// <summary>
        /// idntificador de la direccion
        /// </summary>
        public int IdDireccion { get; set; }

        /// <summary>
        /// nombre de la direccion
        /// </summary>
        public string NombreDireccion { get; set; }

        /// <summary>
        /// identificador de la persona
        /// </summary>
        public List<Persona> IdPersona { get; set; }

        /// <summary>
        /// identificador del inmueble
        /// </summary>
        public Inmueble IdInmueble { get; set; }

        /// <summary>
        ///  Estado para ver si la direccion es activo,inactivo, etc.
        /// </summary>
        private byte estadoModificaion { get; set; }

        /// <summary>
        /// Fecha de modificacion de la direccion
        /// </summary>
        private DateTime fechaModificacion { get; set; }
        #endregion
    }
}
