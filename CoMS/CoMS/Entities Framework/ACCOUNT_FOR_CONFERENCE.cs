namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACCOUNT_FOR_CONFERENCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT_FOR_CONFERENCE()
        {
            MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE = new HashSet<MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE>();
            WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE = new HashSet<WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE>();
            WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE = new HashSet<WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string CURRENT_LAST_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_FIRST_NAME { get; set; }

        [StringLength(500)]
        public string CURRENT_MIDDLE_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_EMAIL { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        [StringLength(50)]
        public string IsRegOrGenforConf { get; set; }

        public DateTime? Reg_GenforConfDate { get; set; }

        [StringLength(500)]
        public string Reg_GenforConf_UserName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Reg_GenforConf_PERSON_ID { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsSuspended { get; set; }

        public bool? CONFERENCE_ADMIN_RIGHT { get; set; }

        [StringLength(250)]
        public string CONFERENCE_ADMIN_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_ADMIN_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? CONFERENCE_ADMIN_RIGHT_SETTING_DATE { get; set; }

        public bool? REVIEWER_RIGHT { get; set; }

        [StringLength(250)]
        public string REVIEWER_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REVIEWER_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? REVIEWER_RIGHT_SETTING_DATE { get; set; }

        public bool? CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT { get; set; }

        [StringLength(250)]
        public string CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT_SETTING_DATE { get; set; }

        public bool? AUTHOR_RIGHT { get; set; }

        [StringLength(250)]
        public string AUTHOR_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AUTHOR_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? AUTHOR_RIGHT_SETTING_DATE { get; set; }

        public bool? PRESENTER_RIGHT { get; set; }

        [StringLength(250)]
        public string PRESENTER_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRESENTER_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? PRESENTER_RIGHT_SETTING_DATE { get; set; }

        public bool? CONFERENCE_ATTENDEE_RIGHT { get; set; }

        [StringLength(250)]
        public string CONFERENCE_ATTENDEE_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_ATTENDEE_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? CONFERENCE_ATTENDEE_RIGHT_SETTING_DATE { get; set; }

        public bool? SUPPORT_STAFF_RIGHT { get; set; }

        [StringLength(250)]
        public string SUPPORT_STAFF_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUPPORT_STAFF_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? SUPPORT_STAFF_RIGHT_SETTING_DATE { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE> MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE> WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE> WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE { get; set; }
    }
}
