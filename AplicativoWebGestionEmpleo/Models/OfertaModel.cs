using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System;
using Entidad;
using EmpresaModel.Model;
using PostulacionModel.Model;

using System.Collections.Generic;
namespace OfertaModel.Model
{
    public class OfertaInputModel{

        public int OfertaId { get; set;}
        public   int  UsuarioId { get; set; }
        public  string Resumen { get; set;}
        public  int Estado { get; set;}
        public  string Salario { get; set;}
        public  string Cargo { get; set;}
        public  string TipoTrabajo { get; set;}
        public  string AnoExperiencia { get; set;}
        public  string DiponibilidadViajar { get; set;}
        public  string DisponibilidadCambioResidendia { get; set;}
    }
    
     public class OfertaViewModel : OfertaInputModel {
         public  EmpresaViewModel Empresa { get; set; }

        public OfertaViewModel (Oferta oferta)
        {  
            OfertaId =oferta.OfertaId;
            Resumen =oferta.Resumen;
            Estado =oferta.Estado;
            Salario =oferta.Salario;
            Cargo =oferta.Cargo;
            TipoTrabajo = oferta.TipoTrabajo;
            AnoExperiencia = oferta.AnoExperiencia;
            DiponibilidadViajar = oferta.DiponibilidadViajar;
            DisponibilidadCambioResidendia = oferta.DisponibilidadCambioResidendia;
            UsuarioId = oferta.UsuarioId;
            Empresa =  new EmpresaViewModel(oferta.Empresa);
        }

    }
    
    public class OfertaSimpleViewModel : OfertaInputModel {

        public OfertaSimpleViewModel (Oferta oferta)
        {  
            OfertaId =oferta.OfertaId;
            Resumen =oferta.Resumen;
            Estado =oferta.Estado;
            Salario =oferta.Salario;
            Cargo =oferta.Cargo;
            TipoTrabajo = oferta.TipoTrabajo;
            AnoExperiencia = oferta.AnoExperiencia;
            DiponibilidadViajar = oferta.DiponibilidadViajar;
            DisponibilidadCambioResidendia = oferta.DisponibilidadCambioResidendia;
            UsuarioId = oferta.UsuarioId;
        }
    }

    public class OfertaConPostulacionViewModel: OfertaInputModel{
        
        public List<InformacionPostulacionViewModel> Postulaciones { get; set; }

        public OfertaConPostulacionViewModel (Oferta oferta){
            OfertaId =oferta.OfertaId;
            Resumen =oferta.Resumen;
            Estado =oferta.Estado;
            Salario =oferta.Salario;
            Cargo =oferta.Cargo;
            TipoTrabajo = oferta.TipoTrabajo;
            AnoExperiencia = oferta.AnoExperiencia;
            DiponibilidadViajar = oferta.DiponibilidadViajar;
            DisponibilidadCambioResidendia = oferta.DisponibilidadCambioResidendia;
            UsuarioId = oferta.UsuarioId;
            Postulaciones = oferta.Postulaciones.Select(p => new InformacionPostulacionViewModel(p)).ToList();
        }
    }
}