using SBS.ApplicationCore.DTO;
using SBS.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBS.ApplicationCore.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<BusquedaUsuarioDto>> BuscarUsuario(FiltroBusquedaUsuarioDto param);
        Task<int> InsertarUsuario(SbsUsuario usuario);
        Task<int> ModificarUsuario(SbsUsuario usuario);
        Task<int> EliminarUsuario(int usuarioId);
    }
}
