﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class Cliente
    {
        public int clie_id { get; set; }
        public string clie_nombre { get; set; }
        public string clie_apellido { get; set; }
        public string clie_correo { get; set; }
        public string clie_clave { get; set; }
        public bool clie_restablecer { get; set; }
    }
}
