using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPI_20240905_Marjorie_Falcone.Models;

namespace WebAPI_20240905_Marjorie_Falcone.Data
{
    public partial class BG_Marjorie_FalconeContext : DbContext
    {
        public BG_Marjorie_FalconeContext()
        {
        }

        public BG_Marjorie_FalconeContext(DbContextOptions<BG_Marjorie_FalconeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividade> Actividades { get; set; } = null!;
        public virtual DbSet<Certificado> Certificados { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Inscripcione> Inscripciones { get; set; } = null!;
        public virtual DbSet<Materiale> Materiales { get; set; } = null!;
        public virtual DbSet<Notificacione> Notificaciones { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividade>(entity =>
            {
                entity.HasKey(e => e.IdActividad)
                    .HasName("PK__Activida__5EAF86A422DE1BB6");

                entity.Property(e => e.Calificacion).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.TipoActividad).HasMaxLength(50);

                entity.Property(e => e.Titulo).HasMaxLength(255);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Actividad__IdCur__6A30C649");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK__Actividad__IdEst__6B24EA82");
            });

            modelBuilder.Entity<Certificado>(entity =>
            {
                entity.HasKey(e => e.IdCertificado)
                    .HasName("PK__Certific__F58599F9EF53279B");

                entity.Property(e => e.FechaEmision)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Certificados)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Certifica__IdCur__6EF57B66");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Certificados)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK__Certifica__IdEst__6FE99F9F");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__085F27D6C6DF9FF8");

                entity.Property(e => e.Titulo).HasMaxLength(255);

                entity.HasOne(d => d.IdInstructorNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstructor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Cursos__IdInstru__5AEE82B9");
            });

            modelBuilder.Entity<Inscripcione>(entity =>
            {
                entity.HasKey(e => e.IdInscripcion)
                    .HasName("PK__Inscripc__A122F2BF42FB31C9");

                entity.Property(e => e.FechaInscripcion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Progreso).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Inscripciones)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Inscripci__IdCur__6383C8BA");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Inscripciones)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK__Inscripci__IdEst__6477ECF3");
            });

            modelBuilder.Entity<Materiale>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PK__Material__94356E58B21C6D29");

                entity.Property(e => e.TipoMaterial).HasMaxLength(50);

                entity.Property(e => e.UrlMaterial).HasMaxLength(500);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Materiales)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Materiale__IdCur__5EBF139D");
            });

            modelBuilder.Entity<Notificacione>(entity =>
            {
                entity.HasKey(e => e.IdNotificacion)
                    .HasName("PK__Notifica__F6CA0A854A508BF0");

                entity.Property(e => e.FechaEnvio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Leida).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Notificaciones)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK__Notificac__IdEst__74AE54BC");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF9710872C37");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105340714464C")
                    .IsUnique();

                entity.Property(e => e.Apellido).HasMaxLength(100);

                entity.Property(e => e.Contraseña).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Rol).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
