using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.EmpleadoDal
{
    public class CuentaDal
    {
        /// <summary>
        /// Inserta una cuenta a la base de datos 
        /// </summary>
        /// <param name="Cuenta"></param>        
        public static void Insertar(Cuenta cuenta)
        {
            Operaciones.WriteLogsDebug("CuentaDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear una Cuenta"));

            SqlCommand command = null;

            //Consulta para insertar Cuenta
            string queryString = @"INSERT INTO Cuenta(usuario, contrasena, idPersona, estadoModificacion) 
                                    VALUES(@usuario, @contrasena, @idPersona, @estadoModificacion)";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@usuario", cuenta.Usuario);
                command.Parameters.AddWithValue("@contrasena", cuenta.Contrasena);
                command.Parameters.AddWithValue("@idPersona", cuenta.idPersona.IdPersona);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease("CuentaDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("CuentaDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug("CuentaDal", "Insertar", string.Format("{0} {1} Info: {2}",
                DateTime.Now.ToString(), DateTime.Now.ToString(),
                "Termino de ejecutar  el metodo acceso a datos para insertar Cuenta"));
        }

        /// <summary>
        /// Inserta un Cuenta a la base de datos y devuelve el ID, aparte me devuelve el comando
        /// </summary>
        /// <param name="Cuenta"></param>
        /// <param name="idPersona"></param>        
        public static SqlCommand InsertarOUTPUT(Cuenta cuenta)
        {
            Operaciones.WriteLogsDebug("CuentaDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un Cuenta"));

            SqlCommand command = null;

            //Consulta para insertar telefonos
            string queryString = @"INSERT INTO CuentaCuenta(usuario, contrasena, idPersona, estadoModificacion) 
                                                VALUES(@usuario, @contrasena, @idPersona, @estadoModificacion)";

            command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@usuario", cuenta.Usuario);
            command.Parameters.AddWithValue("@contrasena", cuenta.Contrasena);
            command.Parameters.AddWithValue("@idPersona", cuenta.idPersona.IdPersona);
            command.Parameters.AddWithValue("@estadoModificacion", 0);

            return command;

        }

        /// <summary>
        /// Elimina telefono de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug("CuentaDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Cuenta SET estadoModificacion=1
                                    WHERE idCuenta = @idCuenta";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idCuenta", id);
                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease("CuentaDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("CuentaDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug("CuentaDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));
        }

        /// <summary>
        /// Actualiza Cuenta de la base de datos
        /// </summary>
        /// <param name="Cuenta"></param>
        public static void Actualizar(Cuenta cuenta)
        {
            Operaciones.WriteLogsDebug("CuentaDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Cuenta SET contrasena=@contrasena
                                    WHERE idCuenta=@idCuenta";
            try
            {

                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@contrasena", cuenta.Contrasena);                
                command.Parameters.AddWithValue("@idCuenta", cuenta.idCuenta);
                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease("CuentaDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("CuentaDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug("CuentaDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));

        }

        /// <summary>
        /// Obtiene un Cuenta de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Cuenta Obtener(int id)
        {
            Cuenta res = new Cuenta();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Cuenta WHERE idCuenta=@id and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Cuenta()
                    {
                        idCuenta = dr.GetInt32(0),
                        Usuario = dr.GetString(1),                                                
                    };
                }
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("CuentaDal", "Obtenet(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
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
