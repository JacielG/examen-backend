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
    public class UsuarioApplicationService
    {
        private readonly BackendComputadorasDataContext _baseDatos;
        private readonly UsuarioDomainService _usuarioDomainServices;
        public UsuarioApplicationService(BackendComputadorasDataContext baseDatos, UsuarioDomainService usuarioDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _usuarioDomainServices = usuarioDomainServiceaseDatos;
        }

        public async Task<string> TieneAccesoUsuario(string usuarioId, string contrasenia)
        {
            var usuario = await _baseDatos.Usuarios.FirstOrDefaultAsync(q => q.usuarioId == usuarioId
            && q.contrasena == contrasenia);


            var respuestaDomain = _usuarioDomainServices.TieneAcceso(usuario);
            bool vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }

            return "success";
        }
    }
}
