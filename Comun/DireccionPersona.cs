namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que me permite crear objetos de la clase direccionPersona
    /// </summary>
    public class DireccionPersona : Direccion
    {
        #region
        /// <summary>
        /// id de la persona a la cual pertenece la direccion
        /// </summary>
        public int IdPersona { get; set; }

        #endregion
    }
}
