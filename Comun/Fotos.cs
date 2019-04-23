using System;
using System.Collections.Generic;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    public class Fotos
    {
        /// <summary>
        /// Identidicador de la foto
        /// </summary>
        public int IdFotos { get; set; }

        /// <summary>
        /// Direccion de la foto que relaciona el inmueble
        /// </summary>
        public string direccionFotos{get;set;}

        /// <summary>
        /// Identficador del inmueble
        /// </summary>
        public List<Inmueble> IdInmueble {get;set;}

        /// <summary>
        /// Estado para saber si la foto del inmueble tiene alguna alteracion
        /// </summary>
        public byte estadoModificacion {get;set;}

        /// <summary>
        /// Fecha de modificacion de la foto
        /// </summary>
        public DateTime fechaModificacin { get; set; }
    }
}
