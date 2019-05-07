using System;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que me permite heredar los atributos de una direccion
    /// Esta clase no se puede crear por que es abstracta
    /// </summary>
    public abstract class Direccion
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
        ///  Estado para ver si la direccion es activo,inactivo, etc.
        /// </summary>
        public byte estadoModificaion { get; set; }

        /// <summary>
        /// Fecha de modificacion de la direccion
        /// </summary>
        public DateTime fechaModificacion { get; set; }
        #endregion
    }
}
