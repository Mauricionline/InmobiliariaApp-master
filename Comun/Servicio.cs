using System;
namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    public class Servicio
    {
        /// <summary>
        /// Identificador del servicio
        /// </summary>
        public int idServicio { get; set; }
        /// <summary>
        /// El tipo especifico de servicio
        /// </summary>
        public byte tipoServicio { get; set; }
        /// <summary>
        /// Percio del Servicio
        /// </summary>
        public decimal precioEstimadoServicio { get; set; }
        /// <summary>
        /// Estado del servicio, para ver si tiene alguna modificacion
        /// </summary>
        public byte estadoModificacion {get; set;}
        /// <summary>
        /// Fecha de modificacion del Servico
        /// </summary>
        public DateTime fechaModificacion { get; set; }
    }
}
