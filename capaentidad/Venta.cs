using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class Venta
    {
        public int vent_id { get; set; }
        public Cliente vent_clie_id { get; set; }
        public int vent_total_prod { get; set; }
        public decimal vent_monto_total { get; set; }
        public string vent_contacto { get; set; }
        public string vent_distrito_id { get; set; }
        public string vent_telefono { get; set; }
        public string vent_direccion { get; set; }
        public string vent_transaccion_id { get; set; }
        //public List<Detalle_venta> Detalle_Ventas { get; set; }
    }
}
