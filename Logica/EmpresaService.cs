using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class EmpresaService
    {
        private readonly GestionEmpleoContext _context;
        public EmpresaService(GestionEmpleoContext context)
        {
            _context = context;
        }
        
        public GuardarEmpresaResponse GuardarEmpresa(Empresa empresa)
        {
            try
            {
                var _empresa = _context.Empresas.Find(empresa.UsuarioId);
                if (_empresa == null)
                {
                    empresa.Estado = 1;
                    empresa.TipoUsuario = 2;
                    _context.Empresas.Add(empresa);
                    _context.SaveChanges();
                    return new GuardarEmpresaResponse(empresa);
                }
                 return new GuardarEmpresaResponse("La empresa ya se encuentra registrada");
            }
            catch (Exception e)
            {
                return new GuardarEmpresaResponse("Ocurrieron algunos Errores:" + e.Message);   
            }
        }

        public ConsultarEmpresaResponse Consultar()
        {
            try
            {
                var Empresas = _context.Empresas.ToList();
                return new ConsultarEmpresaResponse(Empresas);
            }
            catch (Exception e)
            {
                return new ConsultarEmpresaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public ModificarEmpresaResponse Modificar(Empresa empresaNueva)
        {
            try
            {
                var empresaVieja = _context.Empresas.Find(empresaNueva.UsuarioId);
                if(empresaVieja != null){
                    empresaVieja.Nit = empresaNueva.Nit;
                    empresaVieja.RazonSocial = empresaNueva.RazonSocial;
                    empresaVieja.Telefono = empresaNueva.Telefono;
                    empresaVieja.Ciudad = empresaNueva.Ciudad;
                    empresaVieja.TipoUsuario = empresaNueva.TipoUsuario;
                    empresaVieja.Correo = empresaNueva.Correo;
                    empresaVieja.Direccion = empresaNueva.Direccion;
                    empresaVieja.Descripcion = empresaNueva.Descripcion;
                    empresaVieja.SitioWeb = empresaNueva.SitioWeb;
                    empresaVieja.Contrasena = empresaNueva.Contrasena;
                    _context.Empresas.Update(empresaVieja);
                    _context.SaveChanges();
                }
                return new ModificarEmpresaResponse(empresaVieja);
            }
            catch (Exception e)
            {
                return new ModificarEmpresaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public String Eliminar(int  idEmpresa)
        {
            try
            {
                var empresaVieja = _context.Empresas.Find(idEmpresa);
                if(empresaVieja != null){
                    empresaVieja.Estado = 2;
                    _context.Empresas.Update(empresaVieja);
                    _context.SaveChanges();
                }
                return ("Se elimino la empresa");
            }
            catch (Exception e)
            {
                return ("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public BuscarEmpresaResponse BuscarEmpresaPorId(int id)
        {
            try
            {
                var empresa = _context.Empresas.Find(id);
                if (empresa != null)
                {
                    return new BuscarEmpresaResponse(empresa);
                }
                return new BuscarEmpresaResponse("La empresa consultada no existe");
            }
            catch (Exception e)
            {
                return new BuscarEmpresaResponse("Ocurriern algunos Errores:" + e.Message);
            }

        }

        public BuscarEmpresaResponse BuscarEmpresaConOfertasPorId(int id)
        {
            try
            {
                var empresa = _context.Empresas.Where(t => t.Nit == id).Include(t => t.Ofertas).FirstOrDefault();
                if (empresa != null)
                {
                    return new BuscarEmpresaResponse(empresa);
                }
                return new BuscarEmpresaResponse("La Empresa consultada no existe");
            }
            catch (Exception e)
            {
                return new BuscarEmpresaResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public ConsultarUsuarioLoginResponse consultarLogin(string correo, string contrasena){
            try
            {
                var empresa = _context.Empresas.Where(d => d.Correo == correo && d.Contrasena == contrasena).FirstOrDefault();
                
                if (empresa != null)
                {
                    return new ConsultarUsuarioLoginResponse(empresa);
                }
                return new ConsultarUsuarioLoginResponse("La empresa consultada no existe");
            }
            catch (Exception e)
            {
                return new ConsultarUsuarioLoginResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }


        //Response
        public class ConsultarEmpresaResponse
        {
            public List<Empresa> Empresas { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarEmpresaResponse(List<Empresa> listempresas)
            {
                Empresas = listempresas;
                Error = false;
            }

            public ConsultarEmpresaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class GuardarEmpresaResponse
        {
            public Empresa Empresa { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public GuardarEmpresaResponse(Empresa empresa)
            {
                Empresa = empresa;
                Error = false;
            }

            public GuardarEmpresaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class ModificarEmpresaResponse
        {
            public Empresa Empresa { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ModificarEmpresaResponse(Empresa empresa)
            {
                Empresa = empresa;
                Error = false;
            }

            public ModificarEmpresaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

        public class BuscarEmpresaResponse
        {
            public Empresa Empresa { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public BuscarEmpresaResponse(Empresa empresa)
            {
                Empresa = empresa;
                Error = false;
            }

            public BuscarEmpresaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
        public class ConsultarUsuarioLoginResponse
        {
            public Empresa Empresa { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarUsuarioLoginResponse(Empresa empresa)
            {
                Empresa = empresa;
                Error = false;
            }

            public ConsultarUsuarioLoginResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

}
