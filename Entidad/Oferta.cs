using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entidad
{
    public class Oferta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfertaId { get; set;}
        
        [ForeignKey("Empresa")]
        public int UsuarioId { get; set; }
        public Empresa Empresa { get; set;}

        public  string Resumen { get; set;}
        public  int Estado { get; set;}
        public  string Salario { get; set;}
        public  string Cargo { get; set;}
        public  string TipoTrabajo { get; set;}
        public  string AnoExperiencia { get; set;}
        public  string DiponibilidadViajar { get; set;}
        public  string DisponibilidadCambioResidendia { get; set;}
        public List<Postulacion> Postulaciones{ get; set;}

    }
}