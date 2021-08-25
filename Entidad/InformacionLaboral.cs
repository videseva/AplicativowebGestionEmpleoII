using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class InformacionLaboral
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InformacionLaboralId { get; set;}
        [ForeignKey("Aspirante")]
        public int UsuarioId { get; set; }
        public Aspirante Aspirante { get; set;}
        public string Empresa { get; set;}
        public string Cargo { get; set;}
        public int Estado { get; set;}
        public DateTime FechaInicio { get; set;}
        public DateTime FechaFin { get; set;}
    }
}