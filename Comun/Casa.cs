namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase para crear objetos de la clase Casa
    /// </summary>
    public class Casa:InmuebleEdificado
    {
        #region
        /// <summary>
        /// propiedad para saber si tiene sotano
        /// </summary>
        public bool Sotano { get; set; }        
        /// <summary>
        /// propiedad para saber si tiene Atico
        /// </summary>
        public bool Atico { get; set; }
        #endregion
    }
}
