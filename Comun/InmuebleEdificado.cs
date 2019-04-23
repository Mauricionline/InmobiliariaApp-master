using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que me sirve para crear objetos InmuebleEdificado
    /// </summary>
    public class InmuebleEdificado :Inmueble
    {
        #region
        /// <summary>
        /// metros construidos del inmueble
        /// </summary>
        public int MtsConstruidos { get; set; }
        /// <summary>
        /// Expensas puede ser nulo en caso de que no se necesite
        /// </summary>
        public decimal Expensas { get; set; }
        /// <summary>
        /// año de contruccion
        /// </summary>
        public int AnoConstruccion { get; set; }
        /// <summary>
        /// cantidad de garajes puede ser nulo en caso de que no tenga garaje
        /// </summary>
        public byte Garaje  { get; set; }
        /// <summary>
        /// cantidad de dormitorios puede ser nulo en caso de que no tenga dormitorios
        /// </summary>
        public byte Dormitorios { get; set; }
        /// <summary>
        /// cantidad de baños puede ser nulo en caso de que no se necesite
        /// </summary>
        public byte Banos { get; set; }
        /// <summary>
        /// cantidad de pisos
        /// </summary>
        public byte CantidadPisos { get; set; }
        #endregion
    }
}
