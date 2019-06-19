using System;
using System.Data.SqlClient;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.InmobiliariaDal
{
    public class CasaDal
    {

            const string NOMBRE = "Casa";
            const string NOMBREDAL = "CasaDal";

            /// <summary>
            /// Inserta un telefono a la base de datos 
            /// </summary>
            /// <param name="casa"></param>
            /// <param name="IdInmueble"></param>
            public static void Insertar(Casa casa)
            {
                Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
                DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un telefono"));

                SqlCommand command = null;

                //Consulta para insertar telefonos
                string queryString = @"INSERT INTO Casa(Sotano, Atico, idInmueble) 
                                    VALUES(@sotano, @atico, @IdInmueble)";
                try
                {
                    command = OperacionesSql.CreateBasicCommand(queryString);
                    command.Parameters.AddWithValue("@sotano", casa.Sotano);
                    command.Parameters.AddWithValue("@atico", casa.Atico);
                    command.Parameters.AddWithValue("@IdInmueble", casa.IdInmueble.IdInmueble);
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
                    "Termino de ejecutar  el metodo acceso a datos para insertar una casa"));
            }

        /// <summary>
        /// Inserta un telefono a la base de datos y devuelve el ID, aparte me devuelve el comando
        /// </summary>
        /// <param name="casa"></param>
        /// <param name="IdInmueble"></param>
        public static SqlCommand InsertarOUTPUT(Casa casa)
            {
                Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
                DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un"));

                SqlCommand command = null;

                //Consulta para insertar telefonos
                string queryString = @"INSERT INTO Casa(Sotano, Atico, idInmueble) 
                                    VALUES(@sotano, @atico, @IdInmueble)";

                command = new SqlCommand(queryString);
                command.Parameters.AddWithValue("@sotano", casa.Sotano);
                command.Parameters.AddWithValue("@atico", casa.Atico);
                command.Parameters.AddWithValue("@IdInmueble", casa.IdInmueble.IdInmueble);
                return command;

            }

            /// <summary>
            /// Elimina Casa de la base de datos
            /// </summary>
            /// <param name="id"></param>
            public static void Eliminar(int id)
            {
                Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

                SqlCommand command = null;

                // Proporcionar la cadena de consulta 
                string queryString = @"UPDATE Casa SET estadoModificacion=1
                                    WHERE IdInmueble = @IdInmueble";
                try
                {
                    command = OperacionesSql.CreateBasicCommand(queryString);
                    command.Parameters.AddWithValue("@IdInmueble", id);
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

                Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));
            }

            /// <summary>
            /// Actualiza Casa de la base de datos
            /// </summary>
            /// <param name="casa"></param>
            public static void Actualizar(Casa casa)
            {
                Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

                SqlCommand command = null;

                // Proporcionar la cadena de consulta 
                string queryString = @"UPDATE Casa SET Sotano=@sotano, Atico=@atico
                                    WHERE IdInmueble=@IdInmueble";
                try
                {

                    command = OperacionesSql.CreateBasicCommand(queryString);
                    command.Parameters.AddWithValue("@sotano", casa.Sotano);
                    command.Parameters.AddWithValue("@atico", casa.Atico);
                    command.Parameters.AddWithValue("@IdInmueble", casa.IdInmueble);
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

                Operaciones.WriteLogsDebug("TelefonoDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));

            }

            /// <summary>
            /// Obtiene un Telefono de la base de datos
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public static Casa Obtener(int id)
            {
                Casa res = new Casa();
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                string query = @"SELECT * FROM Casa WHERE IdInmueble=@id and estadoModificacion=0";
                try
                {
                    cmd = OperacionesSql.CreateBasicCommand(query);
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                    while (dr.Read())
                    {
                        res = new Casa()
                        {
                            IdInmueble = dr.GetInt16(0),
                            Sotano = dr.Bool(1),
                            Atico = dr.Bool(2),
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
        }
    }
}
