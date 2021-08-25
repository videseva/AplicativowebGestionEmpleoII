using System.Linq;
using System;
using Entidad;
using System.Collections.Generic;

namespace AdministradorModel.Model
{
    public class AdministradorInputModel{
        public int Identificacion { get; set;}
        public string Nombres { get; set;}
        public int Estado { get; set;}
        public string Correo { get; set;}
        public string Contrasena { get; set;}
        public int UsuarioId { get; set;}
        public int TipoUsuario { get ; set;}// 1 = admin , 2 =empresa , 3 = aspirante,
    }
    
     public class AdministradorViewModel{
         public int Identificacion { get; set;}
        public string Nombres { get; set;}
        public  int Estado { get; set;}
        public string Correo { get; set;}
        public int UsuarioId { get; set;}
        public int TipoUsuario { get ; set;}// 1 = admin , 2 =empresa , 3 = aspirante,

        public AdministradorViewModel(Administrador administrador)
        {
            Identificacion =administrador.Identificacion;
            Nombres = administrador.Nombres;
            Correo = administrador.Correo;
            TipoUsuario = administrador.TipoUsuario;
            UsuarioId = administrador.UsuarioId;
            Estado = administrador.Estado;
        }

    }
}