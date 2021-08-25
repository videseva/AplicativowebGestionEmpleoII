using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class InformacionLaboralService
    {
        private readonly GestionEmpleoContext _context;
        public InformacionLaboralService(GestionEmpleoContext context)
        {
            _context = context;
        }
        
        public GuardarInformacionLaboralResponse GuardarInformacionLaboral(InformacionLaboral informacionLaboral)
        {
            try
            {
                var _informacionLaboral = _context.ListadoInformacionLaboral.Find(informacionLaboral.InformacionLaboralId);
                if (_informacionLaboral == null)
                {
                    informacionLaboral.Estado=1;
                    _context.ListadoInformacionLaboral.Add(informacionLaboral);
                    _context.SaveChanges();
                    return new GuardarInformacionLaboralResponse(informacionLaboral);
                }
                 return new GuardarInformacionLaboralResponse("La informacion Laboral ya se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarInformacionLaboralResponse("Ocurrieron algunos Errores:" + e.Message);   
            }
        }

        public ConsultarInformacionLaboralResponse Consultar()
        {
            try
            {
                var listadosInformacionLaboral = _context.ListadoInformacionLaboral.ToList();
                return new ConsultarInformacionLaboralResponse(listadosInformacionLaboral);
            }
            catch (Exception e)
            {
                return new ConsultarInformacionLaboralResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        
        public ConsultarInformacionLaboralResponse ConsultarId(int id)
        {
            try
            {
                var listadoInformacionLaboralId = _context.ListadoInformacionLaboral.Where(d => d.UsuarioId == id).ToList();
                return new ConsultarInformacionLaboralResponse(listadoInformacionLaboralId);
            }
            catch (Exception e)
            {
                return new ConsultarInformacionLaboralResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public GuardarInformacionLaboralResponse Modificar(InformacionLaboral informacionLaboralNueva)
        {
            try
            {
                var informacionLaboralVieja = _context.ListadoInformacionLaboral.Find(informacionLaboralNueva.InformacionLaboralId);
                if(informacionLaboralVieja != null){
                    informacionLaboralVieja.Empresa = informacionLaboralNueva.Empresa;
                    informacionLaboralVieja.Cargo = informacionLaboralNueva.Cargo;
                    informacionLaboralVieja.Estado = informacionLaboralNueva.Estado;
                    informacionLaboralVieja.FechaInicio = informacionLaboralNueva.FechaInicio;
                    informacionLaboralVieja.FechaFin = informacionLaboralNueva.FechaFin;
                    _context.ListadoInformacionLaboral.Update(informacionLaboralVieja);
                    
                    _context.SaveChanges();
                }
                return new GuardarInformacionLaboralResponse(informacionLaboralVieja);
            }
            catch (Exception e)
            {
                return new GuardarInformacionLaboralResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        //Response
        public class ConsultarInformacionLaboralResponse
        {
            public List<InformacionLaboral> InformacionLaboral { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarInformacionLaboralResponse(List<InformacionLaboral> informacionLaboral)
            {
                InformacionLaboral = informacionLaboral;
                Error = false;
            }

            public ConsultarInformacionLaboralResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class GuardarInformacionLaboralResponse
        {
            public InformacionLaboral InformacionLaboral  { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public GuardarInformacionLaboralResponse(InformacionLaboral informacionLaboral)
            {
                InformacionLaboral = informacionLaboral;
                Error = false;
            }

            public GuardarInformacionLaboralResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

    }
}
