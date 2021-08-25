using System.Linq;
using System;
using Entidad;
using System.Collections.Generic;

namespace UsuarioModel.Model
{
    
     public class UsuarioViewModel{
        public int UsuarioId { get; set;}
        public int TipoUsuario { get; set;}// 1 = admin , 2 =empresa , 3 = aspirante;
        public string Correo { get; set;}
        public string Contrasena { get; set;}
        public int Estado{ get; set;}// 1 = Activo , 2 =Inactivo ;

        public UsuarioViewModel(Usuario usuario)
        {
            UsuarioId =usuario.UsuarioId;
            TipoUsuario = usuario.TipoUsuario;
            Correo = usuario.Correo;
            Contrasena = usuario.Contrasena;
            Estado = usuario.Estado;
        }

        
    }

    public class UsuarioEmpresaViewModel : UsuarioViewModel{

            public int Nit { get; set;}
            public string RazonSocial { get; set;}
            public string Telefono { get; set;}
            public string Ciudad { get; set;}
            public string Descripcion { get; set;}
            public string SitioWeb { get; set;}
            public string Direccion { get; set;}

            public UsuarioEmpresaViewModel(Empresa empresa): base(empresa)
            {
                UsuarioId = empresa.UsuarioId;
                TipoUsuario = empresa.TipoUsuario;
                Correo = empresa.Correo;
                Contrasena = empresa.Contrasena;
                Estado = empresa.Estado;
                UsuarioId = empresa.UsuarioId;
                Nit = empresa.Nit;
                RazonSocial = empresa.RazonSocial;
                Telefono = empresa.Telefono;
                Ciudad = empresa.Ciudad;
                Correo = empresa.Correo;
                Contrasena = empresa.Contrasena;
                TipoUsuario = empresa.TipoUsuario;
                Estado = empresa.Estado;
                Descripcion = empresa.Descripcion;
                Direccion = empresa.Direccion;
                SitioWeb= empresa.SitioWeb;
            }
        }
}