using System;
using Entidad;
using Microsoft.EntityFrameworkCore;
namespace Datos
{
    public class GestionEmpleoContext : DbContext
    {
        public GestionEmpleoContext(DbContextOptions options) : base(options)
        {
        
        }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Postulacion> Postulaciones { get; set; }
        public DbSet<Aspirante> Aspirantes { get; set; }
        public DbSet<InformacionAcademica> ListadoInformacionAcademica { get; set; }
        public DbSet<InformacionLaboral> ListadoInformacionLaboral { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        
    }

    
}
