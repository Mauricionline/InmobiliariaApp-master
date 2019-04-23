using System;
namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    public class Transaccion
    { 
        /// <summary>
        /// Prosentage que recive la imnoviliaria por un servicio
        /// </summary>
        public decimal comision { get; set; }
        /// <summary>
        /// Monto de ganacias de la comision
        /// </summary>
        public decimal monto { get; set; }
        /// <summary
        /// Fecha de la transaccion
        /// </summary>
        public DateTime fechahora { get; set; }
        /// <summary>
        /// clave que une con la clase empleado
        /// </summary>
        public Empleado Idempleado { get; set; }
        /// <summary>
        /// clave que une con la calse inmueble
        /// </summary>
        public Inmueble idInmueble { get; set; }
        /// <summary>
        /// clave que une con la clase Servicio
        /// </summary>
        public Servicio IdServicio { get; set; }
        /// <summary>
        /// Estado de la transaccion para saver si sufre cambios
        /// </summary>
        public int estadoModificacion { get; set; }
        /// <summary>
        /// Fecha de la alteracion de la tabla
        /// </summary>
        public DateTime fechaModificacion { get; set; }
    }
}
