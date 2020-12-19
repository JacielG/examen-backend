using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendComputadoras.Models
{
    public class Computadora
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string tipoDisco { get; set; }
        public string precio { get; set; }
        public int marcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
