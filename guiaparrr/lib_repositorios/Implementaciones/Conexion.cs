using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using lib_repositorios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Conexion: DbContext, IConexion
    {        
        public string? StringConexion { get; set; }

        public Conexion()
        {
            Configuracion iconexion = new Configuracion();    
            
            this.StringConexion = iconexion.ObtenerValor("StringConexion");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
       public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Zapatos> zapatos { get; set; }
       public DbSet<Auditoria> Auditoria { get; set; }



    }
}
