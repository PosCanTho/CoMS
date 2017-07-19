namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_ATTENDEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_ATTENDEE()
        {
            CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION = new HashSet<CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION>();
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

        [Column(TypeName = "numeric")]
        public decimal? CURRENT_HOME_ORGANIZATION_ID { get; set; }

        [StringLength(500)]
        public string CURRENT_HOME_ORGANIZATION_NAME { get; set; }

        [StringLength(500)]
        public string CURRENT_HOME_ORGANIZATION_NAME_EN { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_10 { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION> CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION { get; set; }

        public virtual PERSON PERSON { get; set; }
    }
}
