using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Entidad
{
    public class Aspirante : Usuario
    {
        
        public int Identificacion { get; set;}
        public string Nombres { get; set;}
        public  string Apellidos { get; set;}
        public  string Ciudad { get; set;}
        public  string Telefono { get; set;}
        public  string Genero { get; set;}
        public  int Edad { get; set;}
        public  string AnoExperiencia { get; set;}
        public  string DiponibilidadViajar { get; set;}

        public string TituloProfesional { get; set;}
        public string EstadoCivil { get; set;}
        public string Descripcion { get; set;}
        public int Salario { get; set;}
        public string DisponibilidadViajar{ get; set;}

        public  string DisponibilidadCambioResidendia { get; set;}
        public List<InformacionLaboral> ExperienciaLaboral{ get; set;}
        public List<InformacionAcademica> FormacionAcademica{ get; set;}

    }
}