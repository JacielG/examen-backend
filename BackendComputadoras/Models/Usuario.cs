using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendComputadoras.Models
{
    public class Usuario
    {
        public string usuarioId { get; set; }
        public string contrasena { get; set; }
        public bool estaActivo { get; set; }
    }
}
