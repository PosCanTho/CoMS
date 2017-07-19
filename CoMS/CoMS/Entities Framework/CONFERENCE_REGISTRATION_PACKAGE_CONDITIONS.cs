namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS()
        {
            APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE = new HashSet<APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE>();
            APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS = new HashSet<APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS>();
            APPROVED_CONFERENCE_ATTENDEE_TYPES = new HashSet<APPROVED_CONFERENCE_ATTENDEE_TYPES>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_CONDITION_ID { get; set; }

        public short? CONFERENCE_ATTENDEE_AGE_FROM { get; set; }

        public short? CONFERENCE_ATTENDEE_AGE_TO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE> APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS> APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPROVED_CONFERENCE_ATTENDEE_TYPES> APPROVED_CONFERENCE_ATTENDEE_TYPES { get; set; }

        public virtual CONFERENCE_REGISTRATION_PACKAGE CONFERENCE_REGISTRATION_PACKAGE { get; set; }
    }
}
