namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_TYPE()
        {
            CONFERENCEs = new HashSet<CONFERENCE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_TYPE_ID { get; set; }

        [StringLength(500)]
        public string CONFERENCE_TYPE_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_TYPE_NAME_EN { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE> CONFERENCEs { get; set; }
    }
}
