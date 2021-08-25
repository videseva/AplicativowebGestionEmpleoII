using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using AdministradorModel.Model;

    namespace AplicativoWebGestionEmpleo.controller 
    {
        [Route("api/[controller]")]
        [ApiController]

        public class AdministradorController : ControllerBase{
             private AdministradorService _administradorService;

            public AdministradorController (GestionEmpleoContext context)
            {
                _administradorService = new AdministradorService(context);
            }

            //Api GET
            [HttpGet]
            public ActionResult<IEnumerable<AdministradorViewModel>>GetAdministrador()
            {
                var response = _administradorService.Consultar();
                if (!response.Error)
                {
                    var administradorViewModel = response.Administradores.Select(p => new AdministradorViewModel(p));
                    return Ok(administradorViewModel);
                }
                return BadRequest(response.Mensaje);
            }

             [HttpPost]
            public ActionResult<AdministradorViewModel> PostPago(AdministradorInputModel administradorInputModel)
            {   

                var administrador = MapearAdministrador(administradorInputModel);
                var response = _administradorService.GuardarAdministrador(administrador);
                if (!response.Error)
                {
                    var administradorViewModel = new AdministradorViewModel(administrador);
                    return Ok(administradorViewModel);
                }
                return BadRequest(response.Mensaje);
            }
            private Administrador MapearAdministrador(AdministradorInputModel administradorInputModel){
                var _administrador = new Administrador(){                    
                    UsuarioId = administradorInputModel.UsuarioId,
                    Identificacion = administradorInputModel.Identificacion,
                    Nombres = administradorInputModel.Nombres,
                    Correo = administradorInputModel.Correo,
                    Contrasena = administradorInputModel.Contrasena,
                };
                return _administrador;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
            }

            //Api Get ID
            [HttpGet("{id}")]
            public ActionResult<AdministradorViewModel> GetAdministradorId(int id)
            {
                var response = _administradorService.BuscarAdministradorPorId(id);
                if (!response.Error)
                {
                    var administradorViewModel = new AdministradorViewModel(response.Administrador);
                    return Ok(administradorViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            // PUT: api/Empresa/2
            [HttpPut("{id}")]
            public ActionResult<AdministradorViewModel> put(AdministradorInputModel administradorInputModel)
                {
                var administrador = MapearAdministrador(administradorInputModel);
                var response = _administradorService.Modificar(administrador);
                if (!response.Error)
                {
                    return Ok(response.Administrador);
                }
                return BadRequest(response.Mensaje);
            }  
        }
    }

