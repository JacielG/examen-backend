using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendComputadoras.Models
{
    public class Marca
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string anio { get; set; }
        public List<Computadora> Computadoras { get; set; }
    }
}
