namespace Kontrol.Datos.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SegOpciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SegOpciones()
        {
            SegAuditoria = new HashSet<SegAuditoria>();
            SegOpciones1 = new HashSet<SegOpciones>();
            SegPerfilesOpcionesAcciones = new HashSet<SegPerfilesOpcionesAcciones>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte IdOpcion { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreOpcion { get; set; }

        public byte? IdOpcionPadre { get; set; }

        [StringLength(100)]
        public string UrlImagen { get; set; }

        [StringLength(100)]
        public string UrlOpcion { get; set; }

        public byte Orden { get; set; }

        public bool EsPresentable { get; set; }

        public bool EsAuditable { get; set; }

        public bool NotificacionDeUso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegAuditoria> SegAuditoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegOpciones> SegOpciones1 { get; set; }

        public virtual SegOpciones SegOpciones2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegPerfilesOpcionesAcciones> SegPerfilesOpcionesAcciones { get; set; }
    }
}
