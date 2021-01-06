using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBS.ApplicationCore.DTO;
using SBS.ApplicationCore.Entities;
using SBS.ApplicationCore.Interfaces.Services;
using SBS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;

namespace SBS.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<Controller> _logger;
        private readonly IUsuarioService _usuarioService;

        /// <summary>
        /// UsuarioController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="usuarioService"></param>
        public UsuarioController
            (
            ILogger<Controller> logger,
            IUsuarioService usuarioService
            )
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// BuscarUsuario
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("Buscar")]
        public JsonResult BuscarUsuario([FromBody] FiltroBusquedaUsuarioDto param)
        {
            var success = true;
            List<BusquedaUsuarioDto> lista = null;

            try
            {
                lista = _usuarioService.BuscarUsuario(param).Result;
            }
            catch (Exception ex)
            {
                success = false;
                _logger.LogError(default(EventId), ex, ex.Message);
            }

            return Json(new
            {
                success,
                data = lista
            });
        }

        /// <summary>
        /// GrabarUsuario
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("Grabar")]
        public JsonResult GrabarUsuario([FromBody] SbsUsuario param)
        {
            var success = true;
            int result = 0;

            try
            {
                result = _usuarioService.GrabarUsuario(param).Result;
            }
            catch (Exception ex)
            {
                success = false;
                _logger.LogError(default(EventId), ex, ex.Message);
            }

            return Json(new
            {
                success,
                data = result
            });
        }

        /// <summary>
        /// EliminarUsuario
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("Eliminar")]
        public JsonResult EliminarUsuario([FromBody] SbsUsuario param)
        {
            var success = true;
            int result = 0;

            try
            {
                result = _usuarioService.EliminarUsuario(param.Usuarioid).Result;
            }
            catch (Exception ex)
            {
                success = false;
                _logger.LogError(default(EventId), ex, ex.Message);
            }

            return Json(new
            {
                success,
                data = result
            });
        }
    }
}
