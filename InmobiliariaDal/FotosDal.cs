using System;
using System.Data.SqlClient;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;
namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.FotosDal
{
    public class FotosDal
    {
        const string NOMBRE = "Fotos";
        const string NOMBREDAL = "FotosDal";
        /// <summary>
        /// Inserta una Empleado a la base de datos 
        /// </summary>
        /// <param name="Foto"></param>
        public static void Insertar(Fotos fotos)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un empleado"));

            SqlCommand command = null;

            //Consulta para insertar empleados
            string queryString = @"INSERT INTO Fotos(IdFotos, direccionFotos, IdInmueble,estadoModificacion) 
                                    VALUES(@IdFotos, @direccionFotos, @IdInmueble,@estadoModificacion)";
            //Declaro e inicio la conexion
            SqlConnection conexion = OperacionesSql.ObtenerConexion();

            //Declaro la transaccion
            SqlTransaction transaccion = null;
            try
            {
                //Abro la conexion a la base de datos
                conexion.Open();

                //Inicio la transaccion
                transaccion = conexion.BeginTransaction();

                //Inserto a la persona
                InmuebleDal.InsertarTransaccion(fotos as Inmueble, transaccion, conexion);

                //Inserto al empleado
                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);
                command.Parameters.AddWithValue("@IdFotos", fotos.IdInmueble);
                command.Parameters.AddWithValue("@direccionFotos", fotos.direccionFotos);
                command.Parameters.AddWithValue("@IdInmueble", Inmueble.IdInmueble);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                OperacionesSql.ExecuteBasicCommandWithTransaction(command);

                transaccion.Commit();

            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Insertar", string.Format("{0} Error: {1} ",
                    DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Insertar", string.Format("{0} Error: {1}",
                    DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
                DateTime.Now.ToString(),
                "Termino de ejecutar  el metodo acceso a datos para insertar empleado"));
        }

        /// <summary>
        /// Metodo para obtener  un empleado
        /// </summary>
        /// <param name="id">Identificado del empleado </param>
        /// <returns>Empleado</returns>
        public static Empleado Obtener(int id)
        {
            Empleado empleado = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT IdInmueble,direccionFotos, estadoModificacion FROM Fotos WHERE IdInmueble=@id and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                fotos = DireccionInmueble.ObtenerFoto(id);
                while (dr.Read())
                {
                    IdFotos = dr.GetInt(0);
                    Inmueble = InmuebleDal.Obtener(dr.GetInt32(1));
                     estadoModificacion = dr.GetBoolean(2);
                }

            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Obtenet", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Obtenet", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return empleado;
        }

        /// <summary>
        /// Método para actulizar a un empleado
        /// </summary>
        /// <param name="empleado"></param>
        public static void Actualizar(Fotos fotos)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Persona"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Fotos SET direccionFotos=@direccionFotos
                                    WHERE IdInmueble=@IdInmueble";
            try
            {

                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@direccionFotos", fotos.direccionFotos);
                command.Parameters.AddWithValue("@IdInmueble", fotos.IdInmueble);

                //Actualizo a la persona
                PersonaDal.Actualizar(empleado as Persona);

                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREDAL, "Actualizar", string.Format("{0}  Info: {1}", DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));

        }

        /// <summary>
        /// Método para eliminar a un empleado
        /// </summary>
        /// <param name="foto"></param>
        public static void Eliminar(int IdFoto)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Persona"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Fotos SET estadoModificacion=1
                                    WHERE IdInmueble=@id";
            //Declaro e inicio la conexion
            SqlConnection conexion = OperacionesSql.ObtenerConexion();

            //Declaro la transaccion
            SqlTransaction transaccion = null;
            try
            {
                //Abro la conexion a la base de datos
                conexion.Open();

                //Inicio la transaccion
                transaccion = conexion.BeginTransaction();

                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);
                command.Parameters.AddWithValue("@id", idEmpleado);

                //Elimino a la persona
                PersonaDal.EliminarConTransaccion(IdFoto, transaccion, conexion);

                OperacionesSql.ExecuteBasicCommandWithTransaction(command);

                transaccion.Commit();
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREDAL, "Actualizar", string.Format("{0}  Info: {1}", DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));

        }

    }
}

