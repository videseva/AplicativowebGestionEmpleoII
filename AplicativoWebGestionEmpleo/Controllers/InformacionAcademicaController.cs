using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using InformacioAcademicaModel.Model;
using AspiranteModel.Model;

    namespace AplicativoWebGestionEmpleo.controller 
    {
        [Route("api/[controller]")]
        [ApiController]

        public class InformacionAcademicaController : ControllerBase{
             private InformacionAcademicaService  _informacionAcademicaService;

            public InformacionAcademicaController (GestionEmpleoContext context)
            {
                _informacionAcademicaService = new InformacionAcademicaService(context);
            }

            //Api GET
            [HttpGet]
            public ActionResult<IEnumerable<InformacionAcademicaViewModel>>GetInformacionAcademica()
            {
                var response = _informacionAcademicaService.Consultar();
                if (!response.Error)
                {
                    var informacionAcademicaViewModel = response.InformacionAcademicas.Select(p => new InformacionAcademicaViewModel(p));
                    return Ok(informacionAcademicaViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            [HttpGet("{id}")]
            public ActionResult<IEnumerable<InformacionAcademicaViewModel>>GetInformacionAcademicaId(int id)
            {
               var response = _informacionAcademicaService.ConsultarId(id);
                if (!response.Error)
                {
                    var informacionAcademicaViewModel = response.InformacionAcademicas.Select(p => new InformacionAcademicaViewModel(p));
                    return Ok(informacionAcademicaViewModel);
                }
                return BadRequest(response.Mensaje);
            }
            [HttpPost]
            public ActionResult <InformacionAcademicaViewModel> PostInformacionAcademica(InformacionAcademicaInputModel informacionAcademicaInputModel)
            {   

                var informacionAcademica = MapearInformacionAcademica(informacionAcademicaInputModel);
                
                var response = _informacionAcademicaService.GuardarInformacionAcademica(informacionAcademica);
                if (!response.Error)
                {
                    var informacionAcademicaViewModel = new InformacionAcademicaViewModel(informacionAcademica);
                    return Ok(informacionAcademicaViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            private InformacionAcademica MapearInformacionAcademica(InformacionAcademicaInputModel informacionAcademicaInputModel){
               
                var _informacionAcademica= new InformacionAcademica(){     

                InformacionAcademicaId =informacionAcademicaInputModel.InformacionAcademicaId,
                Institucion =  informacionAcademicaInputModel.Institucion,
                TipoFormacion = informacionAcademicaInputModel.TipoFormacion,
                Estado = informacionAcademicaInputModel.Estado,
                FechaInicio = informacionAcademicaInputModel.FechaInicio,
                FechaFin = informacionAcademicaInputModel.FechaFin,
                UsuarioId = informacionAcademicaInputModel.UsuarioId,
                EstadoTipoFormacion = informacionAcademicaInputModel.EstadoTipoFormacion,
                };
                    return _informacionAcademica;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
            }

            [HttpPut("{id}")]
            public ActionResult<InformacionAcademicaViewModel> put(InformacionAcademicaInputModel informacionAcademicaInputModel)
                {
                var informacionAcademica = MapearInformacionAcademica(informacionAcademicaInputModel);
                var response = _informacionAcademicaService.Modificar(informacionAcademica);
                if (!response.Error)
                {
                    return Ok(response.InformacionAcademica);
                }
                return BadRequest(response.Mensaje);
            }
 
        }
        
    }