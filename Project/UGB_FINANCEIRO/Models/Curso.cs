namespace UGB_FINANCEIRO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            Mensalidade = new HashSet<Mensalidade>();
        }

        [Key]
        public int idCurso { get; set; }

        [Required]
        [StringLength(145)]
        [Display(Name = "Curso")]
        public string NomeCurso { get; set; }

        public int? Tipo_idTipo { get; set; }

        public virtual Tipo Tipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mensalidade> Mensalidade { get; set; }
    }
}
