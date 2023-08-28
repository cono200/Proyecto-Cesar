using FinaliPB.Models;
using System.Data.SqlClient;
using System.Data;

namespace FinaliPB.Datos
{
    public class LoginUsuario
    {
        LoginRegister lr=new LoginRegister();   
        public bool Registro(UsuarioModel model)
        {
            bool respuesta;
            if(lr.existeCorreo(model.Correo))
            {
                try
                {
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getCadenaSql()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                        cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                        cmd.Parameters.AddWithValue("Apellido", model.Apellido);
                        cmd.Parameters.AddWithValue("Correo", model.Correo);
                        cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
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
            }
            else
            {
                respuesta = false;
            }
            return respuesta;
        }
        public class LoginRegister
        {
            public bool existeCorreo(string correo)

            {
                string eCorreo = "";
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ValidarCorreo", conexion);
                    cmd.Parameters.AddWithValue("Correo", correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            eCorreo = dr["Correo"].ToString();
                        }
                    }
                }
                if(eCorreo == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public UsuarioModel ValidarUsuario(string correo,string contraseña)
        {
            UsuarioModel usuario = new UsuarioModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conexion);
                cmd.Parameters.AddWithValue("Correo", correo);
                cmd.Parameters.AddWithValue("Contraseña", contraseña);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        usuario.Nombre = dr["Nombre"].ToString();
                        usuario.Apellido = dr["Apellido"].ToString();
                        usuario.Correo = dr["Correo"].ToString();
                        usuario.Contraseña = dr["Contraseña"].ToString();
                    }
                }
            }
            return usuario;
        }
        public bool CambiarContraseña(string correo,string contraseña)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using(var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CambiarContraseña", conexion);
                    cmd.Parameters.AddWithValue("Correo", correo);
                    cmd.Parameters.AddWithValue("Contraseña", contraseña);
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
    }
}
