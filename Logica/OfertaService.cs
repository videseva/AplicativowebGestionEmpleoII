using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class OfertaService
    {
        
    
        private readonly GestionEmpleoContext _context;
        public OfertaService(GestionEmpleoContext context)
        {
            _context = context;
        }
        
        public GuardarOfertaResponse GuardarOferta(Oferta oferta)
        {
            try
            {
                var _oferta = _context.Ofertas.Find(oferta.OfertaId);

                if (_oferta == null)
                {
                    var _empresa = _context.Empresas.Find(oferta.UsuarioId);
                    if(_empresa == null){
                        return new GuardarOfertaResponse("La empresa no se encuntra registrada");
                    }
                    oferta.Estado =1;
                    _context.Ofertas.Add(oferta);
                    _context.SaveChanges();
                    return new GuardarOfertaResponse(oferta);
                }
                 return new GuardarOfertaResponse("La oferta ya se encuentra registrada ");
            }
            catch (Exception e)
            {
                return new GuardarOfertaResponse("Ocurrieron algunos Errores:" + e.Message);   
            }
        }

        public  List<Oferta> Consultar(int id){
               List<Oferta> ofertas = _context.Ofertas.Where(d => d.UsuarioId == id && d.Estado == 1).Include(x => x.Empresa).ToList();
                return ofertas;
        }

        public ConsultarOfertasResponse ConsultarTodasOfertas()
        {
            try
            {
                var Ofertas = _context.Ofertas.Include(x => x.Empresa).ToList();
                return new ConsultarOfertasResponse(Ofertas);
            }
            catch (Exception e)
            {
                return new ConsultarOfertasResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public GuardarOfertaResponse Eliminar(Oferta ofertanueva)
        {
            try
            {
                var ofertaVieja = _context.Ofertas.Find(ofertanueva.OfertaId);
                if(ofertaVieja != null){
                ofertaVieja.Estado = 0;
                    _context.Ofertas.Update(ofertaVieja);
                    _context.SaveChanges();
                }
                return new GuardarOfertaResponse(ofertaVieja);
            }
            catch (Exception e)
            {
                return new GuardarOfertaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }
        
        public GuardarOfertaResponse BuscarOfertaPorId(int id)
        {
            try
            {
                var oferta = _context.Ofertas.Find(id);
                
                if (oferta != null)
                {
                    return new GuardarOfertaResponse(oferta);
                }
                return new GuardarOfertaResponse("La oferta consultada no existe");
            }
            catch (Exception e)
            {
                return new GuardarOfertaResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }

        public GuardarOfertaResponse BuscarOfertasConPostulacionesporId(int id){
            try
            {
                var Oferta = _context.Ofertas.Where(t => t.OfertaId == id).Include(p => p.Postulaciones).ThenInclude(x => x.Aspirante).FirstOrDefault();
                return new GuardarOfertaResponse(Oferta);
            }
            catch (Exception e)
            {
                return new GuardarOfertaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        

        //Response
        public class ConsultarOfertasResponse
        {
            public List<Oferta> Ofertas { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarOfertasResponse(List<Oferta> ofertas)
            {
                Ofertas = ofertas;
                Error = false;
            }

            public ConsultarOfertasResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class GuardarOfertaResponse
        {
            public Oferta Oferta  { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public GuardarOfertaResponse(Oferta oferta)
            {
                Oferta = oferta;
                Error = false;
            }

            public GuardarOfertaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        
    }
   
}
