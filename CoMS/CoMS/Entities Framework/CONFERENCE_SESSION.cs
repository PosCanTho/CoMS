namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_SESSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_SESSION()
        {
            CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION = new HashSet<CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION>();
            CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP = new HashSet<CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP>();
            CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT = new HashSet<CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT>();
            PRESENTER_CONFERENCE_SESSION_RELATIONSHIP = new HashSet<PRESENTER_CONFERENCE_SESSION_RELATIONSHIP>();
            REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE = new HashSet<REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE>();
            SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE = new HashSet<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE>();
            SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP = new HashSet<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_SESSION_ID { get; set; }

        [StringLength(50)]
        public string WALK_IN_OR_REGISTERED_SESSION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_TOPIC_ID { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        public DateTime? START_DATETIME { get; set; }

        public DateTime? END_DATETIME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN { get; set; }

        public short? NUMBER_OF_PRESENTATION_SLOTS { get; set; }

        public DateTime? PRESENTATION_SLOT_1_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_1_END_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_2_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_2_END_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_3_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_3_END_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_4_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_4_END_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_5_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_5_END_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_6_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_6_END_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_7_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_7_END_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_8_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_8_END_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_9_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_9_END_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_10_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_10_END_DATETIME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRESENTATION_REVIEW_RATING_SCALE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRESENTATION_REVIEW_RATING_SCALE_STEP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRESENTATION_REVIEW_RATING_SCALE_START_POINT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRESENTATION_REVIEW_RATING_SCALE_END_POINT { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION> CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP> CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP { get; set; }

        public virtual CONFERENCE_SESSION_TOPIC CONFERENCE_SESSION_TOPIC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT> CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESENTER_CONFERENCE_SESSION_RELATIONSHIP> PRESENTER_CONFERENCE_SESSION_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE> REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE> SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP> SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP { get; set; }
    }
}
