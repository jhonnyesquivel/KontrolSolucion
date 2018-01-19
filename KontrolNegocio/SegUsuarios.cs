namespace Kontrol.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SegUsuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(500)]
        public string Username { get; set; }

        [Required]
        [StringLength(300)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string PrimerNombre { get; set; }

        [StringLength(100)]
        public string SegundoNombre { get; set; }

        [Required]
        [StringLength(100)]
        public string PrimerApellido { get; set; }

        [StringLength(100)]
        public string SegundoApellido { get; set; }

        public short DiasVigencia { get; set; }

        public bool EnSesion { get; set; }

        public DateTime FechaCreacionRegistro { get; set; }

        public DateTime FechaActualizacionRegistro { get; set; }
    }
}
