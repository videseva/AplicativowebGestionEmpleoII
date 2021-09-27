using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class AspiranteService
    {
        private readonly GestionEmpleoContext _context;
        public AspiranteService(GestionEmpleoContext context)
        {
            _context = context;
        }
        
        public GuardarAspiranteResponse GuardarAspirante(Aspirante aspirante)
        {
            if(aspirante.Nombres != null && aspirante.Apellidos != null && aspirante.Identificacion >0){
                 try
            {
                var _aspirante = _context.Aspirantes.Find(aspirante.UsuarioId);
                if (_aspirante == null)
                {
                    aspirante.Estado = 1;
                    aspirante.TipoUsuario = 3;
                    _context.Aspirantes.Add(aspirante);
                    _context.SaveChanges();
                    return new GuardarAspiranteResponse(aspirante);
                }
                 return new GuardarAspiranteResponse("El aspirante ya se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarAspiranteResponse("Ocurrieron algunos Errores:" + e.Message);   
            }
            }else{
                 return new GuardarAspiranteResponse("Todos los campos son requeridos");
            }
           
        }

        public ConsultarAspiranteResponse Consultar()
        {
            try
            {
                var Aspirantes = _context.Aspirantes.ToList();
                return new ConsultarAspiranteResponse(Aspirantes);
            }
            catch (Exception e)
            {
                return new ConsultarAspiranteResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public GuardarAspiranteResponse Modificar(Aspirante aspiranteNuevo)
        {
            try
            {
                var aspiranteViejo = _context.Aspirantes.Find(aspiranteNuevo.UsuarioId);
                if(aspiranteViejo != null){
                    aspiranteViejo.Identificacion = aspiranteNuevo.Identificacion;
                    aspiranteViejo.Nombres = aspiranteNuevo.Nombres;
                    aspiranteViejo.Apellidos = aspiranteNuevo.Apellidos;
                    aspiranteViejo.Ciudad = aspiranteNuevo.Ciudad;
                    aspiranteViejo.Telefono = aspiranteNuevo.Telefono;
                    aspiranteViejo.Genero = aspiranteNuevo.Genero;
                    aspiranteViejo.Edad = aspiranteNuevo.Edad;
                    aspiranteViejo.AnoExperiencia = aspiranteNuevo.AnoExperiencia;
                    aspiranteViejo.DiponibilidadViajar = aspiranteNuevo.DiponibilidadViajar;
                    aspiranteViejo.DisponibilidadCambioResidendia = aspiranteNuevo.DisponibilidadCambioResidendia;
                    aspiranteViejo.Correo = aspiranteNuevo.Correo;
                    aspiranteViejo.TituloProfesional = aspiranteNuevo.TituloProfesional;
                    aspiranteViejo.EstadoCivil = aspiranteNuevo.EstadoCivil;
                    aspiranteViejo.Descripcion = aspiranteNuevo.Descripcion;
                    aspiranteViejo.Salario = aspiranteNuevo.Salario;
                    aspiranteViejo.Contrasena = aspiranteNuevo.Contrasena;
                    aspiranteViejo.DisponibilidadViajar = aspiranteNuevo.DiponibilidadViajar;
                    //aspiranteViejo.TipoUsuario = aspiranteNuevo.TipoUsuario;

                    _context.Aspirantes.Update(aspiranteViejo);
                    _context.SaveChanges();
                }
                return new GuardarAspiranteResponse(aspiranteViejo);
            }
            catch (Exception e)
            {
                return new GuardarAspiranteResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public String Eliminar(int idAspirante)
        {
            try
            {
                var aspirante = _context.Aspirantes.Find(idAspirante);
                if(aspirante != null){
                    aspirante.Estado = 2;
                    _context.Aspirantes.Update(aspirante);
                    _context.SaveChanges();
                }
                return ("Se elimino el aspirante");
            }
            catch (Exception e)
            {
                return ("Ocurriern algunos Errores:" + e.Message);
            }
        }
        
        public GuardarAspiranteResponse BuscarAspiranteId(int id)
        {
            try
            {
                var aspirante = _context.Aspirantes.Where(d => d.Identificacion == id).FirstOrDefault();
                if (aspirante != null)
                {
                    return new GuardarAspiranteResponse(aspirante);
                }
                return new GuardarAspiranteResponse("el aspirante consultado no existe");
            }
            catch (Exception e)
            {
                return new GuardarAspiranteResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }

        public ConsultarUsuarioLoginResponse consultarLogin(string correo, string contrasena){
            try
            {
                var aspirante = _context.Aspirantes.Where(d => d.Correo == correo && d.Contrasena == contrasena).FirstOrDefault();
                
                if (aspirante != null)
                {
                    return new ConsultarUsuarioLoginResponse(aspirante);
                }
                return new ConsultarUsuarioLoginResponse("El aspirante consultada no existe");
            }
            catch (Exception e)
            {
                return new ConsultarUsuarioLoginResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        //Response
        public class ConsultarAspiranteResponse
        {
            public List<Aspirante> Aspirantes { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarAspiranteResponse(List<Aspirante> listaAspirantes)
            {
                Aspirantes = listaAspirantes;
                Error = false;
            }

            public ConsultarAspiranteResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class GuardarAspiranteResponse
        {
            public Aspirante Aspirante  { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public GuardarAspiranteResponse(Aspirante aspirante)
            {
                Aspirante = aspirante;
                Error = false;
            }

            public GuardarAspiranteResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class ConsultarUsuarioLoginResponse
        {
            public Aspirante Aspirante { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarUsuarioLoginResponse(Aspirante aspirante)
            {
                Aspirante = aspirante;
                Error = false;
            }

            public ConsultarUsuarioLoginResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}
