using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendComputadoras.Models;

namespace BackendComputadoras.DomainService
{
    public class MarcaDomainService
    {
        public string ObtenerMarca(int id, Marca marca)
        {
            var esMarcaValido = marca == null;
            if (esMarcaValido)
            {
                return "La marca no existe.";
            }

            return null;
        }
        public string RegistrarMarca(Marca marca)
        {
            var esNombreValido = marca.nombre == "";
            if (esNombreValido)
            {
                return "Se requiere el nombre de la marca.";
            }

            var esAnioValido = marca.anio == "";
            if (esAnioValido)
            {
                return "Se requiere del año.";
            }

            return null;
        }
        public string ActualizarMarca(int id, Marca marca)
        {
            var esNombreValido = marca.nombre == "";
            if (esNombreValido)
            {
                return "Se requiere el nombre de la marca.";
            }

            var esAnioValido = marca.anio == "";
            if (esAnioValido)
            {
                return "Se requiere del año.";
            }

            return null;
        }
        public string EliminarMarca(int id, Marca marca)
        {
            var esMarcaValido = marca == null;
            if (esMarcaValido)
            {
                return "El marca no existe.";
            }

            return null;
        }
    }
}
