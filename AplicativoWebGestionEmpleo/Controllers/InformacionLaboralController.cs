using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using InformacionLaboralModel.Model;
using AspiranteModel.Model;

    namespace AplicativoWebGestionEmpleo.controller 
    {
        [Route("api/[controller]")]
        [ApiController]

        public class InformacionLaboralController : ControllerBase{
             private InformacionLaboralService  _informacionLaboralService;

            public InformacionLaboralController (GestionEmpleoContext context)
            {
                _informacionLaboralService = new InformacionLaboralService(context);
            }

            //Api GET
            [HttpGet]
            public ActionResult<IEnumerable<InformacionLaboralViewModel>>GetInformacionLaboral()
            {
                var response = _informacionLaboralService.Consultar();
                if (!response.Error)
                {
                    var informacionLaboralViewModel = response.InformacionLaboral.Select(p => new InformacionLaboralViewModel(p));
                    return Ok(informacionLaboralViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            [HttpGet("{id}")]
            public ActionResult<IEnumerable<InformacionLaboralViewModel>>GetInformacionLaboralId(int id)
            {
               var response = _informacionLaboralService.ConsultarId(id);
                if (!response.Error)
                {
                    var informacionLaboralViewModel = response.InformacionLaboral.Select(p => new InformacionLaboralViewModel(p));
                    return Ok(informacionLaboralViewModel);
                }
                return BadRequest(response.Mensaje);
            }
            [HttpPost]
            public ActionResult <InformacionLaboralViewModel> PostInformacionLaboral(InformacionLaboralInputModel informacionLaboralInputModel)
            {   

                var informacionLaboral = MapearInformacionLaboral(informacionLaboralInputModel);
                
                var response = _informacionLaboralService.GuardarInformacionLaboral(informacionLaboral);

                if (!response.Error)
                {
                    var informacionLaboralViewModel = new InformacionLaboralViewModel(informacionLaboral);
                    return Ok(informacionLaboralViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            private InformacionLaboral MapearInformacionLaboral(InformacionLaboralInputModel informacionLaboralInputModel){
               
                var _informacionLaboral = new InformacionLaboral(){     

                InformacionLaboralId = informacionLaboralInputModel.InformacionLaboralId,
                UsuarioId = informacionLaboralInputModel.UsuarioId,
                Empresa = informacionLaboralInputModel.Empresa,
                Cargo = informacionLaboralInputModel.Cargo,
                Estado = informacionLaboralInputModel.Estado,
                FechaInicio = informacionLaboralInputModel.FechaInicio,
                FechaFin =informacionLaboralInputModel.FechaFin,
                };
                    return _informacionLaboral;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
            }

            [HttpPut("{id}")]
            public ActionResult<InformacionLaboralViewModel> put(InformacionLaboralInputModel informacionLaboralInputModel)
                {
                var informacionLaboral = MapearInformacionLaboral(informacionLaboralInputModel);
                var response = _informacionLaboralService.Modificar(informacionLaboral);
                if (!response.Error)
                {
                    return Ok(response.InformacionLaboral);
                }
                return BadRequest(response.Mensaje);
            }
 
        }
        
    }