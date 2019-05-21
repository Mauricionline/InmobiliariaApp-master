using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.EmpleadoDal
{
    
    public class PersonaDal
    {
        const string NOMBRE = "Persona";
        const string NOMBREDAL = "PersonaDal";
        /// <summary>
        /// Inserta un telefono a la base de datos 
        /// </summary>       
        /// <param name="idPersona"></param>

        public static void Insertar(Persona persona)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear una "+NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar telefonos
            string queryString = @"INSERT INTO Persona(nombres, primerApellido, segundoApellido, cargo, carnet, estadoModificacion) 
                                    VALUES(@nombres, @primerApellido,@segundoApellido, @cargo, @carnet, @estadoModificacion)";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombres", persona.Nombres);
                command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
                command.Parameters.AddWithValue("@cargo", persona.Cargo);
                command.Parameters.AddWithValue("@carnet", persona.Carnet);
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
        /// Inserta un Email a la base de datos y devuelve el ID, aparte me devuelve el comando
        /// </summary>
        /// <param name=Persona></param>        
        public static SqlCommand InsertarOUTPUT(Persona persona)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un "+NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar Persona
            string queryString = @"INSERT INTO Persona(nombres, primerApellido, segundoApellido, cargo, carnet, estadoModificacion) 
                                            VALUES(@nombres, @primerApellido,@segundoApellido, @cargo, @carnet, @estadoModificacion)";

            command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@nombres", persona.Nombres);
            command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
            command.Parameters.AddWithValue("@cargo", persona.Cargo);
            command.Parameters.AddWithValue("@carnet", persona.Carnet);
            command.Parameters.AddWithValue("@estadoModificacion", 0);

            return command;

        }

        /// <summary>
        /// Elimina Persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un "+NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Persona SET estadoModificacion = 1
                                    WHERE idPersona = @idPersona";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idPersona", id);
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

            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un "+NOMBRE));
        }

        /// <summary>
        /// Actualiza Persona de la base de datos
        /// </summary>
        /// <param name="Persona"></param>
        public static void Actualizar(Persona persona)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un "+NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Persona 
                                   SET nombres=@nombres, primerApellido=@primerApellido,segundoApellido=@segundoApellido, cargo = @cargo,carnet=@carnet
                                   WHERE idPersona=@idPersona";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombres", persona.Nombres);
                command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
                command.Parameters.AddWithValue("@cargo", persona.Cargo);
                command.Parameters.AddWithValue("@carnet", persona.Carnet);
                command.Parameters.AddWithValue("@idPersona", persona.IdPersona);
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

            Operaciones.WriteLogsDebug(NOMBREDAL, "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un "+NOMBREDAL));

        }

        /// <summary>
        /// Obtiene una Persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Persona Obtener(int id)
        {
            Persona res = new Persona();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Persona WHERE idPersona=@id and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Persona()
                    {
                        IdPersona = dr.GetInt32(0),
                        Nombres = dr.GetString(1),
                        PrimerApellido = dr.GetString(2),
                        SegundoApellido = dr.GetString(3),
                        Cargo = dr.GetByte(4),
                        Carnet = dr.GetString(5),
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

        public void buscar_persona()
        {
            Persona res = new Persona();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Persona WHERE idPersona=@id and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Persona()
                    {
                        IdPersona = dr.GetInt32(0),
                        Nombres = dr.GetString(1),
                        PrimerApellido = dr.GetString(2),
                        SegundoApellido = dr.GetString(3),
                        Cargo = dr.GetByte(4),
                        Carnet = dr.GetString(5),
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
