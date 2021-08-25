using System.Xml.XPath;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica {


    public class PostulacionService {
    
        private readonly GestionEmpleoContext _context;
        public PostulacionService(GestionEmpleoContext context)
        {
            _context = context;
        }

        public GuardarPostulacionResponse GuardarPostulacion(Postulacion postulacion)
        {
            try
            {
                var _postulacion = _context.Postulaciones.Where(d => d.OfertaId == postulacion.OfertaId).FirstOrDefault();;

                if (_postulacion == null)
                {
                    var _aspirante = _context.Aspirantes.Find(postulacion.UsuarioId);
                    if(_aspirante == null){
                        return new GuardarPostulacionResponse("El aspirante no se encuntra registrada");
                    }
                    postulacion.Estado =1;
                    postulacion.EstadoPostulacion=1;
                    _context.Postulaciones.Add(postulacion);
                    _context.SaveChanges();
                    return new GuardarPostulacionResponse(postulacion);
                }
                 return new GuardarPostulacionResponse("La postulacion ya se encuentra registrada ");
            }
            catch (Exception e)
            {
                return new GuardarPostulacionResponse("Ocurrieron algunos Errores:" + e.Message);   
            }

        }

    
        public ConsultarPostulacionResponse ConsultarOfertaId(int id){
            try
            {
                var _Postulaciones = _context.Postulaciones.Where(d => d.OfertaId == id).Include(x => x.Aspirante).Include(a => a.Oferta).ToList();
                return new ConsultarPostulacionResponse(_Postulaciones);
            }
            catch (Exception e)
            {
                return new ConsultarPostulacionResponse("Ocurriern algunos Errores:   " + e.Message);
            }
        }
        public ConsultarPostulacionResponse Consultar(){
            try
            {
                var _Postulaciones = _context.Postulaciones.Include(x => x.Aspirante).Include(a => a.Oferta).ToList();
                return new ConsultarPostulacionResponse(_Postulaciones);
            }
            catch (Exception e)
            {
                return new ConsultarPostulacionResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }
        
        public ConsultarPostulacionResponse ConsultarId(int id){
            try
            {
                var _Postulaciones = _context.Postulaciones.Where(d => d.UsuarioId == id && d.Estado == 1).Include(x => x.Aspirante).Include(o => o.Oferta).ToList();
                return new ConsultarPostulacionResponse(_Postulaciones);
            }
            catch (Exception e)
            {
                return new ConsultarPostulacionResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public GuardarPostulacionResponse Eliminar(Postulacion postulacionNueva){
            try
            {
                var postulacionVieja = _context.Postulaciones.Find(postulacionNueva.PostulacionId);
                if(postulacionVieja != null){
                    postulacionVieja.Estado = 2;
                    _context.Postulaciones.Update(postulacionVieja);
                    
                    _context.SaveChanges();
                }
                return new GuardarPostulacionResponse(postulacionVieja);
            }
            catch (Exception e)
            {
                return new GuardarPostulacionResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }


        public GuardarPostulacionResponse SeleccionAspirante(int opcion,Postulacion postulacionNueva){
            try
            {
                var postulacionVieja = _context.Postulaciones.Find(postulacionNueva.PostulacionId);
                
                if(postulacionVieja != null){
                    if(opcion == 2){
                    //Postulacion seleccionada
                    postulacionVieja.EstadoPostulacion = 2;
                    
                    }else{
                    //Postulacion rechazada
                    postulacionVieja.EstadoPostulacion = 3;
                }
                _context.Postulaciones.Update(postulacionVieja);
                    _context.SaveChanges();
                    return new GuardarPostulacionResponse(postulacionVieja);
            }
                    return new GuardarPostulacionResponse("POSTULACION NO ENCONTRADA");
            }
            catch (Exception e)
            {
                return new GuardarPostulacionResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }
        
        //Response
        public class GuardarPostulacionResponse{
            public Postulacion Postulacion { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public GuardarPostulacionResponse(Postulacion postulacion)
            {
                Postulacion = postulacion;
                Error = false;
            }

            public GuardarPostulacionResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class ConsultarPostulacionResponse
        {
            public List<Postulacion> Postulaciones { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarPostulacionResponse(List<Postulacion> postulaciones)
            {
                Postulaciones = postulaciones;
                Error = false;
            }

            public ConsultarPostulacionResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    
    }
}