using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class Carrito
    {
        public int carr_id { get; set; }
        public Cliente carr_clie_id { get; set; }
        public Producto carr_prod_id { get; set; }
        public int carr_cantidad { get; set; }
    }
}
