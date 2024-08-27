using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capadatos;
using capaentidad;


namespace capanegocio
{
    public class CN_Marca
    {
        private CD_Marca objcapadatos = new CD_Marca();

        public List<Marca> Listar()
        {
            return objcapadatos.Listar();
        }

        public int Registrar(Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.marc_descrip) || string.IsNullOrWhiteSpace(obj.marc_descrip))
            {
                Mensaje = "La descripcion de la categoria no puede ser vacio";
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

        public bool Editar(Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.marc_descrip) || string.IsNullOrWhiteSpace(obj.marc_descrip))
            {
                Mensaje = "La descripcion de la marca no puede ser vacio";
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
