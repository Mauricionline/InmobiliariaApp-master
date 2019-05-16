using System;
using System.Data.SqlClient;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.PersonaBrl
{
    public class PersonaBrl
    {
        const string NOMBRE = "Persona";
        const string NOMBREBRL = "PersonaBrl";
        /// <summary>
        /// Metodo logica de negocio para insertar una Persona
        /// </summary>
        /// <param name="Persona"></param>
        public static void Insertar(Persona persona)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para crear una "+NOMBRE));

            try
            {
                EmpleadoDal.PersonaDal.Insertar(persona);

            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "Insertar", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "Insertar", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREBRL, "Insertar", string.Format("{0} {1} Info: {2}",
                DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                "Termino de ejecutar  el metodo logica de negocio para insertar "+NOMBRE));

        }

        /// <summary>
        /// Metodo logica de negocio para actulizar un Persona
        /// </summary>
        /// <param name="Persona"></param>
        public static void Actualizar(Persona persona)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Actualizar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para crear un "+NOMBRE));

            try
            {
                EmpleadoDal.PersonaDal.Actualizar(persona);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "Actualizar", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "Actualizar", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREBRL, "Actualizar", string.Format("{0} {1} Info: {2}",
                DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                "Termino de ejecutar  el metodo logica de negocio para actualizar "+NOMBRE));
        }

        /// <summary>
        /// Metodo logica de negocio para eliminar un Persona
        /// </summary>
        /// <param name="Persona"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Eliminar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para Eliminar un "+NOMBRE));

            try
            {
                EmpleadoDal.PersonaDal.Eliminar(id);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "Eliminar", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "Eliminar", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREBRL, "Eliminar", string.Format("{0} {1} Info: {2}",
                DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                "Termino de ejecutar  el metodo logica de negocio para Eliminar "+NOMBRE));
        }

        /// <summary>
        /// Metodo logica de negocio para eliminar un Persona
        /// </summary>
        /// <param name="Persona"></param>
        public static Persona Obtener(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Obtener", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para Obtener "+NOMBRE));

            try
            {
                return EmpleadoDal.PersonaDal.Obtener(id);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "Obtener", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "Obtener", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }
    }
}
