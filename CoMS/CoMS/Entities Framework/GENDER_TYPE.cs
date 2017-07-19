namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GENDER_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GENDER_TYPE()
        {
            APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE = new HashSet<APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal GENDER_TYPE_ID { get; set; }

        [StringLength(250)]
        public string GENDER_TYPE_NAME { get; set; }

        [StringLength(250)]
        public string GENDER_TYPE_NAME_EN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE> APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE { get; set; }
    }
}
