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
        /// Inserta un telefono a la base de datos 
        /// </summary>       
        /// <param name="idFoto"></param>

        public static void Insertar(Fotos foto)
        {
            Operaciones.WriteLogsDebug(NOMBREDAL, "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear una " + NOMBRE));

            SqlCommand command = null;

            //Consulta para insertar inmuebles
            string queryString = @"INSERT INTO Fotos(estado, direccionFotos, estadoModificacion) 
                                    VALUES(@estado, @zona,@superficieSprox, @estadoModificacion)";
            try
            {
                command = OperacionesSql.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@estado", foto.estado);
                command.Parameters.AddWithValue("@zona", foto.zona);
                command.Parameters.AddWithValue("@superficieSprox", foto.superficieSprox);
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

