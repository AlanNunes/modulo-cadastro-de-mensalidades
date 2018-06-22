namespace UGB_FINANCEIRO.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBFinanceiroModel : DbContext
    {
        public DBFinanceiroModel()
            : base("name=DBFinanceiroModel")
        {
        }

        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Mensalidade> Mensalidade { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .Property(e => e.NomeCurso)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Mensalidade)
                .WithOptional(e => e.Curso)
                .HasForeignKey(e => e.Curso_idCurso);

            modelBuilder.Entity<Tipo>()
                .Property(e => e.Tipo1)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo>()
                .HasMany(e => e.Curso)
                .WithOptional(e => e.Tipo)
                .HasForeignKey(e => e.Tipo_idTipo);
        }
    }
}
