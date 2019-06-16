using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.InmobiliariaBrl
{
    public class InmuebleBrl
    {
        const string NOMBRE = "Inmueble";
        const string NOMBREBRL = "InmuebleBrl";
        /// <summary>
        /// Metodo logica de negocio para insertar una Inmueble
        /// </summary>
        /// <param name="Inmueble"></param>
        public static void Insertar(Inmueble inmueble)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para crear una " + NOMBRE));

            try
            {
                InmobiliariaDal.InmuebleDal.Insertar(inmueble);

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
        /// Metodo logica de negocio para actulizar un Persona
        /// </summary>
        /// <param name="Inmueble"></param>
        public static void Actualizar(Inmueble inmueble)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Actualizar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para crear un " + NOMBRE));

            try
            {
                InmobiliariaDal.InmuebleDal.Actualizar(inmueble);
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
        /// Metodo logica de negocio para eliminar un Persona
        /// </summary>
        /// <param name="Inmueble"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Eliminar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para Eliminar un " + NOMBRE));

            try
            {
                InmobiliariaDal.InmuebleDal.Eliminar(id);
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
        /// Metodo logica de negocio para eliminar un Persona
        /// </summary>
        /// <param name="Inmueble"></param>
        public static Inmueble Obtener(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREBRL, "Obtener", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(),
            "Empezando a ejecutar el metodo logica de negocio para Obtener " + NOMBRE));

            try
            {
                return InmobiliariaDal.InmuebleDal.Obtener(id);
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



