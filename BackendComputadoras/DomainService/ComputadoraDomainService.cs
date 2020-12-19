using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendComputadoras.Models;

namespace BackendComputadoras.DomainService
{
    public class ComputadoraDomainService
    {
        public string ObtenerComputadora(int id, Computadora computadora)
        {
            var esComputadoraValido = computadora == null;
            if (esComputadoraValido)
            {
                return "La computadora no existe.";
            }

            return null;
        }
        public string RegistrarComputadora(Computadora computadora)
        {
            var esNombreValido = computadora.nombre == "";
            if (esNombreValido)
            {
                return "Se requiere el nombre de la computadora.";
            }

            var esTipoDiscoValido = computadora.tipoDisco == "";
            if (esTipoDiscoValido)
            {
                return "Se requiere del tipo de disco.";
            }

            var esPrecioValido = computadora.precio == "";
            if (esPrecioValido)
            {
                return "Se requiere el precio.";
            }

            return null;
        }
        public string ActualizarComputadora(int id, Computadora computadora, Marca marca)
        {
            var esMarcaValido = marca == null;
            if (esMarcaValido)
            {
                return "La marca no existe.";
            }

            var esNombreValido = computadora.nombre == "";
            if (esNombreValido)
            {
                return "Se requiere el nombre de la computadora.";
            }

            var esTipoDiscoValido = computadora.tipoDisco == "";
            if (esTipoDiscoValido)
            {
                return "Se requiere del tipo de disco.";
            }

            var esPrecioValido = computadora.precio == "";
            if (esPrecioValido)
            {
                return "Se requiere el precio.";
            }

            return null;
        }
        public string EliminarComputadora(int id, Computadora computadora)
        {
            var esComputadoraValido = computadora == null;
            if (esComputadoraValido)
            {
                return "El computadora no existe.";
            }

            return null;
        }
    }
}
