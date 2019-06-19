using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.InmobiliariaDal
{
    public class DepartamentoDal
    {
        const string NOMBRE = "Departamento";
        const string NOMBREDAL = "DepartamentoDal";

        /// <summary>
        /// Inserta un Dapartamento a la base de datos 
        /// </summary>        
        /// <param name="Departamento"></param>
        public static void Insertar(Departamento departamento)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un " + NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar Empleado
            string queryString = @"INSERT INTO Departamento(IdInmueble, NumPiso,Ascensor,DepartamentoPorPiso) 
                                    VALUES(@IdInmueble, @NumPiso,@Ascensor,@DepartamentoPorPiso.)";

            SqlConnection connection = OperacionesSql.ObtenerConexion();
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                InmobiliariaDal.InsertarConTransaccion(empleado as Inmueble, transaction, connection);

                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaction, connection);
                command.Parameters.AddWithValue("@IdInmueble", OperacionesSql.GetActIdTable("Inmueble"));
                command.Parameters.AddWithValue("@NumPiso", departamento.Numpiso);
                command.Parameters.AddWithValue("@Ascensor", departamento.Ascensor);
                command.Parameters.AddWithValue("@DepartamentoPorPiso", departamento.DepartamentoPorPiso);

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
            string queryString = @"UPDATE Departamento SET estadoModificacion=1
                                    WHERE IdInmueble = @IdInmueble";

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
        /// Actualiza Departamento de la base de datos
        /// </summary>
        /// <param name="Departamento"></param>
        public static void Actualizar(Departamento departamento)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Departmanto SET NumPiso=@NumPiso, Ascensor=@Ascensor, DepartamentoPorPiso=@DepartamentoPorPiso
                                    WHERE idTelefono=@idTelefono";
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
        public static Departamento Obtener(int id)
        {
            Departmanrto res = new Departmanrto();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT NumPiso, Ascensor, DepartamentoPorPiso FROM Departmaento
                            INNER JOIN inmueble ON Departmaento.IdDepartmanto = Inmueble.IdInmueble
                            WHERE idDeartamento = @id";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Departmanrto()
                    {
                        NumPiso = dr.GetByte(0),
                        Ascensor = dr.GetBool(1),
                        DepartamentoPorPiso = dr.GetByte(2)
                        
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

