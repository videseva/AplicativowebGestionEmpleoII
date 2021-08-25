using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Entidad
{
    public class Administrador : Usuario
    {
        public int Identificacion { get; set;}
        public string Nombres { get; set;}
    }
}