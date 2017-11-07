namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONFERENCE")]
    public partial class CONFERENCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE()
        {
            ACCOUNT_FOR_CONFERENCE = new HashSet<ACCOUNT_FOR_CONFERENCE>();
            AUTHORs = new HashSet<AUTHOR>();
            CONFERENCE_ATTENDEE = new HashSet<CONFERENCE_ATTENDEE>();
            CONFERENCE_BOARD_OF_REVIEW = new HashSet<CONFERENCE_BOARD_OF_REVIEW>();
            CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP = new HashSet<CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP>();
            CONFERENCE_REGISTRATION_PACKAGE = new HashSet<CONFERENCE_REGISTRATION_PACKAGE>();
            CONFERENCE_REGISTRATION_PACKAGE_OFFERING = new HashSet<CONFERENCE_REGISTRATION_PACKAGE_OFFERING>();
            CONFERENCE_SESSION_CHAIR = new HashSet<CONFERENCE_SESSION_CHAIR>();
            CONFERENCE_SESSION = new HashSet<CONFERENCE_SESSION>();
            CONFERENCE_SURVEY = new HashSet<CONFERENCE_SURVEY>();
            CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP = new HashSet<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP>();
            FOLLOWER_RELATIONSHIP = new HashSet<FOLLOWER_RELATIONSHIP>();
            MANDATORY_OR_REGISTED_CONFERENCE_SESSION = new HashSet<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>();
            MESSAGE_FEED = new HashSet<MESSAGE_FEED>();
            MESSAGING_GROUP = new HashSet<MESSAGING_GROUP>();
            MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE = new HashSet<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE>();
            MOBILEFORM_GROUP_MENU_FOR_CONFERENCE = new HashSet<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE>();
            PRESENTERs = new HashSet<PRESENTER>();
            REVIEWERs = new HashSet<REVIEWER>();
            SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE = new HashSet<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE>();
            CONFERENCE_SESSION_TOPIC = new HashSet<CONFERENCE_SESSION_TOPIC>();
            SUPPORT_STAFF = new HashSet<SUPPORT_STAFF>();
            WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE = new HashSet<WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE>();
            WEBFORM_GROUP_MENU_FOR_CONFERENCE = new HashSet<WEBFORM_GROUP_MENU_FOR_CONFERENCE>();
            WINFORM_GROUP_FUNCTION_FOR_CONFERENCE = new HashSet<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE>();
            WINFORM_GROUP_MENU_FOR_CONFERENCE = new HashSet<WINFORM_GROUP_MENU_FOR_CONFERENCE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_TYPE_ID { get; set; }

        [StringLength(500)]
        public string CONFERENCE_TYPE_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_TYPE_NAME_EN { get; set; }

        public DateTime? FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        [Column(TypeName = "image")]
        public byte[] CONFERENCE_IMAGE { get; set; }

        [StringLength(250)]
        public string CONFERENCE_IMAGE_FILENAME { get; set; }

        [Column(TypeName = "image")]
        public byte[] CONFERENCE_BANNER { get; set; }

        [StringLength(250)]
        public string CONFERENCE_BANNER_FILENAME { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [Column(TypeName = "image")]
        public byte[] CONFERENCE_DIRECTION_MAP_1 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_DIRECTION_MAP_FILENAME_1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] CONFERENCE_DIRECTION_MAP_2 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_DIRECTION_MAP_FILENAME_2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] CONFERENCE_DIRECTION_MAP_3 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_DIRECTION_MAP_FILENAME_3 { get; set; }

        [Column(TypeName = "image")]
        public byte[] CONFERENCE_DIRECTION_MAP_4 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_DIRECTION_MAP_FILENAME_4 { get; set; }

        [Column(TypeName = "image")]
        public byte[] CONFERENCE_DIRECTION_MAP_5 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_DIRECTION_MAP_FILENAME_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_1 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_1 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_2 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_2 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_3 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_3 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_4 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_4 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_5 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_5 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_6 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_6 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_7 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_7 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_8 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_8 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_9 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_9 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZING_ORGANIZATION_ID_10 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_10 { get; set; }

        [StringLength(500)]
        public string ORGANIZING_ORGANIZATION_NAME_EN_10 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MAIN_FIELD_OF_STUDY_ID { get; set; }

        [StringLength(500)]
        public string MAIN_FIELD_OF_STUDY_NAME { get; set; }

        [StringLength(500)]
        public string MAIN_FIELD_OF_STUDY_NAME_EN { get; set; }

        public string CONFERENCE_MAIN_THEME { get; set; }

        public string CONFERENCE_MAIN_THEME_EN { get; set; }

        public short? NUMBER_OF_PAPER_ABSTRACT_SUBMISSION_DEADLINES { get; set; }

        public DateTime? PAPER_ABSTRACT_DEADLINE_1 { get; set; }

        public DateTime? PAPER_ABSTRACT_DEADLINE_2 { get; set; }

        public DateTime? PAPER_ABSTRACT_DEADLINE_3 { get; set; }

        public DateTime? PAPER_ABSTRACT_DEADLINE_4 { get; set; }

        public DateTime? PAPER_ABSTRACT_DEADLINE_5 { get; set; }

        public int? WORD_COUNT_LIMIT_OF_PAPER_ABSTRACT { get; set; }

        public short? NUMBER_OF_PAPER_TEXT_SUBMISSION_DEADLINES { get; set; }

        public DateTime? PAPER_TEXT_DEADLINE_1 { get; set; }

        public DateTime? PAPER_TEXT_DEADLINE_2 { get; set; }

        public DateTime? PAPER_TEXT_DEADLINE_3 { get; set; }

        public DateTime? PAPER_TEXT_DEADLINE_4 { get; set; }

        public DateTime? PAPER_TEXT_DEADLINE_5 { get; set; }

        public short? LIMIT_NUMBER_OF_PAGES_OF_PAPER_TEXT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_STEP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_START_POINT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_END_POINT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_STEP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_START_POINT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_END_POINT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_FOR_CONFERENCE> ACCOUNT_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTHOR> AUTHORs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_ATTENDEE> CONFERENCE_ATTENDEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_BOARD_OF_REVIEW> CONFERENCE_BOARD_OF_REVIEW { get; set; }

        public virtual CONFERENCE_TYPE CONFERENCE_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP> CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_REGISTRATION_PACKAGE> CONFERENCE_REGISTRATION_PACKAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_REGISTRATION_PACKAGE_OFFERING> CONFERENCE_REGISTRATION_PACKAGE_OFFERING { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION_CHAIR> CONFERENCE_SESSION_CHAIR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION> CONFERENCE_SESSION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SURVEY> CONFERENCE_SURVEY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP> CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOLLOWER_RELATIONSHIP> FOLLOWER_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MANDATORY_OR_REGISTED_CONFERENCE_SESSION> MANDATORY_OR_REGISTED_CONFERENCE_SESSION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MESSAGE_FEED> MESSAGE_FEED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MESSAGING_GROUP> MESSAGING_GROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE> MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE> MOBILEFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESENTER> PRESENTERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER> REVIEWERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE> SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION_TOPIC> CONFERENCE_SESSION_TOPIC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPORT_STAFF> SUPPORT_STAFF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE> WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEBFORM_GROUP_MENU_FOR_CONFERENCE> WEBFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE> WINFORM_GROUP_FUNCTION_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WINFORM_GROUP_MENU_FOR_CONFERENCE> WINFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }
    }
}
