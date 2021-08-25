using System.Linq;
using System;
using Entidad;
using System.Collections.Generic;

namespace EmpresaModel.Model
{
    public class EmpresaInputModel{
        public int Nit { get; set;}
        public string RazonSocial { get; set;}
        public string Telefono { get; set;}
        public string Ciudad { get; set;}
        public string Correo { get; set;}
        public string Contrasena { get; set;}
        public int UsuarioId { get; set;}
        public string Descripcion { get; set;}
        public string SitioWeb { get; set;}
        public string Direccion { get; set;}
    }
    
     public class EmpresaViewModel{
        public int UsuarioId { get; set;}
        public int Nit { get; set;}
        public string RazonSocial { get; set;}
        public string Telefono { get; set;}
        public string Ciudad { get; set;}
        public string Correo { get; set;}
        public string Contrasena { get; set;}
        public int Estado { get; set;}
        public string Descripcion { get; set;}
        public string SitioWeb { get; set;}
        public string Direccion { get; set;}
        public int TipoUsuario { get ; set;}// 1 = admin , 2 =empresa , 3 = aspirante,

        public EmpresaViewModel(Empresa empresa)
        {
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
