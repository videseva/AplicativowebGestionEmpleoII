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
using PostulacionModel.Model;
namespace AplicativoWebGestionEmpleo.controller 
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class PostulacionController : ControllerBase{

        private PostulacionService _postulacionService;

        public PostulacionController (GestionEmpleoContext context)
        {
            _postulacionService = new PostulacionService(context);
        }

        
        [HttpPost]
        public ActionResult<InformacionPostulacionViewModel> PostPostulacion(PostulacionInputModel postulacionInput)
        {   
            var postulacion = MapearPostulacion(postulacionInput);
            var response = _postulacionService.GuardarPostulacion(postulacion);

            if (!response.Error)
            {
                var postulacionViewModel = new InformacionPostulacionViewModel(postulacion);
                return Ok(postulacionViewModel);
            }
            return BadRequest(response.Mensaje);
        }

        private Postulacion MapearPostulacion(PostulacionInputModel postulacionInput){
                
                var _postulacion = new Postulacion(){
                PostulacionId =postulacionInput.PostulacionId,
                UsuarioId =postulacionInput.UsuarioId,
                OfertaId =postulacionInput.OfertaId,
                FechaPostulacion =postulacionInput.FechaPostulacion,
                Estado =postulacionInput.Estado,
                EstadoPostulacion = postulacionInput.EstadoPostulacion,
                };
                return _postulacion;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
        } 

        //Api GET
        [HttpGet("{id}")]
       public ActionResult<IEnumerable<PostulacionViewModel>>GetPostulacionId(int id)
        {
             var response = _postulacionService.ConsultarId(id);
            if (!response.Error)
            {
                var postulacionViewModel = response.Postulaciones.Select(p => new PostulacionViewModel(p));
                return Ok(postulacionViewModel);
            }
            return BadRequest(response.Mensaje);
        }

        [HttpGet("PorOferta/{ofertaId}")]
        public ActionResult<IEnumerable<PostulacionOfertaViewModel>> GetPostulacionesOfertaId(int ofertaId)
        {
            var response = _postulacionService.ConsultarOfertaId(ofertaId);
            if (!response.Error)
            {
                var postulacionOfertaViewModel =  response.Postulaciones.Select(p => new PostulacionOfertaViewModel(p));
                return Ok(postulacionOfertaViewModel);
            }
            return BadRequest(response.Mensaje);
        }

        //Api GET
        [HttpGet]
        public ActionResult<IEnumerable<PostulacionViewModel>>GetPostulacion()
        {
            var response = _postulacionService.Consultar();
            if (!response.Error)
            {
                var postulacionViewModel = response.Postulaciones.Select(p => new PostulacionViewModel(p));
                return Ok(postulacionViewModel);
            }
            return BadRequest(response.Mensaje);
        }

            // PUT: api/Postulacion/2
        [HttpPut("{id}")]
        public ActionResult<PostulacionViewModel>put(PostulacionInputModel postulacionInput)
        {
            var postulacion = MapearPostulacion(postulacionInput);
            var response = _postulacionService.Eliminar(postulacion);
            if (!response.Error)
            {
                return Ok(response.Postulacion);
            }
            return BadRequest(response.Mensaje);
        }
  
     // PUT: api/Postulacion/2
        //Api GET correo/{correo}/contrasena/{contrasena}
        [HttpPut("postulacion/{id}/opcion/{opcion}")]

        public ActionResult<PostulacionViewModel>putseleccionAspirante(PostulacionInputModel postulacionInput, int opcion,int id)
        {
            var postulacion = MapearPostulacion(postulacionInput);
            var response = _postulacionService.SeleccionAspirante(opcion,postulacion);
            if (!response.Error)
            {
                return Ok(response.Postulacion);
            }
            return BadRequest(response.Mensaje);
        }
    }
}

