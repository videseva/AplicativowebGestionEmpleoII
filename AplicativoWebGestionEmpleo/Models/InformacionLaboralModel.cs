
using System.Linq;
using System;
using Entidad;
using InformacionLaboralModel.Model;
using System.Collections.Generic;

namespace InformacionLaboralModel.Model
{
    public class InformacionLaboralInputModel{

        public int InformacionLaboralId { get; set;}
        public int UsuarioId { get; set; }
        public string Empresa { get; set;}
        public string Cargo { get; set;}
        public int Estado { get; set;}
        public DateTime FechaInicio { get; set;}
        public DateTime FechaFin { get; set;}
    }
    
    public class InformacionLaboralViewModel : InformacionLaboralInputModel{
        
        public InformacionLaboralViewModel(InformacionLaboral informacionLaboral)
        {
            InformacionLaboralId = informacionLaboral.InformacionLaboralId;
            UsuarioId = informacionLaboral.UsuarioId;
            Empresa = informacionLaboral.Empresa;
            Cargo = informacionLaboral.Cargo;
            Estado = informacionLaboral.Estado;
            FechaInicio = informacionLaboral.FechaInicio;
            FechaFin =informacionLaboral.FechaFin;
        }

    }
    
}