using System.Linq;
using System;
using Entidad;
using System.Collections.Generic;
using OfertaModel.Model;
using AspiranteModel.Model;

namespace PostulacionModel.Model
{
    public class PostulacionInputModel{

        public int PostulacionId { get; set;}
        public int UsuarioId { get; set; }
        public int OfertaId { get; set;}
        public DateTime FechaPostulacion { get; set;}
        public int Estado { get; set;}
           public int EstadoPostulacion { get; set;}
    }

    public class PostulacionViewModel :PostulacionInputModel {
        public  InformacionAspiranteViewModel Aspirante { get; set; }
         public OfertaSimpleViewModel Oferta { get; set; }
        public PostulacionViewModel(Postulacion postulacion){
             Aspirante =  new InformacionAspiranteViewModel(postulacion.Aspirante);
             Oferta =  new OfertaSimpleViewModel(postulacion.Oferta);
            PostulacionId =postulacion.PostulacionId;
            UsuarioId =postulacion.UsuarioId;
            OfertaId =postulacion.OfertaId;
            FechaPostulacion =postulacion.FechaPostulacion;
            Estado =postulacion.Estado;
            EstadoPostulacion= postulacion.EstadoPostulacion;
        }
    }

    public class PostulacionOfertaViewModel :PostulacionInputModel {
        public  AspiranteViewModel Aspirante { get; set; }
        

        public PostulacionOfertaViewModel(Postulacion postulacion){
            Aspirante =  new AspiranteViewModel(postulacion.Aspirante);
           
            PostulacionId =postulacion.PostulacionId;
            UsuarioId =postulacion.UsuarioId;
            OfertaId =postulacion.OfertaId;
            FechaPostulacion =postulacion.FechaPostulacion;
            Estado =postulacion.Estado;
            EstadoPostulacion= postulacion.EstadoPostulacion;
        }
    }

    public class InformacionPostulacionViewModel :PostulacionInputModel {


        public InformacionPostulacionViewModel(Postulacion postulacion){
            PostulacionId =postulacion.PostulacionId;
            UsuarioId =postulacion.UsuarioId;
            OfertaId= postulacion.OfertaId;
            FechaPostulacion =postulacion.FechaPostulacion;
            Estado =postulacion.Estado;
            EstadoPostulacion= postulacion.EstadoPostulacion;
        }
    }
}