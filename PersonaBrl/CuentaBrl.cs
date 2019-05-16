using System;
using System.Data.SqlClient;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.PersonaBrl
{
    public class CuentaBrl
    {
        const string NOMBRE = "Cuenta";
        const string NOMBREBRL = "CuentaBrl";
        /// <summary>
        /// Metodo logica de negocio para insertar un telefono
        /// </summary>
        /// <param name="cuenta"></param>
        public static void Insertar(Cuenta cuenta)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para crear una "+NOMBRE));

            try
            {
                EmpleadoDal.CuentaDal.Insertar(cuenta);

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
                "Termino de ejecutar  el metodo logica de negocio para insertar " + NOMBRE));

        }

        /// <summary>
        /// Metodo logica de negocio para actulizar un Cuenta
        /// </summary>
        /// <param name="Cuenta"></param>
        public static void Actualizar(Cuenta cuenta)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Actualizar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para crear un "+ NOMBRE));

            try
            {
                EmpleadoDal.CuentaDal.Actualizar(cuenta);
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
        /// Metodo logica de negocio para eliminar un telefono
        /// </summary>
        /// <param name="Cuenta"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Eliminar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para Eliminar una "+NOMBRE));

            try
            {
                EmpleadoDal.CuentaDal.Eliminar(id);
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
        /// Metodo logica de negocio para eliminar un telefono
        /// </summary>
        /// <param name="telefono"></param>
        public static Cuenta Obtener(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Obtener", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para Obtener un "+NOMBRE));

            try
            {
                return EmpleadoDal.CuentaDal.Obtener(id);
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


        public static int verificar_cuenta(Cuenta cuenta)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "verificar_existe", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para verificar si una cuenta existe"));

            try
            {
                return EmpleadoDal.CuentaDal.verificar_cuenta(cuenta);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "verificar_existe", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREBRL, "verificar_existe", string.Format("{0} {1} Error: {2}",
                    DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }
    }
}
