namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// clase para crear objetos de la clase departamento
    /// </summary>
    public class Departamento
    {
        #region
        /// <summary>
        /// numero de piso en el que se encuentra el departamento
        /// </summary>
        public byte NumPiso { get; set; }
        /// <summary>
        /// propiedad para saber si en el departamento tiene ascensor
        /// </summary>
        public bool Ascensor { get; set; }
        /// <summary>
        /// numero de departamentos por piso
        /// </summary>
        public byte DepartamentoPorPiso { get; set; }
        #endregion
    }
}
