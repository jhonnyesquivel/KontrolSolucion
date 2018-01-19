namespace Kontrol.Negocio
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KontrolModel : DbContext
    {
        public KontrolModel()
            : base("name=ModeloNegocio")
        {
        }

        public virtual DbSet<SegUsuarios> SegUsuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SegUsuarios>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<SegUsuarios>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<SegUsuarios>()
                .Property(e => e.PrimerNombre)
                .IsUnicode(false);

            modelBuilder.Entity<SegUsuarios>()
                .Property(e => e.SegundoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<SegUsuarios>()
                .Property(e => e.PrimerApellido)
                .IsUnicode(false);

            modelBuilder.Entity<SegUsuarios>()
                .Property(e => e.SegundoApellido)
                .IsUnicode(false);
        }
    }
}
