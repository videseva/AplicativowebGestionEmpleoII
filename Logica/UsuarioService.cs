using System.Security.Cryptography.X509Certificates;
using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class UsuarioService
    {
        private readonly GestionEmpleoContext _context;
        public UsuarioService(GestionEmpleoContext context)
        {
            _context = context;
        }
        
        public ConsultarUsuarioResponse Consultar()
        {
            try
            {
                var _Usuarios = _context.Usuario.ToList();
                return new ConsultarUsuarioResponse(_Usuarios);
            }
            catch (Exception e)
            {
                return new ConsultarUsuarioResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public ConsultarUsuarioLoginResponse consultarLogin(string correo, string contrasena){
            try
            {
                var usuario = _context.Usuario.Where(d => d.Correo == correo && d.Contrasena == contrasena).First();
                
                if (usuario != null)
                {
                    var usuario_retornar = usuario;
                    if (usuario.TipoUsuario == 2)
                    {
                        usuario_retornar = _context.Empresas.Find(usuario.UsuarioId);
                    }else if(usuario.TipoUsuario == 3){
                        usuario_retornar = _context.Aspirantes.Find(usuario.UsuarioId);
                    }
                    return new ConsultarUsuarioLoginResponse(usuario_retornar);
                }
                return new ConsultarUsuarioLoginResponse("El usuario consultada no existe");
            }
            catch (Exception e)
            {
                return new ConsultarUsuarioLoginResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }
        //Response
        
        public class ConsultarUsuarioResponse
        {
            public List<Usuario> Usuarios { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarUsuarioResponse(List<Usuario> listUsuarios)
            {
                Usuarios = listUsuarios;
                Error = false;
            }

            public ConsultarUsuarioResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class ConsultarUsuarioLoginResponse
        {
            public Usuario Usuario   { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarUsuarioLoginResponse(Usuario usuario)
            {
                Usuario = usuario;
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
