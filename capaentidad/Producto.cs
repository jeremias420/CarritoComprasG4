using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class Producto
    {
        public int prod_id { get; set; }
        public string prod_nombre { get; set; }
        public string prod_descripcion { get; set; }
        public Categoria prod_cate_id { get; set; }
        public Marca prod_marc_id { get; set; }
        public decimal prod_precio { get; set; }
        public int prod_stock { get; set; }
        public string prod_ruta_imagen { get; set; }
        public string prod_nomb_imagen { get; set; }
        public bool prod_activo { get; set; }
    }
}
