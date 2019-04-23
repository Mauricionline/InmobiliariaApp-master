using System;
namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    public class Inmueble
    {
        ///<summary>
        ///Identidicador del inmueble
        /// </summary>
        public int idInmueble {get;set;}
        /// <summary>
        /// Direccion del inmueble
        /// </summary>
        public Direccion idDireccion{get;set;}
        /// <summary>
        /// estado del inmueble vendido alquilado etc
        /// </summary>
        public byte estado{get;set;}
        /// <summary>
        /// Zona del inmueble
        /// </summary>
        public string zona{get;set;}
        /// <summary>
        /// identificador de la ciudad donde se encuntra el inmueble
        /// </summary>
        public Ciudad idCiudad {get;set;}
        /// <summary>
        /// La superficie especificada por el dueño del inmueble
        /// </summary>
        public string superficieSprox{get;set;}
        /// <summary>
        /// Saber si un inmueble esta activo o inactivo,etc. 
        /// </summary>
        public byte estadoModificacion{get;set;}
        /// <summary>
        /// Fecha de modificacion de inmueble
        /// </summary>
        public DateTime fechaModificacion{get;set;}
    }
}
