using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaentidad;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace capadatos
{
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select p.prod_id, p.prod_nombre, p.prod_descripcion,");
                    sb.AppendLine("m.marc_id, m.marc_descrip,c.cate_id, c.cate_descrip,");
                    sb.AppendLine("p.prod_precio, p.prod_stock, p.prod_ruta_imagen, p.prod_nomb_imagen, p.prod_activo");
                    sb.AppendLine("from Producto p");
                    sb.AppendLine("inner join Marca m on m.marc_id = p.prod_marc_id");
                    sb.AppendLine("inner join Categoria c on c.cate_id = p.prod_cate_id");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                prod_id = Convert.ToInt32(dr["prod_id"]),
                                prod_nombre = dr["¨prod_nombre"].ToString(),
                                prod_descripcion = dr["¨prod_descripcion"].ToString(),
                                prod_activo = Convert.ToBoolean(dr["prod_activo"]),
                                prod_marc_id = new Marca() { marc_id = Convert.ToInt32(dr["prod_id"]), marc_descrip = dr["marc_descrip"].ToString() },
                                prod_cate_id = new Categoria() { cate_id = Convert.ToInt32(dr["cate_id"]), cate_descrip = dr["cate_descrip"].ToString() },
                                prod_precio = Convert.ToDecimal(dr["prod_precio"], new CultureInfo("es-ARG")),
                                prod_stock = Convert.ToInt32(dr["prod_stock"]),
                                prod_ruta_imagen = dr["¨prod_ruta_imagen"].ToString(),
                                prod_nomb_imagen = dr["¨prod_nomb_imagen"].ToString(),
                            });
                        }
                    }
                }

            }
            catch
            {
                lista = new List<Producto>();
            }
            return lista;
        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oconexion);
                    cmd.Parameters.AddWithValue("prod_nombre", obj.prod_nombre);
                    cmd.Parameters.AddWithValue("prod_descripcion", obj.prod_descripcion);
                    cmd.Parameters.AddWithValue("prod_cate_id", obj.prod_cate_id);
                    cmd.Parameters.AddWithValue("prod_marc_id", obj.prod_marc_id);
                    cmd.Parameters.AddWithValue("prod_precio", obj.prod_precio);
                    cmd.Parameters.AddWithValue("prod_stock", obj.prod_stock);
                    cmd.Parameters.AddWithValue("prod_activo", obj.prod_activo);
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

        public bool Editar(Producto obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarProducto", oconexion);
                    cmd.Parameters.AddWithValue("prod_id", obj.prod_id);
                    cmd.Parameters.AddWithValue("prod_nombre", obj.prod_nombre);
                    cmd.Parameters.AddWithValue("prod_descripcion", obj.prod_descripcion);
                    cmd.Parameters.AddWithValue("prod_cate_id", obj.prod_cate_id);
                    cmd.Parameters.AddWithValue("prod_marc_id", obj.prod_marc_id);
                    cmd.Parameters.AddWithValue("prod_precio", obj.prod_precio);
                    cmd.Parameters.AddWithValue("prod_stock", obj.prod_stock);
                    cmd.Parameters.AddWithValue("prod_activo", obj.prod_activo);
                    cmd.Parameters.Add("prod_resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("prod_mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["marc_resultado"].Value);
                    Mensaje = cmd.Parameters["marc_mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool GuardarDatosImagen(Producto obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "update Producto set prod_ruta_imagen = @prod_ruta_imagen, prod_nomb_imagen = @prod_nomb_imagen where prod_id = @prod_id";

                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oconexion);
                    cmd.Parameters.AddWithValue("@prod_ruta_imagen", obj.prod_ruta_imagen);
                    cmd.Parameters.AddWithValue("@prod_nomb_imagen", obj.prod_nomb_imagen);
                    cmd.Parameters.AddWithValue("@prod_id", obj.prod_id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        Mensaje = "No se pudo actualizar imagen";
                    };
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int prod_id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarProducto", oconexion);
                    cmd.Parameters.AddWithValue("prod_id", prod_id);
                    cmd.Parameters.Add("prod_resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("prod_mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["prod_resultado"].Value);
                    Mensaje = cmd.Parameters["prod_mensaje"].Value.ToString();
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
