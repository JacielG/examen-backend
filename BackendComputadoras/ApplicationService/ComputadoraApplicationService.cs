using Microsoft.EntityFrameworkCore;
using BackendComputadoras.DataContext;
using BackendComputadoras.DomainService;
using BackendComputadoras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendComputadoras.ApplicationService
{
    public class ComputadoraApplicationService
    {
        private readonly BackendComputadorasDataContext _baseDatos;
        private readonly ComputadoraDomainService _computadoraDomainService;

        public ComputadoraApplicationService(BackendComputadorasDataContext _context, ComputadoraDomainService computadoraDomainService)
        {
            _baseDatos = _context;
            _computadoraDomainService = computadoraDomainService;
        }
        public async Task<string> GetComputadoraApplicationService(int id)
        {
            var computadora = await _baseDatos.Computadoras.Include(q => q.Marca).FirstOrDefaultAsync(q => q.id == id);

            var respuestaDomainService = _computadoraDomainService.ObtenerComputadora(id, computadora);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostComputadoraApplicationService(Computadora computadora)
        {
            var respuestaDomainService = _computadoraDomainService.RegistrarComputadora(computadora);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Computadoras.Add(computadora);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutComputadoraApplicationService(int id, Computadora computadora)
        {
            Marca marca = await _baseDatos.Marcas.FirstOrDefaultAsync(q => q.id == computadora.marcaId);

            var respuestaDomainService = _computadoraDomainService.ActualizarComputadora(id, computadora, marca);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(computadora).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteComputadoraApplicationService(int id)
        {
            var computadora = await _baseDatos.Computadoras.FindAsync(id);

            var respuestaDomainService = _computadoraDomainService.EliminarComputadora(id, computadora);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Computadoras.Remove(computadora);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
