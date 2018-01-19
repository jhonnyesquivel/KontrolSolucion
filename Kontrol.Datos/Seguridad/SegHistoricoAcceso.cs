namespace Kontrol.Datos.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegHistoricoAcceso")]
    public partial class SegHistoricoAcceso
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IdUsuario { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime FechaIngreso { get; set; }

        [Required]
        [StringLength(50)]
        public string HostRemoto { get; set; }

        [Required]
        [StringLength(50)]
        public string ClienteWeb { get; set; }
    }
}
