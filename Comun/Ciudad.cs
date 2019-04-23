using System;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    public class Ciudad
    {
        /// <summary>
        /// Identificador de la Ciudad.
        /// </summary>
        public int idCiudad { get; set; }
        /// <summary>
        /// Nombre de la ciudad.
        /// </summary>
        public string nombreCiudad { get; set; }
        /// <summary>
        ///  Estado para ver si alguna ciudad tiene modificaciones.
        /// </summary>
        public byte estadoModificaion { get; set; }
        /// <summary>
        /// Fecha de modificacion de la Ciudad.
        /// </summary>
        public DateTime fechaModificacion { get; set; }
    }
}
