using FinaliPB.Models;
using System.Data.SqlClient;
using System.Data;
using FinaliPB.Datos;
using NuGet.Versioning;
using System.Text.RegularExpressions;

namespace FinaliPB.Datos
{
    public class LibroDatos
    {

        public List<LibroModel> Listar()
        {
            var oLista = new List<LibroModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarlibros", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new LibroModel()
                        {
                            IdLibro = Convert.ToInt32(dr["IdLibro"]),
                            Nombre = dr["Nombre"].ToString(),
                            Autor = dr["Autor"].ToString(),
                            
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            ISBN = dr["ISBN"].ToString(),
                            Fecha_de_Compra = (DateTime)dr["Fecha_de_Compra"],
                            Fecha_de_Adquisicion = (DateTime)dr["Fecha_de_Adquisicion"]

                        });
                    }
                }
            }
            return oLista;
        }
        /*Obtener libros especificos*/
        public LibroModel Obtener(int IdLibro)
        {
            var oConsulta = new LibroModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_consultaLibro", conexion);

                cmd.Parameters.AddWithValue("IdLibro", IdLibro);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var fc = cmd.ExecuteReader())
                {
                    while (fc.Read())
                    {
                        oConsulta.IdLibro = Convert.ToInt32(fc["IdLibro"]);
                        oConsulta.Nombre = fc["Nombre"].ToString();
                        oConsulta.Autor = fc["Autor"].ToString();
                        oConsulta.Cantidad = Convert.ToInt32(fc["Cantidad"]);
                        oConsulta.ISBN = fc["ISBN"].ToString();
                        oConsulta.Fecha_de_Compra = (DateTime)fc["Fecha_de_Compra"];
                        oConsulta.Fecha_de_Adquisicion = (DateTime)fc["Fecha_de_Adquisicion"];
                    }
                }

            }
            return oConsulta;

        }
        /*añadir libro*/
        public bool Añadir(LibroModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_añadirLibro", conexion);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Autor", model.Autor);
                    cmd.Parameters.AddWithValue("Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("ISBN", model.ISBN);
                    cmd.Parameters.AddWithValue("F_Compra", model.Fecha_de_Compra);
                    cmd.Parameters.AddWithValue("F_Adquisicion", model.Fecha_de_Adquisicion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }



        /*editar libros*/
        public bool Editar(LibroModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarLibro", conexion);
                    cmd.Parameters.AddWithValue("IdLibro", model.IdLibro);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Autor", model.Autor);
                    cmd.Parameters.AddWithValue("Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("ISBN", model.ISBN);
                    cmd.Parameters.AddWithValue("F_compra", model.Fecha_de_Compra);
                    cmd.Parameters.AddWithValue("F_adquisicion", model.Fecha_de_Adquisicion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }




        /*eliminar libro*/
        public bool eliminar(int IdLibro)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarLibro", conexion);
                    cmd.Parameters.AddWithValue("IdLibro", IdLibro);
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
