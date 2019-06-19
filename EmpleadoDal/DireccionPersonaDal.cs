using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.EmpleadoDal
{
    public class DireccionPersonaDal
    {   
        ///IMPORTANTE DEBO VERIFICAR SI LAS CONSULTAS ESTAN BIEN POR QUE YA NO ES DIRECCION AHORA ES DIRECCIONPERSONA
        const string NOMBRE = "Direccion";
        const string NOMBREDAL = "DireccionDal";
        /// <summary>
        /// Inserta un telefono a la base de datos 
        /// </summary>
        /// <param name="direccionPersona"></param>        
        public static void Insertar(DireccionPersona direccionPersona)
        {
            Operaciones.WriteLogsDebug("DireccionDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear una "+NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar Direccion
            string queryString = @"INSERT INTO DireccionPersona(nombreDireccion, idPersona, estadoModificacion) 
                                    VALUES(@nombreDireccion, @idPersona, @estadoModificacion)";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombreDireccion", direccionPersona.NombreDireccion);
                //command.Parameters.AddWithValue("@idPersona", direccionPersona.IdPersona.IdPersona);
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
                "Termino de ejecutar  el metodo acceso a datos para insertar "+NOMBRE));
        }

        /// <summary>
        /// Inserta una direccion a la base de datos y devuelve el ID, aparte me devuelve el comando
        /// </summary>
        /// <param name="Direccion"></param>        
        public static SqlCommand InsertarOUTPUT(DireccionPersona direccionPersona)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear una "+ NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar telefonos
            string queryString = @"INSERT INTO DireccionPersona(nombreDireccion, idPersona,idInmueble, estadoModificacion)
                                            VALUES(@nombreDireccion, @idPersona, @estadoModificacion)";

            command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@nombreDireccion", direccionPersona.NombreDireccion);
            //command.Parameters.AddWithValue("@idPersona", direccionPersona.IdPersona.IdPersona);            
            command.Parameters.AddWithValue("@estadoModificacion", 0);

            return command;

        }

        /// <summary>
        /// Elimina Direccion de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar una "+ NOMBRE));

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
        /// Actualiza telefono de la base de datos
        /// </summary>
        /// <param name="telefono"></param>
        public static void Actualizar(DireccionPersona direccionPersona)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar una" + NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE DireccionPersona SET nombreDireccion=@nombreDireccion
                                    WHERE idDireccion = @idDireccion";
            try
            {

                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombreDireccion", direccionPersona.NombreDireccion);
                command.Parameters.AddWithValue("@idDireccion", direccionPersona.IdDireccion);
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

            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar una "+NOMBRE));

        }

        /// <summary>
        /// Obtiene una Direccion de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Direccion Obtener(int id)
        {
            DireccionPersona res = new DireccionPersona();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM DireccionPersona WHERE idDireccion=@id and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new DireccionPersona()
                    {
                        IdDireccion = dr.GetInt32(0),
                        NombreDireccion = dr.GetString(1),
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

        public static void InsertarConTransaccion(DireccionPersona direccionPersona, SqlTransaction transaccion, SqlConnection conexion)
        {
            Operaciones.WriteLogsDebug("CuentaDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un " + "cuenta"));

            SqlCommand command = null;

            //Consulta para insertar personas
            string queryString = @"INSERT INTO DireccionPersona(nombreDireccion, idPersona, estadoModificacion) 
                                    VALUES(@nombreDireccion, @idPersona, @estadoModificacion)";

            try
            {
                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);

                command.Parameters.AddWithValue("@nombreDireccion", direccionPersona.NombreDireccion);
                command.Parameters.AddWithValue("@idPersona", OperacionesSql.GetActIdTable("Persona"));
                command.Parameters.AddWithValue("@estadoModificacion", 0);

                OperacionesSql.ExecuteBasicCommandWithTransaction(command);

            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease("CuentaDal", "Insertar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("CuentaDal", "Insertar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug("CuentaDal", "Insertar", string.Format("{0} Info: {1}",
                DateTime.Now.ToString(), DateTime.Now.ToString(),
                "Termino de ejecutar  el metodo acceso a datos para insertar " + "Cuenta"));
        }
    }
}
