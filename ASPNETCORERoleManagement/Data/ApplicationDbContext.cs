using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPNETCORERoleManagement.Models;
using ASPNETCORERoleManagement.Models.PersonalViewModels;

namespace ASPNETCORERoleManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MenuMaster> MenuMaster { get; set; }
        public DbSet<Cat1> Cat1 { get; set; }

        

        public DbSet<ASPNETCORERoleManagement.Models.Region1> Region1 { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<AreaPers> AreaPers { get; set; }
        public DbSet<TipoPersonal> TipoPersonal { get; set; }
        public DbSet<TipodeNomina> TipodeNomina { get; set; }
        public DbSet<CentrodeCostos> CentrodeCostos { get; set; }
        public DbSet<ClasedeMedida> ClasedeMedida { get; set; }
        public DbSet<Divis> Divis { get; set; }

        public DbSet<Subdivision> Subdivision { get; set; }
        public DbSet<Estatus_stat2> Estatus_Stat2 { get; set; }

        public DbSet<IT0> IT0s { get; set; }

        public DbSet<IT1> IT1s { get; set; }

        public DbSet<IT2_185_105> IT2_185_105s { get; set; }
        public DbSet<IT16> IT16s { get; set; }
        public DbSet<IT21> IT21s { get; set; }
        public DbSet<IT369> IT369s { get; set; }
        public DbSet<IT41> IT41s { get; set; }
        public DbSet<IT7> IT7s { get; set; }
        public DbSet<IT8> IT8s { get; set; }

        public DbSet<IT9> IT9s { get; set; }
        public DbSet<IT6> IT6s { get; set; }

        public DbSet<Personal> Personals { get; set; }
        public DbSet<ASPNETCORERoleManagement.Models.PersonalViewModels.Personal_agregarVM> Personal_agregarVM { get; set; }
        /*Clemente 07/10/18*/
        public DbSet<Competencias> Competencias { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ClasedeMedida>()
                .HasIndex(post => new { post.Gbukrs, post.Bukrs, post.Massg, post.Massn }).IsUnique();
            

        }

    }
}


