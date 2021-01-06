using SBS.ApplicationCore.DTO;
using SBS.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBS.ApplicationCore.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<List<BusquedaUsuarioDto>> BuscarUsuario(FiltroBusquedaUsuarioDto param);
        Task<int> GrabarUsuario(SbsUsuario usuario);
        Task<int> EliminarUsuario(int usuarioId);
    }
}
