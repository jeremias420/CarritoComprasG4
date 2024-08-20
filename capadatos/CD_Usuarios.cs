using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaentidad;
using System.Data.SqlClient;
using System.Data;

namespace capadatos
{
    public class CD_Usuarios
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select usua_id, usua_nombre, usua_apellido, usua_correo, usua_clave, usua_restablecer, usua_activo from Usuario";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuario()
                                {
                                    usua_id = Convert.ToInt32(dr["usua_id"]),
                                    usua_nombre = dr["usua_nombre"].ToString(),
                                    usua_apellido = dr["usua_apellido"].ToString(),
                                    usua_correo = dr["usua_correo"].ToString(),
                                    usua_clave = dr["usua_clave"].ToString(),
                                    usua_restablecer = Convert.ToBoolean(dr["usua_restablecer"]),
                                    usua_activo = Convert.ToBoolean(dr["usua_activo"])
                                }
                            );
                        }
                    }
                }

            }
            catch
            {
                lista = new List<Usuario>();
            }
            return lista;
        }
        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.usua_nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.usua_apellido);
                    cmd.Parameters.AddWithValue("Correo", obj.usua_correo);
                    cmd.Parameters.AddWithValue("Clave", obj.usua_clave);
                    cmd.Parameters.AddWithValue("Activo", obj.usua_activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("usua_id", obj.usua_id);
                    cmd.Parameters.AddWithValue("usua_nombre", obj.usua_nombre);
                    cmd.Parameters.AddWithValue("usua_apellido", obj.usua_apellido);
                    cmd.Parameters.AddWithValue("usua_correo", obj.usua_correo);
                    cmd.Parameters.AddWithValue("usua_activo", obj.usua_activo);
                    cmd.Parameters.Add("usua_resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("usua_mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["usua_resultado"].Value);
                    Mensaje = cmd.Parameters["usua_mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from usuario where usua_id = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
    }
}
