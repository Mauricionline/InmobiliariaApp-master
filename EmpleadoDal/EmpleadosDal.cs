using System;
using System.Data.SqlClient;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.EmpleadoDal
{
    public class EmpleadosDal
    {
        const string NOMBRE = "Empleado";
        const string NOMBREDAL = "EmpleadoDal";

        /// <summary>
        /// Inserta un Empleado a la base de datos 
        /// </summary>        
        /// <param name="Empleado"></param>
        public static void Insertar(Empleado empleado, Telefono telefono, Cuenta cuenta, DireccionPersona direccionPersona, Email email)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un "+NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar Empleado
            string queryString = @"INSERT INTO Empleado(idEmpleado, sueldo) 
                                    VALUES(@idEmpleado, @sueldo)";

            SqlConnection connection = OperacionesSql.ObtenerConexion();
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                PersonaDal.InsertarConTransaccion(empleado as Persona, telefono, cuenta, direccionPersona, email, transaction, connection);

                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaction, connection);

                command.Parameters.AddWithValue("@idEmpleado", OperacionesSql.GetActIdTable("Persona"));
                command.Parameters.AddWithValue("@sueldo", empleado.Sueldo);
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
                "Termino de ejecutar  el metodo acceso a datos para insertar"+ NOMBRE));
        }
       

        /// <summary>
        /// Elimina telefono de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un "+NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Telefono SET estadoModificacion=1
                                    WHERE idTelefono = @idTelefono";

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

                PersonaDal.EliminarConTransaccion(id, transaccion, conexion);

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
        /// Actualiza telefono de la base de datos
        /// </summary>
        /// <param name="telefono"></param>
        public static void Actualizar(Empleado empleado)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Telefono SET numeroTelefono=@numero, tipoTelefono=@tipo
                                    WHERE idTelefono=@idTelefono";
            try
            {

                command = OperacionesSql.CreateBasicCommand(queryString);
                //command.Parameters.AddWithValue("@nombre", empleado.Nombres);
                //command.Parameters.AddWithValue("@tipo", empleado.TipodeTelefono);
                //command.Parameters.AddWithValue("@idTelefono", empleado.IdTelefono);
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
        /// Obtiene un Empleado de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Empleado Obtener(int id)
        {
            Empleado res = new Empleado();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT nombres, primerApellido, segundoApellido, cargo, sueldo FROM Empleado
                            INNER JOIN Persona ON Empleado.idEmpleado = Persona.idPersona
                            WHERE idEmpleado = @id";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Empleado()
                    {                        
                        Nombres = dr.GetString(0),
                        PrimerApellido = dr.GetString(1),
                        SegundoApellido = dr.GetString(2), 
                        Cargo = dr.GetByte(3),
                        Sueldo = dr.GetDecimal(4)
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
