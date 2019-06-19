using System;
using System.Data.SqlClient;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.ServicioDal
{
    public class ServicioDal
    {

        const string NOMBRE = "Servicio";
        const string NOMBREDAL = "ServicioDal";
        /// <summary>
        /// Inserta un telefono a la base de datos 
        /// </summary>       
        /// <param name="idServicio"></param>

        public static void Insertar(Servicio servicio)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear una " + NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar inmuebles
            string queryString = @"INSERT INTO Servicio(tipoServicio, precioEstimadoServicio, estadoModificacion) 
                                    VALUES(@tipoServicio, @precioEstimadoServicio, @estadoModificacion)";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@tipoServicio", servicio.tipoServicio);
                command.Parameters.AddWithValue("@precioEstimadoServicio", servicio.precioEstimadoServicio);
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
        /// Inserta un usaurio a la base de datos con transaccion
        /// </summary>
        /// <param name="Servicio">Objeto usuario </param>
        /// <param name="transaccion">Objeto transaccion</param>
        /// <param name="conexion">Objeto conexion</param>
        public static void InsertarTransaccion(Servicio servicio, SqlTransaction transaccion, SqlConnection conexion)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "InsertarTransaccion", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un usuario"));

            SqlCommand command = null;

            //Consulta para insertar Inmuebles
            string queryString = @"INSERT INTO Servicio(tipoServicio, precioEstimadoServicio, estadoModificacion) 
                                    VALUES(@tipoServicio, @precioEstimadoServicio, @estadoModificacion)";
            try
            {
                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);
                command.Parameters.AddWithValue("@tipoServicio", servicio.tipoServicio);
                command.Parameters.AddWithValue("@precioEstimadoServicio", servicio.precioEstimadoServicio);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                OperacionesSql.ExecuteBasicCommandWithTransaction(command);


            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "InsertarTransaccion", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "InsertarTransaccion", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREDAL, "InsertarTransaccion", string.Format("{0} {1} Info: {1}",
                DateTime.Now.ToString(), DateTime.Now.ToString(),
                "Termino de ejecutar  el metodo acceso a datos para insertar"+NOMBRE));
        }

        /// <summary>
        /// Inserta un Email a la base de datos y devuelve el ID, aparte me devuelve el comando
        /// </summary>
        /// <param name=Servicio></param>        
        public static SqlCommand InsertarOUTPUT(Servicio servicio)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un " + NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar Servicio
            string queryString = @"INSERT INTO Servicio(tipoServicio, precioEstimadoServicio, estadoModificacion) 
                                    VALUES(@tipoServicio, @precioEstimadoServicio, @estadoModificacion)";
            command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@tipoServicio", servicio.tipoServicio);
            command.Parameters.AddWithValue("@precioEstimadoServicio", servicio.precioEstimadoServicio);
            command.Parameters.AddWithValue("@estadoModificacion", 0);
            return command;

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
            string queryString = @"UPDATE Servicio SET estadoModificacion = 1
                                    WHERE IdServicio = @idServicio";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idServicio", id);
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
        /// 
        /// </summary>
        /// <param name="idServicio"></param>
        public static void EliminarPorIdServicioConTransaccion(int idServicio, SqlTransaction transaccion, SqlConnection conexion)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "EliminarPoridServicio", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Usuario"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Servicio SET estadoModificacion=1
                                    WHERE idServicio = (Select idServicio FROM idServicio WHERE idServicio = @idServicio)";
            try
            {
                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);
                command.Parameters.AddWithValue("@idServicio", idServicio);
                OperacionesSql.ExecuteBasicCommandWithTransaction(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "EliminarPoridServicio", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "EliminarPoridServicio", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREDAL, "EliminarPoridServicio", string.Format("{0} {1} Info: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));
        }


        /// <summary>
        /// Actualiza Persona de la base de datos
        /// </summary>
        /// <param name="Servicio"></param>
        public static void Actualizar(Servicio servicio)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un " + NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Servicio 
                                   SET tipoServicio=@tipoServicio, precioEstimadoServicio=@precioEstimadoServicio, estadoModificacion = 0
                                   WHERE IdServicio=@idServicio";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@tipoServicio", servicio.tipoServicio);
                command.Parameters.AddWithValue("@precioEstimadoServicio", servicio.precioEstimadoServicio);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                command.Parameters.AddWithValue("@IdServicio", servicio.idServicio);
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
        /// <param name="idServicio"></param>
        /// <returns></returns>
        public static Servicio Obtener(int idServicio)
        {
            Servicio res = new Servicio();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Servicio WHERE idServicio=@idServicio and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idServicio", idServicio);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Servicio()
                    {
                        idServicio = dr.GetInt32(0),
                        tipoServicio = dr.GetByte(1),
                        precioEstimadoServicio = dr.GetDecimal(2),
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

        public void buscar_servicio(int idServicio)
        {
            Servicio res = new Servicio();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Servicio WHERE idServicio=@idServicio and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idServicio", idServicio);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Servicio()
                    {
                        idServicio = dr.GetInt32(0),
                        tipoServicio = dr.GetByte(1),
                        precioEstimadoServicio = dr.GetDecimal(2),
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
