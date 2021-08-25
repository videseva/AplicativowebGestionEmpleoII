using System.Collections;
using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using OfertaModel.Model;
using EmpresaModel.Model;
namespace AplicativoWebGestionEmpleo.controller 
    {
        
        [Route("api/[controller]")]
        [ApiController]

        public class OfertaController : ControllerBase{

             private OfertaService _ofertaService;

            public OfertaController (GestionEmpleoContext context)
            {
                _ofertaService = new OfertaService(context);
            }

            [HttpPost]
            public ActionResult<OfertaViewModel> PostOferta(OfertaInputModel ofertainput)
            {   
                var oferta = MapearOferta(ofertainput);

                var response = _ofertaService.GuardarOferta(oferta);

                if (!response.Error)
                {
                    var ofertaViewModel = new OfertaViewModel(oferta);
                    return Ok(ofertaViewModel);
                }
                return BadRequest(response.Mensaje);
            }
            private Oferta MapearOferta(OfertaInputModel ofertainput){
                var _oferta = new Oferta(){  
                    OfertaId =ofertainput.OfertaId,
                    Resumen =ofertainput.Resumen,
                    Estado =ofertainput.Estado,
                    Salario =ofertainput.Salario,
                    Cargo =ofertainput.Cargo,
                    TipoTrabajo = ofertainput.TipoTrabajo,
                    AnoExperiencia = ofertainput.AnoExperiencia,
                    DiponibilidadViajar = ofertainput.DiponibilidadViajar,
                    DisponibilidadCambioResidendia = ofertainput.DisponibilidadCambioResidendia,
                    UsuarioId = ofertainput.UsuarioId,
                    
                };
                return _oferta;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
            } 
            //Api GET
            [HttpGet("{id}")]
            public IEnumerable<OfertaViewModel>GetOferta(int id)
            {
                var response = _ofertaService.Consultar(id).Select(p => new OfertaViewModel(p));
                 return response;
            }

            [HttpGet("{id}/Postulaciones")]
            public ActionResult<OfertaConPostulacionViewModel> GetOfertasConPostulaciones(int id)
            {
                var response = _ofertaService.BuscarOfertasConPostulacionesporId(id);
                if (!response.Error)
                {
                    var ofertaConPostulacionViewModel = new OfertaConPostulacionViewModel(response.Oferta);
                    return Ok(ofertaConPostulacionViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            //Api GET
            [HttpGet]
            public ActionResult<IEnumerable<OfertaViewModel>>GetOfertas(){
            
                var response = _ofertaService.ConsultarTodasOfertas();
                if (!response.Error)
                {
                    var ofertaViewModel = response.Ofertas.Select(p => new OfertaViewModel(p));
                    return Ok(ofertaViewModel);
                }
                return BadRequest(response.Mensaje);
            }

             // PUT: api/Oferta/2
            [HttpPut("{id}")]
            public ActionResult<OfertaViewModel> put( OfertaInputModel ofertainput)
            {
                var oferta = MapearOferta(ofertainput);
                var response = _ofertaService.Eliminar(oferta);
                if (!response.Error)
                {
                    return Ok(response.Oferta);
                }
                return BadRequest(response.Mensaje);
            }
        }

    }

