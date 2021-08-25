using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class AdministradorService
    {
        private readonly GestionEmpleoContext _context;
        public AdministradorService(GestionEmpleoContext context)
        {
            _context = context;
        }
        
        public GuardarAdministradorResponse GuardarAdministrador(Administrador administrador)
        {
            try
            {
                var _administrador = _context.Administradores.Find(administrador.UsuarioId);
                if (_administrador == null)
                {
                    administrador.Estado = 1;
                    administrador.TipoUsuario = 1;
                    _context.Administradores.Add(administrador);
                    _context.SaveChanges();
                    return new GuardarAdministradorResponse(administrador);
                }
                 return new GuardarAdministradorResponse("El administrador ya se encuentra registrado");
            }
            catch (Exception e)
            {
                return new GuardarAdministradorResponse("Ocurrieron algunos Errores:" + e.Message);   
            }
        }

        public ConsultarAdministradorResponse Consultar()
        {
            try
            {
                var Administradores = _context.Administradores.ToList();
                return new ConsultarAdministradorResponse(Administradores);
            }
            catch (Exception e)
            {
                return new ConsultarAdministradorResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }


        public GuardarAdministradorResponse Modificar(Administrador administradorNuevo)
        {
            try
            {
                var AdministradorViejo = _context.Administradores.Find(administradorNuevo.UsuarioId);
                if(AdministradorViejo != null){
                    AdministradorViejo.Identificacion = administradorNuevo.Identificacion;
                    AdministradorViejo.Nombres = administradorNuevo.Nombres;
                    AdministradorViejo.Correo = administradorNuevo.Correo;
                    _context.Administradores.Update(AdministradorViejo);
                    _context.SaveChanges();
                }
                return new GuardarAdministradorResponse(AdministradorViejo);
            }
            catch (Exception e)
            {
                return new GuardarAdministradorResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }


        public GuardarAdministradorResponse BuscarAdministradorPorId(int id)
        {
            try
            {
                var administrador = _context.Administradores.Find(id);
                if (administrador != null)
                {
                    return new GuardarAdministradorResponse(administrador);
                }
                return new GuardarAdministradorResponse("El administrador consultado no existe");
            }
            catch (Exception e)
            {
                return new GuardarAdministradorResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }

        //Response
        public class ConsultarAdministradorResponse
        {
            public List<Administrador> Administradores { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarAdministradorResponse(List<Administrador> listaAdministradores)
            {
                Administradores = listaAdministradores;
                Error = false;
            }

            public ConsultarAdministradorResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class GuardarAdministradorResponse
        {
            public Administrador Administrador { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public GuardarAdministradorResponse(Administrador administrador)
            {
                Administrador = administrador;
                Error = false;
            }

            public GuardarAdministradorResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }

}
