namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_SESSION_CHAIR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_SESSION_CHAIR()
        {
            CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP = new HashSet<CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP>();
        }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [StringLength(50)]
        public string CURRENT_LAST_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_FIRST_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_MIDDLE_NAME { get; set; }

        [StringLength(255)]
        public string CURRENT_PERSONAL_TITLE { get; set; }

        [StringLength(50)]
        public string CURRENT_SUFFIX { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP> CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP { get; set; }

        public virtual PERSON PERSON { get; set; }
    }
}
