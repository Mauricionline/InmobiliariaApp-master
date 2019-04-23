﻿namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun
{
    /// <summary>
    /// Clase que ejecuta operaciones en general
    /// </summary>
    public class Operaciones
    {
        /// <summary>
        /// Escribe en el log en modo depuración
        /// </summary>
        /// <param name="tabla">Nombre de la entidad</param>
        /// <param name="titulo">Título del mensaje</param>
        /// <param name="mensaje">Mensaje a imprimir en el log</param>
        public static void WriteLogsDebug(string tabla, string titulo, string mensaje)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0} {1} {2}", mensaje, titulo, tabla));
        }


        /// <summary>
        /// Escribe en el log en modo producción
        /// </summary>
        /// <param name="tabla">Nombre de la entidad</param>
        /// <param name="titulo">Título del mensaje</param>
        /// <param name="mensaje">Mensaje a imprimir en el log</param>
        public static void WriteLogsRelease(string tabla, string titulo, string mensaje)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("{0} {1} {2}", mensaje, titulo, tabla));
        }
    }
}
