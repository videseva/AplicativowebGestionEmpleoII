using System.Security.Cryptography.X509Certificates;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Empresa : Usuario
    {
        
        public int Nit { get; set;}
        public string RazonSocial { get; set;}
        public string Telefono { get; set;}
        public string Ciudad { get; set;}
        public string Direccion { get; set;}
        public string Descripcion { get; set;}
        public string SitioWeb { get; set;}
        public List<Oferta> Ofertas{ get; set;}
    }
}
