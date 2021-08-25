using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entidad
{
    public abstract class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set;}
        public int TipoUsuario { get; set;}// 1 = admin , 2 =empresa , 3 = aspirante;
        public string Correo { get; set;}
        public string Contrasena { get; set;}
        public int Estado{ get; set;}// 1 = Activo , 2 =Inactivo ;
    }
}
