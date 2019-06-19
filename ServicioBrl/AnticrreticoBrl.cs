using Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.ServicioBrl
{
    class AnticrreticoBrl
    {

        const string NOMBRE = "Anticretico";
        const string NOMBREBRL = "Anticreticobrl";


        /// <summary>
        /// Metodo logica de negocio para insertar un Departmanto
        /// </summary>
        /// <param name="cuenta"></param>
        public static void Insertar(Anticretico anticretico)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para crear una " + NOMBRE));

            try
            {
                ServicioDal.ServicioDal.Insertar(anticretico);


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
        /// <param name="Departamento"></param>
        public static void Actualizar(Anticrretico anticrretico)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Actualizar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para crear un " + NOMBRE));

            try
            {
                ServicioDal.ServicioDal.Actualizar(anticretico);

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
                "Termino de ejecutar  el metodo logica de negocio para actualizar " + NOMBRE));
        }

        /// <summary>
        /// Metodo logica de negocio para eliminar un telefono
        /// </summary>
        /// <param name="Anticrewtico"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Eliminar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para Eliminar una " + NOMBRE));

            try
            {
                ServicioDal.ServicioDal.Eliminar(id);

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
                "Termino de ejecutar  el metodo logica de negocio para Eliminar " + NOMBRE));
        }

        /// <summary>
        /// Metodo logica de negocio para eliminar un telefono
        /// </summary>
        /// <param name="telefono"></param>
        public static Anticretico Obtener(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Obtener", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para Obtener un " + NOMBRE));

            try
            {
                return ServicioDal.AnticreticoDal.Obtener(id);
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
