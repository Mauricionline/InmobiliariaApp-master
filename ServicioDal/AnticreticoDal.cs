using Base;
using System;
using System.Data.SqlClient;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.ServicioDal
{
    public class AnticreticoDal
    {
        const string NOMBRE = "Anticretico";
        const string NOMBREDAL = "AnticreticoDal";

        /// <summary>
        /// Inserta un Dapartamento a la base de datos 
        /// </summary>        
        /// <param name="Anticretico"></param>
        public static void Insertar(Anticretico anticretico)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un " + NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar Empleado
            string queryString = @"INSERT INTO Anticretico(idServicio, tiempoAnticreticoAnios) 
                                    VALUES(@idServicio, @tiempoAnticreticoAnios)";

            SqlConnection connection = OperacionesSql.ObtenerConexion();
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                ServicioDal.InsertarTransaccion(anticretico as Servicio, transaction, connection);

                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaction, connection);
                command.Parameters.AddWithValue("@idServicio", OperacionesSql.GetActIdTable("Servicio"));
                command.Parameters.AddWithValue("@tiempoAnticreticoAnios", anticretico.tiempoAnticreticoAnios);
                OperacionesSql.ExecuteBasicCommandWithTransaction(command);

                transaction.Commit();
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
            finally
            {
                connection.Close();
            }

            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} {1} Info: {2}",
                DateTime.Now.ToString(), DateTime.Now.ToString(),
                "Termino de ejecutar  el metodo acceso a datos para insertar" + NOMBRE));
        }


        /// <summary>
        /// Elimina Departamento de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un " + NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Anticretico SET estadoModificacion=1
                                    WHERE idServicio = @idServicio";

            //Declaro e inicio la conexion
            SqlConnection conexion = OperacionesSql.ObtenerConexion();

            //Declaro la transaccion
            SqlTransaction transaccion = null;
            try
            {
                conexion.Open();

                transaccion = conexion.BeginTransaction();

                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);
                command.Parameters.AddWithValue("@id", id);

                ServicioDal.EliminarPorIdServicioConTransaccion(id, transaccion, conexion);

                OperacionesSql.ExecuteBasicCommandWithTransaction(command);

                transaccion.Commit();
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
        /// Actualiza Departamento de la base de datos
        /// </summary>
        /// <param name="Anticretico"></param>
        public static void Actualizar(Anticretico anticretico)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Anticretico SET tiempoAnticreticoAnios=@tiempoAnticreticoAnios
                                    WHERE IdServicio=@IdServicio";
            try
            {

                //command = OperacionesSql.CreateBasicCommand(queryString);
                //command.Parameters.AddWithValue("@nombre", empleado.Nombres);
                //command.Parameters.AddWithValue("@tipo", empleado.TipodeTelefono);
                //command.Parameters.AddWithValue("@idTelefono", empleado.IdTelefono);
                //OperacionesSql.ExecuteBasicCommand(command);
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
        /// Obtiene un Departamento de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Anticretico Obtener(int id)
        {
            Anticretico res = new Anticretico();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT tiempoAnticreticoAnios FROM Anticretico
                            INNER JOIN inmueble ON Departmaento.IdDepartmanto = Inmueble.IdInmueble
                            WHERE idDeartamento = @id";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Anticretico()
                    {
                        tiempoAnticreticoAnios = dr.GetByte(1),

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
