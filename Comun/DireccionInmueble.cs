using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    public class DireccionInmueble : Direccion
    {
        /// <summary>
        /// id del Inmueble a la cual pertenece la direccion
        /// </summary>
        public Inmueble IdInmueble { get; set; }
    }
}

