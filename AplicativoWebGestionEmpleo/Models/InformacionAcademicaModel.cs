using System.Linq;
using System;
using Entidad;
using AspiranteModel.Model;
using System.Collections.Generic;

namespace InformacioAcademicaModel.Model
{
    public class InformacionAcademicaInputModel{
        public int InformacionAcademicaId { get; set;}
        public string Institucion { get; set;}
        public string TipoFormacion { get; set;}
        public string EstadoTipoFormacion { get; set;}
        public int Estado { get; set;}
        public DateTime FechaInicio { get; set;}
        public DateTime FechaFin { get; set;}
        public int UsuarioId { get; set;}
    }
    
    public class InformacionAcademicaViewModel : InformacionAcademicaInputModel{
        public InformacionAcademicaViewModel(InformacionAcademica informacionAcademica)
        {
            InformacionAcademicaId = informacionAcademica.InformacionAcademicaId;
            Institucion =informacionAcademica.Institucion;
            TipoFormacion =informacionAcademica.TipoFormacion;
            Estado =informacionAcademica.Estado;
            EstadoTipoFormacion = informacionAcademica.EstadoTipoFormacion;
            FechaInicio =informacionAcademica.FechaInicio;
            FechaFin =informacionAcademica.FechaFin;
            UsuarioId = informacionAcademica.UsuarioId;


        }

    }
    
}