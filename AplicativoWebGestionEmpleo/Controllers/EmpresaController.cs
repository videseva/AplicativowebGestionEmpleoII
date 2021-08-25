using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using EmpresaModel.Model;

    namespace AplicativoWebGestionEmpleo.controller 
    {
        [Route("api/[controller]")]
        [ApiController]

        public class EmpresaController : ControllerBase{
             private EmpresaService _empresaService;

            public EmpresaController (GestionEmpleoContext context)
            {
                _empresaService = new EmpresaService(context);
            }

             [HttpPost]
            public ActionResult<EmpresaViewModel> PostEmpresa(EmpresaInputModel empresainput)
            {   

                var empresa = MapearEmpresa(empresainput);
                var response = _empresaService.GuardarEmpresa(empresa);
                if (!response.Error)
                {
                    var empresaViewModel = new EmpresaViewModel(empresa);
                    return Ok(empresaViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            //Api GET
            [HttpGet]
            public ActionResult<IEnumerable<EmpresaViewModel>>GetEmpresa()
            {
                var response = _empresaService.Consultar();
                if (!response.Error)
                {
                    var empresaViewModels = response.Empresas.Select(p => new EmpresaViewModel(p));
                    return Ok(empresaViewModels);
                }
                return BadRequest(response.Mensaje);
            }

            //Api GET --- api/Usuario/correo/{correo}/contrasena/{contrasena}
            //Api GET --- api/Usuario/correo/contrasena
            [HttpGet("correo/{correo}/contrasena/{contrasena}")]
            public ActionResult<IEnumerable<EmpresaViewModel>>GetUsuario(string correo, string contrasena)
            {
                var response = _empresaService.consultarLogin(correo,contrasena);
                if (!response.Error)
                {
                     var empresaViewModel = new EmpresaViewModel(response.Empresa);
                    return Ok(empresaViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            //Api Get ID
            [HttpGet("{id}")]
            public ActionResult<EmpresaViewModel> GetEmpresaId(int id)
            {
                var response = _empresaService.BuscarEmpresaPorId(id);
                if (!response.Error)
                {
                    var empresaViewModel = new EmpresaViewModel(response.Empresa);
                    return Ok(empresaViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            private Empresa MapearEmpresa(EmpresaInputModel empresainput){
                var _empresa = new Empresa(){                    
                    UsuarioId = empresainput.UsuarioId,
                    Nit = empresainput.Nit,
                    RazonSocial = empresainput.RazonSocial,
                    Telefono = empresainput.Telefono,
                    Ciudad = empresainput.Ciudad,
                    Correo = empresainput.Correo,
                    Contrasena = empresainput.Contrasena,
                    Descripcion = empresainput.Descripcion,
                    Direccion = empresainput.Direccion,
                    SitioWeb= empresainput.SitioWeb,
                };
                return _empresa;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
            }

            // PUT: api/Empresa/2
            [HttpPut("{id}")]
            public ActionResult<EmpresaViewModel> put(EmpresaInputModel empresainput)
                {
                var empresa = MapearEmpresa(empresainput);
                var response = _empresaService.Modificar(empresa);
                if (!response.Error)
                {
                    return Ok(response.Empresa);
                }
                return BadRequest(response.Mensaje);
            }

            // Delete: api/Empresa/2
           [HttpDelete("{id}")]
            public ActionResult<EmpresaViewModel> delete(int id)
            {
                var response = _empresaService.Eliminar(id);
                return Ok(response);
            }   
        }
    }

