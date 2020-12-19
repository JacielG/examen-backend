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
    public class MarcaApplicationService
    {
        private readonly BackendComputadorasDataContext _baseDatos;
        private readonly MarcaDomainService _marcaDomainService;
        public MarcaApplicationService(BackendComputadorasDataContext _context, MarcaDomainService marcaDomainService)
        {
            _baseDatos = _context;
            _marcaDomainService = marcaDomainService;
        }
        public async Task<string> GetMarcaApplicationService(int id)
        {
            var marca = await _baseDatos.Marcas.FirstOrDefaultAsync(q => q.id == id);

            var respuestaDomainService = _marcaDomainService.ObtenerMarca(id, marca);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostMarcaApplicationService(Marca marca)
        {
            var respuestaDomainService = _marcaDomainService.RegistrarMarca(marca);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Marcas.Add(marca);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutMarcaApplicationService(int id, Marca marca)
        {
            var respuestaDomainService = _marcaDomainService.ActualizarMarca(id, marca);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(marca).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteMarcaApplicationService(int id)
        {
            var marca = await _baseDatos.Marcas.FindAsync(id);

            var respuestaDomainService = _marcaDomainService.EliminarMarca(id, marca);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Marcas.Remove(marca);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
