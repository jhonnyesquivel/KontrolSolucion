namespace Kontrol.Datos.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SegPerfilesOpcionesAcciones
    {
        [Key]
        [Column(Order = 0)]
        public byte IdPerfil { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte IdOpcion { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte IdAccion { get; set; }

        public virtual SegAcciones SegAcciones { get; set; }

        public virtual SegOpciones SegOpciones { get; set; }

        public virtual SegPerfiles SegPerfiles { get; set; }
    }
}
