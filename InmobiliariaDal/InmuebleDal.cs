using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.Comun;

namespace Univalle.Fie.Sistemas.BaseDatosII.InmobiliariaApp.InmobiliariaDal
{
    public class InmuebleDal
    {

        const string NOMBRE = "Inmueble";
        const string NOMBREDAL = "InmuebleDal";
        /// <summary>
        /// Inserta un telefono a la base de datos 
        /// </summary>       
        /// <param name="IdInmueble"></param>

        public static void Insertar(Inmueble inmueble)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear una " + NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar inmuebles
            string queryString = @"INSERT INTO Inmueble(estado, zona, superficieSprox, estadoModificacion) 
                                    VALUES(@estado, @zona,@superficieSprox, @estadoModificacion)";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@estado", inmueble.estado);
                command.Parameters.AddWithValue("@zona", inmueble.zona);
                command.Parameters.AddWithValue("@superficieSprox", inmueble.superficieSprox);
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
                "Termino de ejecutar  el metodo acceso a datos para insertar " + NOMBRE));
        }

        ///// <summary>
        ///// Inserta un Email a la base de datos y devuelve el ID, aparte me devuelve el comando
        ///// </summary>
        ///// <param name=Persona></param>        
        //public static SqlCommand InsertarOUTPUT(Persona persona)
        //{
        //    Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
        //    DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un " + NOMBRE));

        //    SqlCommand command = null;

        //    //Consulta para insertar Persona
        //    string queryString = @"INSERT INTO Persona(nombres, primerApellido, segundoApellido, cargo, carnet, estadoModificacion) 
        //                                    VALUES(@nombres, @primerApellido,@segundoApellido, @cargo, @carnet, @estadoModificacion)";

        //    command = new SqlCommand(queryString);
        //    command.Parameters.AddWithValue("@nombres", persona.Nombres);
        //    command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
        //    command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
        //    command.Parameters.AddWithValue("@cargo", persona.Cargo);
        //    command.Parameters.AddWithValue("@carnet", persona.Carnet);
        //    command.Parameters.AddWithValue("@estadoModificacion", 0);

        //    return command;

        //}

        /// <summary>
        /// Elimina Persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un " + NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Inmueble SET estadoModificacion = 1
                                    WHERE IdInmueble = @IdInmueble";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@IdInmueble", id);
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

            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un " + NOMBRE));
        }

        /// <summary>
        /// Actualiza Persona de la base de datos
        /// </summary>
        /// <param name="Inmueble"></param>
        public static void Actualizar(Inmueble inmueble)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un " + NOMBRE));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Inmueble 
                                   SET estado=@estado, zona=@zona,superficieSprox=@superficieSprox, estadoModificacion = 0
                                   WHERE IdInmueble=@IdInmueble";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@estado", inmueble.estado);
                command.Parameters.AddWithValue("@zona", inmueble.zona);
                command.Parameters.AddWithValue("@superficieSprox", inmueble.superficieSprox);
                command.Parameters.AddWithValue("@estadoModificacion", 0);
                command.Parameters.AddWithValue("@IdInmueble", inmueble.idInmueble);
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

            Operaciones.WriteLogsDebug(NOMBREDAL, "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un " + NOMBREDAL));

        }

        /// <summary>
        /// Obtiene una Persona de la base de datos
        /// </summary>
        /// <param name="IdInmueble"></param>
        /// <returns></returns>
        public static Inmueble Obtener(int IdInmueble)
        {
            Inmueble res = new Inmueble();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Inmueble WHERE IdInmueble=@IdInmueble and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@IdInmueble", IdInmueble);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Inmueble()
                    {
                        idInmueble = dr.GetInt32(0),
                        estado = dr.GetByte(1),
                        zona = dr.GetString(2),
                        superficieSprox = dr.GetString(3),

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

        public void buscar_inmueble(int IdInmueble)
        {
            Inmueble res = new Inmueble();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Inmueble WHERE IdInmueble=@IdInmueble and estadoModificacion=0";
            try
            {
                cmd = OperacionesSql.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@IdInmueble", IdInmueble);
                dr = OperacionesSql.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Inmueble()
                    {
                        idInmueble = dr.GetInt32(0),
                        estado = dr.GetByte(1),
                        zona = dr.GetString(2),
                        superficieSprox = dr.GetString(3),
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
            
        }
    }
}


