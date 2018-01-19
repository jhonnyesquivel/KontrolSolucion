namespace Kontrol.Datos.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegAuditoria")]
    public partial class SegAuditoria
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IdAuditoria { get; set; }

        public int IdUsuario { get; set; }

        public byte IdOpcion { get; set; }

        public byte IdAccion { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreTabla { get; set; }

        [Required]
        [StringLength(100)]
        public string IdRegistro { get; set; }

        public DateTime FechaOperacion { get; set; }

        [Required]
        [StringLength(150)]
        public string DescripcionOperacion { get; set; }

        public virtual SegAcciones SegAcciones { get; set; }

        public virtual SegOpciones SegOpciones { get; set; }

        public virtual SegUsuarios SegUsuarios { get; set; }
    }
}
