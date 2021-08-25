using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using AspiranteModel.Model;

    namespace AplicativoWebGestionEmpleo.controller 
    {
        [Route("api/[controller]")]
        [ApiController]

        public class AspiranteController : ControllerBase{
             private AspiranteService _aspiranteService;

            public AspiranteController (GestionEmpleoContext context)
            {
                _aspiranteService = new AspiranteService(context);
            }

            //Api GET
            [HttpGet]
            public ActionResult<IEnumerable<AspiranteViewModel>>GetAspirante()
            {
                var response = _aspiranteService.Consultar();
                if (!response.Error)
                {
                    var aspiranteViewModels = response.Aspirantes.Select(p => new AspiranteViewModel(p));
                    return Ok(aspiranteViewModels);
                }
                return BadRequest(response.Mensaje);
            }

             [HttpPost]
            public ActionResult<AspiranteViewModel> PostAspirante(AspiranteInputModel aspiranteinput)
            {   
                var aspirante = MapearAspirante(aspiranteinput);
                var response = _aspiranteService.GuardarAspirante(aspirante);
                if (!response.Error)
                {
                    var aspiranteViewModel = new AspiranteViewModel(aspirante);
                    return Ok(aspiranteViewModel);
                }
                return BadRequest(response.Mensaje);
            }
            private Aspirante MapearAspirante(AspiranteInputModel aspiranteinput){
                var _aspirante = new Aspirante(){       
                    Identificacion =aspiranteinput.Identificacion,
                    Nombres = aspiranteinput.Nombres,
                    Apellidos = aspiranteinput.Apellidos,
                    Ciudad = aspiranteinput.Ciudad,
                    Telefono = aspiranteinput.Telefono,
                    Genero = aspiranteinput.Genero,
                    Edad = aspiranteinput.Edad,
                    AnoExperiencia = aspiranteinput.AnoExperiencia,
                    DiponibilidadViajar= aspiranteinput.DiponibilidadViajar,
                    DisponibilidadCambioResidendia  = aspiranteinput.DisponibilidadCambioResidendia,
                    Correo = aspiranteinput.Correo,
                    Contrasena = aspiranteinput.Contrasena,
                    UsuarioId = aspiranteinput.UsuarioId,
                    TipoUsuario = aspiranteinput.TipoUsuario,

                    TituloProfesional = aspiranteinput.TituloProfesional,
                    EstadoCivil = aspiranteinput.EstadoCivil,
                    Descripcion = aspiranteinput.Descripcion,
                    Salario = aspiranteinput.Salario,
                    DisponibilidadViajar = aspiranteinput.DiponibilidadViajar,
                };
                return _aspirante;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
            }

            //Api Get ID
            [HttpGet("{id}")]
            public ActionResult<AspiranteViewModel> GetAspiranteId(int id)
            {
                var response = _aspiranteService.BuscarAspiranteId(id);
                if (!response.Error)
                {
                    var aspiranteViewModel = new AspiranteViewModel(response.Aspirante);
                    return Ok(aspiranteViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            //Api GET --- api/Usuario/correo/{correo}/contrasena/{contrasena}
            //Api GET --- api/Usuario/correo/contrasena
            [HttpGet("correo/{correo}/contrasena/{contrasena}")]
            public ActionResult<IEnumerable<AspiranteViewModel>>GetUsuario(string correo, string contrasena)
            {
                var response = _aspiranteService.consultarLogin(correo,contrasena);
                if (!response.Error)
                {
                     var aspiranteViewModel = new AspiranteViewModel(response.Aspirante);
                    return Ok(aspiranteViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            // PUT: api/Empresa/2
            [HttpPut("{id}")]
            public ActionResult<AspiranteViewModel> put(AspiranteInputModel aspiranteinput)
            {
                var aspirante = MapearAspirante(aspiranteinput);
                var response = _aspiranteService.Modificar(aspirante);
                if (!response.Error)
                {
                    return Ok(response.Aspirante);
                }
                return BadRequest(response.Mensaje);
            }

            // Delete: api/Empresa/2
           [HttpDelete("{id}")]
            public ActionResult<AspiranteViewModel> delete(int id)
            {
                var response = _aspiranteService.Eliminar(id);
                return Ok(response);
            }   
        }
    }

