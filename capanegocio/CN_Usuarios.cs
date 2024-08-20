using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capadatos;
using capaentidad;

namespace capanegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objcapadatos = new CD_Usuarios();

        public List<Usuario> Listar()
        {
            return objcapadatos.Listar();
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if(string.IsNullOrEmpty(obj.usua_nombre) || string.IsNullOrWhiteSpace(obj.usua_nombre))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";
            }else if(string.IsNullOrEmpty(obj.usua_apellido) || string.IsNullOrWhiteSpace(obj.usua_apellido)){
                Mensaje = "El apellido del usuario no puede estar vacio";
            }else if(string.IsNullOrEmpty(obj.usua_correo) || string.IsNullOrWhiteSpace(obj.usua_correo))
            {
                Mensaje = "El correo del usuasrio no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = CN_Recursos.GenerarClave();
                string mensaje_correo = "<h3>Su Cuenta fue creada correctamente</h3></br><p>Su contraseña para acceder es: !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", clave);

                bool respuesta = CN_Recursos.EnviarCorreo(obj.usua_correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    obj.usua_clave = CN_Recursos.ConvertirSha256(clave);
                    return objcapadatos.Registrar(obj, out Mensaje);
                }else
                {
                    Mensaje = "No se puede enviar el correo";
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.usua_nombre) || string.IsNullOrWhiteSpace(obj.usua_nombre))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.usua_apellido) || string.IsNullOrWhiteSpace(obj.usua_apellido))
            {
                Mensaje = "El apellido del usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.usua_correo) || string.IsNullOrWhiteSpace(obj.usua_correo))
            {
                Mensaje = "El correo del usuasrio no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objcapadatos.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objcapadatos.Eliminar(id, out Mensaje);
        }
    }
}
