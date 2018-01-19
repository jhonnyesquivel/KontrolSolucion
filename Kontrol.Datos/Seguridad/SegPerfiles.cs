namespace Kontrol.Datos.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SegPerfiles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SegPerfiles()
        {
            SegPerfilesOpcionesAcciones = new HashSet<SegPerfilesOpcionesAcciones>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte IdPerfil { get; set; }

        [Required]
        [StringLength(50)]
        public string NombrePerfil { get; set; }

        [StringLength(100)]
        public string DescripcionPerfil { get; set; }

        public DateTime FechaCreacionRegistro { get; set; }

        public DateTime FechaActualizacionRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegPerfilesOpcionesAcciones> SegPerfilesOpcionesAcciones { get; set; }
    }
}
