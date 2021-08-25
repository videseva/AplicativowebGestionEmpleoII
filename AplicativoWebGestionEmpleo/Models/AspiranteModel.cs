using System.Linq;
using System;
using Entidad;
using System.Collections.Generic;

namespace AspiranteModel.Model
{
    public class AspiranteInputModel{
         public int Identificacion { get; set;}
        public string Nombres { get; set;}
        public  string Apellidos { get; set;}
        public  string Ciudad { get; set;}
        public  string Telefono { get; set;}
        public  string Genero { get; set;}
        public  int Edad { get; set;}
        public  string AnoExperiencia { get; set;}
        public  string DiponibilidadViajar { get; set;}
        public  string DisponibilidadCambioResidendia { get; set;}
        public string Correo { get; set;}
        public string Contrasena { get; set;}
        public int UsuarioId { get; set;}
        public int TipoUsuario { get ; set;}// 1 = admin , 2 =empresa , 3 = aspirante,

        public string TituloProfesional { get; set;}
        public string EstadoCivil { get; set;}
        public string Descripcion { get; set;}
        public int Salario { get; set;}
        public string DisponibilidadViajar{ get; set;}
    }
    
     public class AspiranteViewModel{
         public int Identificacion { get; set;}
        public string Nombres { get; set;}
        public  string Apellidos { get; set;}
        public  string Ciudad { get; set;}
        public  string Telefono { get; set;}
        public  string Genero { get; set;}
        public  int Edad { get; set;}
        public  string AnoExperiencia { get; set;}
        public  string DiponibilidadViajar { get; set;}
        public  string DisponibilidadCambioResidendia { get; set;}
        public  int Estado { get; set;}
        public string Correo { get; set;}
        public int UsuarioId { get; set;}
        public int TipoUsuario { get ; set;}// 1 = admin , 2 =empresa , 3 = aspirante,

        public string TituloProfesional { get; set;}
        public string EstadoCivil { get; set;}
        public string Descripcion { get; set;}
        public int Salario { get; set;}
        public string DisponibilidadViajar{ get; set;}

        public AspiranteViewModel(Aspirante aspirante)
        {
            Identificacion =aspirante.Identificacion;
            Nombres = aspirante.Nombres;
            Apellidos = aspirante.Apellidos;
            Ciudad = aspirante.Ciudad;
            Telefono = aspirante.Telefono;
            Genero = aspirante.Genero;
            Edad = aspirante.Edad;
            AnoExperiencia = aspirante.AnoExperiencia;
            DiponibilidadViajar= aspirante.DiponibilidadViajar;
            DisponibilidadCambioResidendia  = aspirante.DisponibilidadCambioResidendia;
            Correo = aspirante.Correo;
            TipoUsuario = aspirante.TipoUsuario;
            UsuarioId = aspirante.UsuarioId;
            Estado = aspirante.Estado;
            TituloProfesional = aspirante.TituloProfesional;
            EstadoCivil = aspirante.EstadoCivil;
            Descripcion = aspirante.Descripcion;
            Salario = aspirante.Salario;
            DisponibilidadViajar = aspirante.DiponibilidadViajar;
        }
    }

    public class InformacionAspiranteViewModel: AspiranteInputModel{
             
       

    public InformacionAspiranteViewModel(Aspirante aspirante)
    {
            Identificacion =aspirante.Identificacion;
            Nombres = aspirante.Nombres;
            Apellidos = aspirante.Apellidos;
            Ciudad = aspirante.Ciudad;
            Telefono = aspirante.Telefono;
            Genero = aspirante.Genero;
            Edad = aspirante.Edad;
            AnoExperiencia = aspirante.AnoExperiencia;
            DiponibilidadViajar= aspirante.DiponibilidadViajar;
            DisponibilidadCambioResidendia  = aspirante.DisponibilidadCambioResidendia;
            Correo = aspirante.Correo;
            TipoUsuario = aspirante.TipoUsuario;
            UsuarioId = aspirante.UsuarioId;
            TituloProfesional = aspirante.TituloProfesional;
            EstadoCivil = aspirante.EstadoCivil;
            Descripcion = aspirante.Descripcion;
            Salario = aspirante.Salario;
            DisponibilidadViajar = aspirante.DiponibilidadViajar;
        }
    }
}