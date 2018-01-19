namespace Kontrol.Datos.Seguridad
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloSeguridad : DbContext
    {
        public ModeloSeguridad()
            : base("name=conetionstring")
        {
        }

        public virtual DbSet<SegAcciones> SegAcciones { get; set; }
        public virtual DbSet<SegAuditoria> SegAuditoria { get; set; }
        public virtual DbSet<SegHistoricoAcceso> SegHistoricoAcceso { get; set; }
        public virtual DbSet<SegOpciones> SegOpciones { get; set; }
        public virtual DbSet<SegPerfiles> SegPerfiles { get; set; }
        public virtual DbSet<SegPerfilesOpcionesAcciones> SegPerfilesOpcionesAcciones { get; set; }
        public virtual DbSet<SegUsuarios> SegUsuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SegAcciones>()
                .Property(e => e.NombreAccion)
                .IsUnicode(false);

            modelBuilder.Entity<SegAcciones>()
                .Property(e => e.DescripcionAccion)
                .IsUnicode(false);

            modelBuilder.Entity<SegAcciones>()
                .HasMany(e => e.SegAuditoria)
                .WithRequired(e => e.SegAcciones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SegAcciones>()
                .HasMany(e => e.SegPerfilesOpcionesAcciones)
                .WithRequired(e => e.SegAcciones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SegAuditoria>()
                .Property(e => e.IdAuditoria)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SegAuditoria>()
                .Property(e => e.NombreTabla)
                .IsUnicode(false);

            modelBuilder.Entity<SegAuditoria>()
                .Property(e => e.IdRegistro)
                .IsUnicode(false);

            modelBuilder.Entity<SegAuditoria>()
                .Property(e => e.DescripcionOperacion)
                .IsUnicode(false);

            modelBuilder.Entity<SegHistoricoAcceso>()
                .Property(e => e.IdUsuario)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SegHistoricoAcceso>()
                .Property(e => e.HostRemoto)
                .IsUnicode(false);

            modelBuilder.Entity<SegHistoricoAcceso>()
                .Property(e => e.ClienteWeb)
                .IsUnicode(false);

            modelBuilder.Entity<SegOpciones>()
                .Property(e => e.NombreOpcion)
                .IsUnicode(false);

            modelBuilder.Entity<SegOpciones>()
                .Property(e => e.UrlImagen)
                .IsUnicode(false);

            modelBuilder.Entity<SegOpciones>()
                .Property(e => e.UrlOpcion)
                .IsUnicode(false);

            modelBuilder.Entity<SegOpciones>()
                .HasMany(e => e.SegAuditoria)
                .WithRequired(e => e.SegOpciones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SegOpciones>()
                .HasMany(e => e.SegOpciones1)
                .WithOptional(e => e.SegOpciones2)
                .HasForeignKey(e => e.IdOpcionPadre);

            modelBuilder.Entity<SegOpciones>()
                .HasMany(e => e.SegPerfilesOpcionesAcciones)
                .WithRequired(e => e.SegOpciones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SegPerfiles>()
                .Property(e => e.NombrePerfil)
                .IsUnicode(false);

            modelBuilder.Entity<SegPerfiles>()
                .Property(e => e.DescripcionPerfil)
                .IsUnicode(false);

            modelBuilder.Entity<SegPerfiles>()
                .HasMany(e => e.SegPerfilesOpcionesAcciones)
                .WithRequired(e => e.SegPerfiles)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<SegUsuarios>()
                .HasMany(e => e.SegAuditoria)
                .WithRequired(e => e.SegUsuarios)
                .WillCascadeOnDelete(false);
        }




    }
}
