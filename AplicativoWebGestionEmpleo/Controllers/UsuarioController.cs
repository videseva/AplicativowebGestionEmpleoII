
using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using UsuarioModel.Model;

    namespace AplicativoWebGestionEmpleo.controller 
    {
        [Route("api/[controller]")]
        [ApiController]

        public class UsuarioController : ControllerBase{
             private UsuarioService _usuarioService;

            public UsuarioController (GestionEmpleoContext context)
            {
                _usuarioService = new UsuarioService(context);
            }

            //Api GET
            [HttpGet]
            public ActionResult<IEnumerable<UsuarioViewModel>>GetUsuarios()
            {
                var response = _usuarioService.Consultar();
                if (!response.Error)
                {
                    var usuarioViewModel = response.Usuarios.Select(p => new UsuarioViewModel(p));
                    return Ok(usuarioViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            //Api GET --- api/Usuario/correo/{correo}/contrasena/{contrasena}
             //Api GET --- api/Usuario/correo/contrasena
             [HttpGet("correo/{correo}/contrasena/{contrasena}")]
            public ActionResult<IEnumerable<UsuarioViewModel>>GetUsuario(string correo, string contrasena)
            {
                var response = _usuarioService.consultarLogin(correo,contrasena);
                if (!response.Error)
                {
                    var usuarioViewModel = new UsuarioViewModel(response.Usuario);
                    return Ok(usuarioViewModel);
                }
                return BadRequest(response.Mensaje);
            }
        }
    }