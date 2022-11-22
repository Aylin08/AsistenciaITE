using AsistenciaDocentes.Models;
using System.Data.SqlClient;
using System.Data;
namespace AsistenciaDocentes.Datos
{
    public class DocentesDatos
    {
        public List<DocentesModel> Listar()
        {
            var objLista = new List<DocentesModel>();
            var con = new Conexion();

            using (var conexion = new SqlConnection(con.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        objLista.Add(new DocentesModel()
                        {
                            IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),

                        });
                        }
                    }
                }
            return objLista;
            }


        public DocentesModel Obtener(int IdEmpleado)
        {
            var objDocente = new DocentesModel();
            var con = new Conexion();

            using (var conexion = new SqlConnection(con.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("obtener_docentes", conexion);
                cmd.Parameters.AddWithValue("IdEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {


                        objDocente.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                        objDocente.Nombre = dr["Nombre"].ToString();
                        objDocente.Telefono = dr["Telefono"].ToString();

                    }
                }
               
                
            }
            return objDocente;
        }

        public bool GuardarDocente(DocentesModel objDo)
        {
            bool respuesta;

            try
            {
                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("agregar", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", objDo.IdEmpleado);
                    cmd.Parameters.AddWithValue("Nombre", objDo.Nombre);
                    cmd.Parameters.AddWithValue("Telefono",objDo.Telefono);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch(Exception e)
            {
                string error = e.Message;
                respuesta = false;

            }


            return respuesta;
        }

        public bool EditarDocente(DocentesModel objDo)
        {
            bool respuesta;

            try
            {
                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("modificar_docente", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", objDo.IdEmpleado);
                    cmd.Parameters.AddWithValue("Nombre", objDo.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", objDo.Telefono);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;

            }


            return respuesta;
        }

        public bool EliminarDocente(int IdEmpleado)
        {
            bool respuesta;

            try
            {
                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", IdEmpleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;

            }


            return respuesta;
        }
    }
    }
