namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_ATTENDEE_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_ATTENDEE_TYPE()
        {
            APPROVED_CONFERENCE_ATTENDEE_TYPES = new HashSet<APPROVED_CONFERENCE_ATTENDEE_TYPES>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_ATTENDEE_TYPE_ID { get; set; }

        [StringLength(250)]
        public string CONFERENCE_ATTENDEE_TYPE_NAME { get; set; }

        [StringLength(250)]
        public string CONFERENCE_ATTENDEE_TYPE_NAME_EN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPROVED_CONFERENCE_ATTENDEE_TYPES> APPROVED_CONFERENCE_ATTENDEE_TYPES { get; set; }
    }
}
