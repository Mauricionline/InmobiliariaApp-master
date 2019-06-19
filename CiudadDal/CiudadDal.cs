using System;
using System.Data.SqlClient;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.CiudadDal
{
    public class CiudadDal
    {
        const string NOMBRE = "Ciudad";
        const string NOMBREDAL = "CiudadDal";
        /// <summary>
        /// Inserta un telefono a la base de datos 
        /// </summary>       
        /// <param name="idFoto"></param>

        public static void Insertar(Ciudad ciudad)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear una " + NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar Ciudades
            string queryString = @"INSERT INTO Ciudad(nombreCiudad, estadoModificacion) 
                                    VALUES(@nombreCiudad, @estadoModificacion)";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombreCiudad",ciudad.nombreCiudad);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} {1} Info: {2}",
                DateTime.Now.ToString(), DateTime.Now.ToString(),
                "Termino de ejecutar  el metodo acceso a datos para insertar " + NOMBRE));
        }
        /// <summary>
        /// Elimina Persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un " + NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Ciudad SET estadoModificacion = 1
                                    WHERE idCiudad = @idCiudad";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idCiudad", id);
                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un " + NOMBRE));
        }

        /// <summary>
        /// Actualiza Persona de la base de datos
        /// </summary>
        /// <param name="Ciudad"></param>
        public static void Actualizar(Ciudad ciudad)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un " + NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Inmueble 
                                   SET  nombreCiudad=@nombreCiudad, estadoModificacion = 0
                                   WHERE idCiudad = @idCiudad";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombreCiudad", ciudad.nombreCiudad);
                command.Parameters.AddWithValue("@idCiudad", ciudad.idCiudad);
                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREDAL, "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un " + NOMBREDAL));

        }

        /// <summary>
        /// Obtiene una Persona de la base de datos
        /// </summary>
        /// <param name="idCiudad"></param>
        /// <returns></returns>
        public static Ciudad Obtener(int idCiudad)
        {
            Ciudad res = new Ciudad();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Ciuadad WHERE idCiudad=@idCiudad and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idCiudad", idCiudad);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Ciudad()
                    {
                        idCiudad = dr.GetInt32(0),
                        
                    };
                }
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Obtenet(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }

        public void buscar_ciudad(int idCiudad)
        {
            Ciudad res = new Ciudad();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Ciudad WHERE WHERE idCiudad=@idCiudad and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@IdInmueble", IdInmueble);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Ciudad()
                    {
                        idCiudad = dr.GetInt32(0),
                        
                    };
                }
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Obtenet(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

        }
    }

}

