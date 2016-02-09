namespace Proyecto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("proyecto.tipo_vehiculo")]
    public partial class tipo_vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_vehiculo()
        {
            persona = new HashSet<persona>();
        }

        [Key]
        public int id_Tipo_vehiculo { get; set; }

        [Column("Tipo_vehiculo")]
        [StringLength(25)]
        public string Tipo_vehiculo1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<persona> persona { get; set; }
    }
}
