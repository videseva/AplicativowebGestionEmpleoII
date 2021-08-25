using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Entidad
{
    public class Postulacion 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostulacionId { get; set;}

        [ForeignKey("Aspirante")]
        public int UsuarioId { get; set; }
        public Aspirante Aspirante { get; set;}
        
        [ForeignKey("Oferta")]
        public int OfertaId { get; set;}
        public Oferta Oferta { get; set;}
        
        public DateTime FechaPostulacion { get; set;}
        public int Estado { get; set;}
        public int EstadoPostulacion { get; set;}
         public List<Aspirante> Aspirantes{ get; set;}
    }
}