namespace Kontrol.Datos.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SegAcciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SegAcciones()
        {
            SegAuditoria = new HashSet<SegAuditoria>();
            SegPerfilesOpcionesAcciones = new HashSet<SegPerfilesOpcionesAcciones>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte IdAccion { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreAccion { get; set; }

        [StringLength(100)]
        public string DescripcionAccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegAuditoria> SegAuditoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegPerfilesOpcionesAcciones> SegPerfilesOpcionesAcciones { get; set; }
    }
}
