using Microsoft.EntityFrameworkCore;
using SBS.ApplicationCore.DTO;
using SBS.ApplicationCore.Entities;
using SBS.ApplicationCore.Interfaces.Repositories;
using SBS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBS.Infrastructure.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly ModelContext _context;
        public UsuarioRepository(ModelContext context)
        {
            _context = context;
        }

        // GET: Usuarios

        public async Task<List<BusquedaUsuarioDto>> BuscarUsuario(FiltroBusquedaUsuarioDto param)
        {
            List<SbsUsuario> listaUsuario = null;

            //var listaUsuarioActivo = _context.SbsUsuario.AsNoTracking().Where(u => u.Activo == true);

            listaUsuario =
                await _context.SbsUsuario.Where
                (
                u => (
                    (param.CodigoUsuario.Equals("") || u.Codigousuario.Contains(param.CodigoUsuario))
                    &&
                    (param.RolId == 0 || u.Rolid == param.RolId)
                    )
                ).ToListAsync();

            return RetornarDtoBusqueda(listaUsuario);
        }

        public async Task<int> InsertarUsuario(SbsUsuario param)
        {
            int result = 0;

            try
            {
                // Método sin transacción

                var newId = _context.SbsUsuario.DefaultIfEmpty().Max(r => r == null ? 0 : r.Usuarioid) + 1;

                var itemAdd = new SbsUsuario
                {
                    Usuarioid = newId,
                    Rolid = param.Rolid,
                    Codigousuario = param.Codigousuario,
                    Clavesecreta = param.Clavesecreta,
                    Email = param.Email,
                    Apellidopaterno = param.Apellidopaterno,
                    Apellidomaterno = param.Apellidomaterno,
                    Primernombre = param.Primernombre,
                    Segundonombre = param.Segundonombre,
                    Alias = param.Alias,
                    Primeravezlogin = true,
                    Activo = true
                };

                _context.SbsUsuario.Add(itemAdd);
                await _context.SaveChangesAsync();

                result = itemAdd.Usuarioid;

                // Método con transacción

                /*
                var newId = _context.SbsUsuario.DefaultIfEmpty().Max(r => r == null ? 0 : r.Usuarioid) + 1;

                var itemAdd = new SbsUsuario
                {
                    Usuarioid = newId,
                    Rolid = param.Rolid,
                    Codigousuario = param.Codigousuario,
                    Clavesecreta = param.Clavesecreta,
                    Email = param.Email,
                    Apellidopaterno = param.Apellidopaterno,
                    Apellidomaterno = param.Apellidomaterno,
                    Primernombre = param.Primernombre,
                    Segundonombre = param.Segundonombre,
                    Alias = param.Alias,
                    Primeravezlogin = true,
                    Activo = true
                };

                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {

                        _context.SbsUsuario.Add(itemAdd);
                        await _context.SaveChangesAsync();

                        dbContextTransaction.Commit();

                        result = itemAdd.Usuarioid;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
                */

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public async Task<int> ModificarUsuario(SbsUsuario param)
        {
            int result = 0;

            try
            {

                var itemUpdate = _context.SbsUsuario.SingleOrDefault(u => u.Usuarioid == param.Usuarioid);
                if (itemUpdate != null)
                {
                    // actualización masiva

                    //List<SbsUsuario> modifiedUsers = new List<SbsUsuario>();
                    //modifiedUsers.Add(param);
                    //_context.UpdateRange(modifiedUsers);


                    // campos a actualizar
                    itemUpdate.Rolid = param.Rolid;
                    itemUpdate.Codigousuario = param.Codigousuario;
                    itemUpdate.Clavesecreta = param.Clavesecreta;
                    itemUpdate.Email = param.Email;
                    itemUpdate.Primernombre = param.Primernombre;
                    itemUpdate.Segundonombre = param.Segundonombre;
                    itemUpdate.Apellidopaterno = param.Apellidopaterno;
                    itemUpdate.Apellidomaterno = param.Apellidomaterno;
                    itemUpdate.Alias = param.Alias;

                    // actualizar
                    _context.SbsUsuario.Update(itemUpdate);
                    _context.Entry(itemUpdate).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    result = itemUpdate.Usuarioid;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public async Task<int> EliminarUsuario(int usuarioId)
        {
            int result = 0;

            try
            {
                var itemToRemove = _context.SbsUsuario.SingleOrDefault(x => x.Usuarioid == usuarioId);
                if (itemToRemove != null)
                {
                    _context.SbsUsuario.Remove(itemToRemove);
                    _context.Entry(itemToRemove).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        #region "Metodos privados"
        private List<BusquedaUsuarioDto> RetornarDtoBusqueda(List<SbsUsuario> paramLista)
        {
            List<BusquedaUsuarioDto> listaDto = null;

            if (paramLista != null)
            {
                listaDto = new List<BusquedaUsuarioDto>();

                paramLista.ForEach(delegate (SbsUsuario e)
                {
                    BusquedaUsuarioDto objDto = new BusquedaUsuarioDto
                    {
                        UsuarioId = e.Usuarioid,
                        CodigoUsuario = e.Codigousuario,
                        PrimerNombre = e.Primernombre,
                        SegundoNombre = e.Segundonombre,
                        ApellidoPaterno = e.Apellidopaterno,
                        ApellidoMaterno = e.Apellidomaterno,
                        Email = e.Email
                    };
                    listaDto.Add(objDto);
                });
            }
            return listaDto;
        }
        #endregion

    }
}
