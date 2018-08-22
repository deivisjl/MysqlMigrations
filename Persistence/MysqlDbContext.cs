using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity.Migrations.History;
using Persistence.Models;

namespace Persistence
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MysqlDbContext : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Carrera> Carrera { get; set; }

        public DbSet<Grado> Grado { get; set; }
        public DbSet<GradoCarrera> GradoCarrera { get; set; }

        public DbSet<Seccion> Seccion { get; set; }
        public DbSet<Salon> Salon { get; set; }

        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<CicloEscolar> CicloEscolar { get; set; }
        public DbSet<Inscrito> Inscrito { get; set; }

        public DbSet<Pensum> Pensum { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<PensumCurso> PensumCurso { get; set; }

        public DbSet<Bimestre> Bimestre { get; set; }
        public DbSet<InscritoCurso> InscritoCurso { get; set; }
        public DbSet<Calificacion> Calificacion { get; set; }

        public DbSet<CursoProfesor> CursoProfesor { get; set; }

        public DbSet<Mes> Mes { get; set; }
        public DbSet<Pago> Pago { get; set; }

        public MysqlDbContext() : base("DefaultConnection")
        {
        }

        //public MysqlDbContext(DbConnection existingConnection, string defaultSchema) : base(existingConnection, defaultSchema)
        //{

        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HistoryRow>().HasKey(h => h.MigrationId).Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
        }
    }
}
