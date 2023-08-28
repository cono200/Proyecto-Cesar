using FinaliPB.Models;
using System.Data.SqlClient;
using System.Data;
using FinaliPB.Datos;
using NuGet.Versioning;
using System.Text.RegularExpressions;

namespace Proyecto_Editorial.Datos
{
    public class EditorialDatos
    {
        public List<EditorialModel> Listar()
        {
            var oLista = new List<EditorialModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection (cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Editorial_Listar", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EditorialModel()
                        {
                            IdEditorial = Convert.ToInt32(dr["IdEditorial"]),
                            Nombre = dr["Nombre"].ToString(),
                            Numero_Publicaciones = Convert.ToInt32(dr["Numero_Publicaciones"]),
                            Calidad = dr["Calidad"].ToString(),
                            Especialidad = dr["Especialidad"].ToString()
                        });
                    }

                }
            }
            return oLista;
        }
        public EditorialModel ObtenerEditorial(int IdEditorial)
        {
            var oEditorial = new EditorialModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Editorial_Obtener", conexion);

                cmd.Parameters.AddWithValue("IdEditorial", IdEditorial);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEditorial.IdEditorial = Convert.ToInt32(dr["IdEditorial"]);
                        oEditorial.Nombre = dr["Nombre"].ToString();
                        oEditorial.Numero_Publicaciones = Convert.ToInt32(dr["IdEditorial"]);
                        oEditorial.Calidad = dr["Calidad"].ToString();
                        oEditorial.Especialidad = dr["Especialidad"].ToString();
                    }
                }
            }
            return oEditorial;
        }
        public bool GuardarEditorial(EditorialModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditorialGuardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Numero_Publicaciones", model.Numero_Publicaciones);
                    cmd.Parameters.AddWithValue("Calidad", model.Calidad);
                    cmd.Parameters.AddWithValue("Especialidad", model.Especialidad);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool EditarEditorial(EditorialModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarEditorial", conexion);
                    cmd.Parameters.AddWithValue("IdEditorial", model.IdEditorial);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Numero_Publicaciones", model.Numero_Publicaciones);
                    cmd.Parameters.AddWithValue("Calidad", model.Calidad);
                    cmd.Parameters.AddWithValue("Especialidad", model.Especialidad);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;

        }
        public bool EliminarEditorial(int IdEditorial)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarEditorial", conexion);
                    cmd.Parameters.AddWithValue("IdEditorial", IdEditorial);
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