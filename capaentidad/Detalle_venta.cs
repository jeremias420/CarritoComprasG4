using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    class Detalle_venta
    {
        public int deve_id { get; set; }
        public Venta deve_vent_id { get; set; }
        public Producto deve_prod_id { get; set; }
        public int deve_cantidad { get; set; }
        public decimal deve_total { get; set; }
        public string deve_transaccion_id { get; set; }
    }
}
