using System.Data.SqlClient;
using System.Data;
using FinaliPB.Models;



namespace FinaliPB.Datos
{
    public class Prestamo_Datos
    {

        /*prestamo listar*/
        public List<PrestamoModel> ListaPrestamo()
        {
            var oLista = new List<PrestamoModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarPrestamoSIN", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PrestamoModel()
                        {
                            IdPrestamo = Convert.ToInt32(dr["IdPrestamo"]),
                            Titulo = dr["Titulo"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Usuario= dr["Usuario"].ToString(),
                            /*RefUsuario = new UsuarioModel
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                //Nombre = dr["Nombre"].ToString()
                            },*/
                            Fecha_de_Prestamo = (DateTime)dr["Fecha_de_Prestamo"],
                            Fecha_de_Entrega = (DateTime)dr["Fecha_de_Entrega"],
                            Estatus = Convert.ToChar(dr["Estatus"])

                        });
                    }
                }
            }
            return oLista;
        }

        //OBNETER PRESTAMO
        public PrestamoModel ObtenerPrestamo(int IdPrestamo)
        {
            var oPrestamo = new PrestamoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultaPrestamoSIN", conexion);
                cmd.Parameters.AddWithValue("IdPrestamo", IdPrestamo);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oPrestamo.IdPrestamo = Convert.ToInt32(dr["IdPrestamo"]);
                        oPrestamo.Titulo = dr["Titulo"].ToString();
                        oPrestamo.Usuario = dr["Titulo"].ToString();
                        /*oPrestamo.RefUsuario = new UsuarioModel
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Nombre = dr["Nombre"].ToString()
                        };*/
                        oPrestamo.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        oPrestamo.Fecha_de_Prestamo = (DateTime)dr["Fecha_de_Prestamo"];
                        oPrestamo.Fecha_de_Entrega = (DateTime)dr["Fecha_de_Entrega"];
                        oPrestamo.Estatus = (char)dr["Estatus"];
                    }
                }

            }
            return oPrestamo;
        }

        /*GUARDAR LIBRO*/
        public bool Prestamo_Guardar(PrestamoModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AñadirPrestamoSIN", conexion);
                    cmd.Parameters.AddWithValue("Titulo", model.Titulo);
                    cmd.Parameters.AddWithValue("Usuario", model.Usuario);
                    //cmd.Parameters.AddWithValue("Nombre", model.RefUsuario.Nombre);
                    cmd.Parameters.AddWithValue("Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("Fecha_de_Prestamo", model.Fecha_de_Prestamo);
                    cmd.Parameters.AddWithValue("Fecha_de_Entrega", model.Fecha_de_Entrega);
                    cmd.Parameters.AddWithValue("Estatus", model.Estatus);
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

        /*ACTUALIZAR LIBRO*/

        public bool Modificar_Presatamo(PrestamoModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarPrestamoSIN", conexion);
                    cmd.Parameters.AddWithValue("IdPrestamo", model.IdPrestamo);
                    cmd.Parameters.AddWithValue("Titulo", model.Titulo);
                    cmd.Parameters.AddWithValue("Usuario", model.Usuario);
                    //cmd.Parameters.AddWithValue("IdUsuario", model.RefUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("Fecha_de_Prestamo", model.Fecha_de_Prestamo);
                    cmd.Parameters.AddWithValue("Fecha_de_Entrega", model.Fecha_de_Entrega);
                    cmd.Parameters.AddWithValue("Estatus", model.Estatus);
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

        public bool Prestamo_Eliminar(int IdPrestamo)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarPrestamoSIN", conexion);
                    cmd.Parameters.AddWithValue("IdPrestamo",IdPrestamo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }

            catch (Exception es)
            {
                string error = es.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
