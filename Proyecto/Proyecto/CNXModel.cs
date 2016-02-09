namespace Proyecto
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CNXModel : DbContext
    {
        public CNXModel()
            : base("name=CNXModel")
        {
        }

        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<tipo_documento> tipo_documento { get; set; }
        public virtual DbSet<tipo_vehiculo> tipo_vehiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<persona>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.Nom_Pers_encontro)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.Ape_Pers_encontro)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.Lugar_encontro)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_documento>()
                .Property(e => e.Tipo_Documento1)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_documento>()
                .HasMany(e => e.persona)
                .WithRequired(e => e.tipo_documento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo_vehiculo>()
                .Property(e => e.Tipo_vehiculo1)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_vehiculo>()
                .HasMany(e => e.persona)
                .WithRequired(e => e.tipo_vehiculo)
                .WillCascadeOnDelete(false);
        }
    }
}
