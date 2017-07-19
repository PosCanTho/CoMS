namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LINE_OF_BUSINES_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LINE_OF_BUSINES_TYPE()
        {
            APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS = new HashSet<APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal LINE_OF_BUSINESS_TYPE_ID { get; set; }

        [StringLength(250)]
        public string LINE_OF_BUSINESS_TYPE_NAME { get; set; }

        [StringLength(250)]
        public string LINE_OF_BUSINESS_TYPE_NAME_EN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS> APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS { get; set; }
    }
}
