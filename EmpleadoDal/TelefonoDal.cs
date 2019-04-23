using System;
using System.Data.SqlClient;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.EmpleadoDal
{
    public class TelefonoDal
    {
        /// <summary>
        /// Inserta un telefono a la base de datos 
        /// </summary>
        /// <param name="telefono"></param>
        /// <param name="idPersona"></param>
        public static void Insertar(Telefono telefono)
        {
            Operaciones.WriteLogsDebug("TelefonoDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un telefono"));

            SqlCommand command = null;

            //Consulta para insertar telefonos
            string queryString = @"INSERT INTO Telefono(numeroTelefono, tipoTelefono, idPersona, estadoModificacion) 
                                    VALUES(@numero, @tipo, @idPersona, @estadoModificacion)";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@numero", telefono.NumeroTelefono);
                command.Parameters.AddWithValue("@tipo", telefono.TipodeTelefono);
                command.Parameters.AddWithValue("@idPersona", telefono.IdPersona.IdPersona);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease("TelefonoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("TelefonoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug("TelefonoDal", "Insertar", string.Format("{0} {1} Info: {2}",
                DateTime.Now.ToString(), DateTime.Now.ToString(),
                "Termino de ejecutar  el metodo acceso a datos para insertar telefono"));
        }

        /// <summary>
        /// Inserta un telefono a la base de datos y devuelve el ID, aparte me devuelve el comando
        /// </summary>
        /// <param name="telefono"></param>
        /// <param name="idPersona"></param>
        public static SqlCommand InsertarOUTPUT(Telefono telefono)
        {
            Operaciones.WriteLogsDebug("TelefonoDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un telefono"));

            SqlCommand command = null;

            //Consulta para insertar telefonos
            string queryString = @"INSERT INTO Telefono(numeroTelefono, tipoTelefono, idPersona, EstadoModificacion) VALUES(@numero, @tipo, @idPersona, @estadoModificacion)";

            command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@numero", telefono.NumeroTelefono);
            command.Parameters.AddWithValue("@tipo", telefono.TipodeTelefono);
            command.Parameters.AddWithValue("@idPersona", telefono.IdPersona.IdPersona);
            command.Parameters.AddWithValue("@estadoModificacion", 0);

            return command;

        }

        /// <summary>
        /// Elimina telefono de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug("TelefonoDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Telefono SET estadoModificacion=1
                                    WHERE idTelefono = @idTelefono";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idTelefono", id);
                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease("TelefonoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("TelefonoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug("TelefonoDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));
        }

        /// <summary>
        /// Actualiza telefono de la base de datos
        /// </summary>
        /// <param name="telefono"></param>
        public static void Actualizar(Telefono telefono)
        {
            Operaciones.WriteLogsDebug("TelefonoDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Telefono SET numeroTelefono=@numero, tipoTelefono=@tipo
                                    WHERE idTelefono=@idTelefono";
            try
            {

                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@numero", telefono.NumeroTelefono);
                command.Parameters.AddWithValue("@tipo", telefono.TipodeTelefono);
                command.Parameters.AddWithValue("@idTelefono", telefono.IdTelefono);
                OperacionesSql.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease("TelefonoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("TelefonoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug("TelefonoDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));

        }

        /// <summary>
        /// Obtiene un Telefono de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Telefono Obtener(int id)
        {
            Telefono res = new Telefono();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Telefono WHERE idTelefono=@id and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Telefono()
                    {
                        IdTelefono = dr.GetInt16(0),
                        NumeroTelefono = dr.GetInt32(1),
                        TipodeTelefono = dr.GetByte(2),
                    };
                }
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease("TelefonoDal", "Obtenet(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
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
