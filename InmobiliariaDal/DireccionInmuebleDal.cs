using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.InmobiliariaDal
{
    public class DireccionInmuebleDal
    {

        ///IMPORTANTE DEBO VERIFICAR SI LAS CONSULTAS ESTAN BIEN POR QUE YA NO ES DIRECCION AHORA ES DIRECCIONPERSONA
        const string NOMBRE = "DireccionInmueble";
        const string NOMBREDAL = "DireccionInmuebleDal";
        /// <summary>
        /// Inserta un telefono a la base de datos 
        /// </summary>
        /// <param name="direccionInmueble"></param>        
        public static void Insertar(DireccionInmueble direccionInmueble)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear una " + NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar Direccion
            string queryString = @"INSERT INTO DireccionInmueble(nombreDireccion, IdInmueble, estadoModificacion) 
                                    VALUES(@nombreDireccion, @IdInmueble, @estadoModificacion)";
            // Declaro e inicio la conexion
            SqlConnection conexion = OperacionesSql.ObtenerConexion();

            //    Declaro la transaccion
              SqlTransaction transaccion = null;
            try
            {
                //   Abro la conexion a la base de datos
                conexion.Open();

                //        Inicio la transaccion
                transaccion = conexion.BeginTransaction();
                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);
                if (direccionInmueble.Inmueble != null)
                {
                    InmuebleDal.InsertarTransaccion(direccionInmueble.Inmueble, transaccion, conexion);
                    command.Parameters.AddWithValue("@IdInmueble", direccionInmueble.Inmueble.IdInmueble);
                }
                else
                {
                    command.Parameters.AddWithValue("@IdInmueble", null);
                }

                command.Parameters.AddWithValue("@nombreDireccion", direccionInmueble.NombreDireccion);
                command.Parameters.AddWithValue("@idInmueble", direccionInmueble.IdInmueble.idInmueble);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                OperacionesSql.ExecuteBasicCommandWithTransaction(command);
        //        Insertar telefonos
        ////        foreach (Telefono telf in persona.Telefonos)
        ////        {
        ////            TelefonoDal.InsertarConTransaccion(telf, transaccion, conexion);
        ////        }
        ////        transaccion.Commit();
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "DireccionInmuebleDal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "DireccionInmuebleDal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} {1} Info: {2}",
                DateTime.Now.ToString(), DateTime.Now.ToString(),
                "Termino de ejecutar  el metodo acceso a datos para insertar " + NOMBRE));
        }

        ///// <summary>
        ///// Inserta una DireccionInueble a la base de datos 
        ///// </summary>
        ///// <param name="persona"></param>
        public static void InsertarConTransaccion(Persona persona, SqlTransaction transaccion, SqlConnection conexion)
        {
            Operaciones.WriteLogsDebug("DireccionInmuebleDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un DireccionInmueble"));
            SqlCommand command = null;
            //Consulta para insertar DireccionInmueble
            string queryString = @"INSERT INTO DireccionInmueble(nombreDireccion, IdInmueble, estadoModificacion) 
                                    VALUES(@nombreDireccion, @IdInmueble, @estadoModificacion)";


            try
            {
                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);
                if (direccionInmueble.Inmueble != null)
                {
                    InmuebleDal.InsertarTransaccion(direccionInmueble.Inmueble, transaccion, conexion);
                    command.Parameters.AddWithValue("@IdInmueble", direccionInmueble.Inmueble.IdInmueble);
                }
                else
                {
                    command.Parameters.AddWithValue("@IdInmueble", null);
                }

                command.Parameters.AddWithValue("@nombreDireccion", direccionInmueble.NombreDireccion);
                command.Parameters.AddWithValue("@idInmueble", direccionInmueble.IdInmueble.idInmueble);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                OperacionesSql.ExecuteBasicCommandWithTransaction(command);
                //        Insertar telefonos
                ////        foreach (Telefono telf in persona.Telefonos)
                ////        {
                ////            TelefonoDal.InsertarConTransaccion(telf, transaccion, conexion);
                ////        }
                ////        transaccion.Commit();
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "DireccionInmuebleDal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "DireccionInmuebleDal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} {1} Info: {2}",
                DateTime.Now.ToString(), DateTime.Now.ToString(),
                "Termino de ejecutar  el metodo acceso a datos para insertar " + NOMBRE));
        }
 



        /// <summary>
        /// Elimina Direccion de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar una " + NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE DireccionPersona SET estadoModificacion=1
                                    WHERE idInmueble = @idInmueble";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idInmueble", id);
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

            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar una" + NOMBRE));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name = "IdInmueble" ></ param >
        public static void EliminarPorIdDireccionInmuebleTransaccion(int IdInmueble, SqlTransaction transaccion, SqlConnection conexion)
        {
            Operaciones.WriteLogsDebug("InmuebleDal", "EliminarPorIdInmeble", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Usuario"));
            SqlCommand command = null;
            string queryString = @"UPDATE DireccionPersona SET estadoModificacion=1
                                    WHERE idInmueble =  (Select IdInmueble FROM DireccionInmueble WHERE IdInmueble = @IdInmueble)";

            try
            {
                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);
                command.Parameters.AddWithValue("@IdInmueble", IdInmueble);
                OperacionesSql.ExecuteBasicCommandWithTransaction(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease("InmuebleDal", "EliminarPorIdInmeble", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("InmuebleDal", "EliminarPorIdInmeble", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug("InmuebleDal", "EliminarPorIdInmeble", string.Format("{0} {1} Info: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));
        }



        /// <summary>
        /// Actualiza telefono de la base de datos
        /// </summary>
        /// <param name="telefono"></param>
        public static void Actualizar(DireccionInmueble direccionInmueble)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar una" + NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE DireccionInmueble SET nombreDireccion=@nombreDireccion
                                    WHERE idDireccion = @idDireccion";
            try
            {

                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombreDireccion", direccionInmueble.NombreDireccion);
                command.Parameters.AddWithValue("@idDireccion", direccionInmueble.IdDireccion);
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

            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar una " + NOMBRE));

        }



        /// <summary>
        /// Obtiene un Persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DireccionInmueble Obtener(int id)
        {
            DireccionInmueble direccionInmueble = new DireccionInmueble();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM DireccionInmueble WHERE IdInmueble=@id and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    DireccionInmueble = new DireccionInmueble()
                    {
                        IdInmueble = dr.GetInt32(0),
                        Inmueble = InmuebleDal.Obtener(dr.GetInt32(2)),
                        estadoModificacion = dr.GetBoolean()
                    };

                }
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("DireccionInmuebleDal", "Obtenet(Get)", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return persona;
        }

       
    }
}

