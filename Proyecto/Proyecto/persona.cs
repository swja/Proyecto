namespace Proyecto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("proyecto.persona")]
    public partial class persona
    {
        [Key]
        [Column(Order = 0)]
        public int id_persona { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTipo_Doc { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_Tipo_Vehiculo { get; set; }

        [StringLength(10)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom_Pers_encontro { get; set; }

        [Required]
        [StringLength(45)]
        public string Ape_Pers_encontro { get; set; }

        [Required]
        [StringLength(50)]
        public string Lugar_encontro { get; set; }

        public DateTime Fecha_registro { get; set; }

        public virtual tipo_vehiculo tipo_vehiculo { get; set; }

        public virtual tipo_documento tipo_documento { get; set; }
    }
}
