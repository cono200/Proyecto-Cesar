using FinaliPB.Models;
using System.Data.SqlClient;
using System.Data;

namespace FinaliPB.Datos
{
    public class ConsultaMDatos
    {   /*
        public List<ConsultaModel> Listar()
        {
            var oLista = new List<ConsultaModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarConsulta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ConsultaModel()
                        {

                            RefLibro= new LibroModel
                            {
                                IdLibro= Convert.ToInt32(dr["IdCategoria"]),
                                Nombre= dr["NombreCategoria"].ToString()
                            },
                            RefPrestamo= new PrestamoModel
                            {
                                IdPrestamo= Convert.ToInt32(dr["IdCategoria"]),

                            }
                            RefUsuario= new UsuarioModel
                            {

                            }

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
        */
    }
}
