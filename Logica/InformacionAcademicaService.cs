using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class InformacionAcademicaService
    {
        private readonly GestionEmpleoContext _context;
        public InformacionAcademicaService(GestionEmpleoContext context)
        {
            _context = context;
        }
        
        public GuardarInformacionAcademicaResponse GuardarInformacionAcademica(InformacionAcademica informacionAcademica)
        {
            try
            {
                var _informacionAcademica = _context.ListadoInformacionAcademica.Find(informacionAcademica.InformacionAcademicaId);
                if (_informacionAcademica == null)
                {
                    informacionAcademica.Estado=1;
                    _context.ListadoInformacionAcademica.Add(informacionAcademica);
                    _context.SaveChanges();
                    return new GuardarInformacionAcademicaResponse(informacionAcademica);
                }
                 return new GuardarInformacionAcademicaResponse("La informacion academica ya se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarInformacionAcademicaResponse("Ocurrieron algunos Errores:" + e.Message);   
            }
        }

        public ConsultarInformacionAcademicaResponse Consultar()
        {
            try
            {
                var InformacionAcademicas = _context.ListadoInformacionAcademica.ToList();
                return new ConsultarInformacionAcademicaResponse(InformacionAcademicas);
            }
            catch (Exception e)
            {
                return new ConsultarInformacionAcademicaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        
        public ConsultarInformacionAcademicaResponse ConsultarId(int id)
        {
            try
            {
                var InformacionAcademicas = _context.ListadoInformacionAcademica.Where(d => d.UsuarioId == id).ToList();
                return new ConsultarInformacionAcademicaResponse(InformacionAcademicas);
            }
            catch (Exception e)
            {
                return new ConsultarInformacionAcademicaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public GuardarInformacionAcademicaResponse Modificar(InformacionAcademica informacionAcademicanueva)
        {
            try
            {
                var informacionAcademicavieja = _context.ListadoInformacionAcademica.Find(informacionAcademicanueva.InformacionAcademicaId);
                if(informacionAcademicavieja != null){
                    informacionAcademicavieja.Institucion = informacionAcademicanueva.Institucion;
                    informacionAcademicavieja.TipoFormacion = informacionAcademicanueva.TipoFormacion;
                    informacionAcademicavieja.FechaInicio = informacionAcademicanueva.FechaInicio;
                    informacionAcademicavieja.FechaFin = informacionAcademicanueva.FechaFin;
                    informacionAcademicavieja.Estado = informacionAcademicanueva.Estado;
                     informacionAcademicavieja.EstadoTipoFormacion = informacionAcademicanueva.EstadoTipoFormacion;
                    _context.ListadoInformacionAcademica.Update(informacionAcademicavieja);
                    
                    _context.SaveChanges();
                }
                return new GuardarInformacionAcademicaResponse(informacionAcademicavieja);
            }
            catch (Exception e)
            {
                return new GuardarInformacionAcademicaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        //Response
        public class ConsultarInformacionAcademicaResponse
        {
            public List<InformacionAcademica> InformacionAcademicas { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarInformacionAcademicaResponse(List<InformacionAcademica> informacionAcademicas)
            {
                InformacionAcademicas = informacionAcademicas;
                Error = false;
            }

            public ConsultarInformacionAcademicaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class GuardarInformacionAcademicaResponse
        {
            public InformacionAcademica InformacionAcademica  { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public GuardarInformacionAcademicaResponse(InformacionAcademica informacionAcademica)
            {
                InformacionAcademica = informacionAcademica;
                Error = false;
            }

            public GuardarInformacionAcademicaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

    }
}
