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
            string queryString = @"INSERT INTO Persona(nombres, primerApellido, segundoApellido, cargo, carnet, estadoModificacion, sexo) 
                                    VALUES(@nombres, @primerApellido,@segundoApellido, @cargo, @carnet, @estadoModificacion, @sexo)";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombres", persona.Nombres);
                command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
                command.Parameters.AddWithValue("@cargo", persona.Cargo);
                command.Parameters.AddWithValue("@carnet", persona.Carnet);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                command.Parameters.AddWithValue("@sexo", persona.Sexo);
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

        public static void InsertarConTransaccion(Persona persona, SqlTransaction transaccion, SqlConnection conexion)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un persona"));

            SqlCommand command = null;

            //Consulta para insertar personas
            string queryString = @"INSERT INTO Persona(nombres, primerApellido, segundoApellido, cargo, carnet, estadoModificacion, sexo) 
                                    VALUES(@nombres, @primerApellido,@segundoApellido, @cargo, @carnet, @estadoModificacion, @sexo)";            

            try
            {                
                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);

                command.Parameters.AddWithValue("@nombres", persona.Nombres);
                command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
                command.Parameters.AddWithValue("@cargo", persona.Cargo);
                command.Parameters.AddWithValue("@carnet", persona.Carnet);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                command.Parameters.AddWithValue("@sexo", persona.Sexo);
                OperacionesSql.ExecuteBasicCommandWithTransaction(command);

            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Insertar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Insertar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
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
            string queryString = @"INSERT INTO Persona(nombres, primerApellido, segundoApellido, cargo, carnet, estadoModificacion, sexo) 
                                            VALUES(@nombres, @primerApellido,@segundoApellido, @cargo, @carnet, @estadoModificacion, @sexo)";

            command = new SqlCommand(queryString);
            command.Parameters.AddWithValue("@nombres", persona.Nombres);
            command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
            command.Parameters.AddWithValue("@cargo", persona.Cargo);
            command.Parameters.AddWithValue("@carnet", persona.Carnet);
            command.Parameters.AddWithValue("@sexo", persona.Sexo);
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
        /// Elimina Persona de la base de datos
        /// </summary>
        /// <param name="idPersona"></param>
        public static void EliminarConTransaccion(int idPersona, SqlTransaction transaccion, SqlConnection conexion)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Persona"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Persona SET estadoModificacion = 1
                                    WHERE idPersona = @idPersona";
            try
            {
                command = OperacionesSql.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);
                command.Parameters.AddWithValue("@idPersona", idPersona);
                OperacionesSql.ExecuteBasicCommandWithTransaction(command);
            }
            catch (SqlException ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Eliminar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "Eliminar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));
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
                                   SET nombres=@nombres, primerApellido=@primerApellido,segundoApellido=@segundoApellido, cargo = @cargo,carnet=@carnet, sexo = @sexo
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
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
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
                        Sexo = dr.GetByte(6),                        
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

        public static List<Persona> buscar_persona_por_primer_apellido(string primer_apellido)
        {
            List<Persona> personas_encontradas = new List<Persona>();
            Persona res = new Persona();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Persona WHERE primerApellido=@primer_apellido and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@primer_apellido", primer_apellido);
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
                        Sexo = dr.GetByte(6)
                    };

                    personas_encontradas.Add(res);
                }
            }
            catch (Exception ex)
            {
                Operaciones.WriteLogsRelease(NOMBREDAL, "buscar personas por primer apellido(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return personas_encontradas;
        }
    }
}
