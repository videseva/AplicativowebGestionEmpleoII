using System.Security.Cryptography.X509Certificates;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class InformacionAcademica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InformacionAcademicaId { get; set;}
        
         [ForeignKey("Aspirante")]
        public int UsuarioId { get; set; }
        public Aspirante Aspirante { get; set;}
        public string Institucion { get; set;}
        public string TipoFormacion { get; set;}
        public int Estado { get; set;}
        public string EstadoTipoFormacion { get; set;}
        public DateTime FechaInicio { get; set;}
        public DateTime FechaFin { get; set;}
    }
}