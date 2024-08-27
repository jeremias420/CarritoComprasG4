using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capadatos;
using capaentidad;

namespace capanegocio
{
    public class CN_Producto
    {
        private CD_Producto objcapadatos = new CD_Producto();

        public List<Producto> Listar()
        {
            return objcapadatos.Listar();
        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.prod_nombre) || string.IsNullOrWhiteSpace(obj.prod_nombre))
            {
                Mensaje = "El nombre del producto no puede ser vacio";
            }

            if (string.IsNullOrEmpty(obj.prod_descripcion) || string.IsNullOrWhiteSpace(obj.prod_descripcion))
            {
                Mensaje = "La descripcion del producto no puede ser vacio";
            }

            if (obj.prod_marc_id.marc_id == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }

            else if (obj.prod_cate_id.cate_id == 0)
            {
                Mensaje = "Debe seleccionar una categoria";
            }

            else if (obj.prod_cate_id.cate_id == 0)
            {
                Mensaje = "Debe seleccionar una categoria";
            }

            else if(obj.prod_precio == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
            }

            else if (obj.prod_stock == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objcapadatos.Registrar(obj, out Mensaje);

            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.prod_nombre) || string.IsNullOrWhiteSpace(obj.prod_nombre))
            {
                Mensaje = "El nombre del producto no puede ser vacio";
            }

            if (string.IsNullOrEmpty(obj.prod_descripcion) || string.IsNullOrWhiteSpace(obj.prod_descripcion))
            {
                Mensaje = "La descripcion del producto no puede ser vacio";
            }

            if (obj.prod_marc_id.marc_id == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }

            else if (obj.prod_cate_id.cate_id == 0)
            {
                Mensaje = "Debe seleccionar una categoria";
            }

            else if (obj.prod_cate_id.cate_id == 0)
            {
                Mensaje = "Debe seleccionar una categoria";
            }

            else if (obj.prod_precio == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
            }

            else if (obj.prod_stock == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
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

        public bool GuardarDatosImagen(Producto obj, out string Mensaje)
        {
            return objcapadatos.GuardarDatosImagen(obj, out Mensaje);
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objcapadatos.Eliminar(id, out Mensaje);
        }
    }
}
