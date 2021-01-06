using SBS.ApplicationCore.DTO;
using SBS.ApplicationCore.Entities;
using SBS.ApplicationCore.Interfaces.Repositories;
using SBS.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBS.ApplicationCore.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<List<BusquedaUsuarioDto>> BuscarUsuario(FiltroBusquedaUsuarioDto param)
        {
            return await _usuarioRepository.BuscarUsuario(param);
        }
        public async Task<int> GrabarUsuario(SbsUsuario usuario)
        {
            if (usuario.Usuarioid == 0)
                return await _usuarioRepository.InsertarUsuario(usuario);
            else
                return await _usuarioRepository.ModificarUsuario(usuario);
        }
        public async Task<int> EliminarUsuario(int usuarioId)
        {
            return await _usuarioRepository.EliminarUsuario(usuarioId);
        }
    }
}
