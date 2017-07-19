namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERSON")]
    public partial class PERSON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSON()
        {
            AUTHORs = new HashSet<AUTHOR>();
            CONFERENCE_ATTENDEE = new HashSet<CONFERENCE_ATTENDEE>();
            CONFERENCE_SESSION_CHAIR = new HashSet<CONFERENCE_SESSION_CHAIR>();
            PRESENTERs = new HashSet<PRESENTER>();
            REVIEWERs = new HashSet<REVIEWER>();
            SUPPORT_STAFF = new HashSet<SUPPORT_STAFF>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [StringLength(15)]
        public string INSTRUCTOR_ID_NUMBER { get; set; }

        [StringLength(15)]
        public string STUDENT_ID_NUMBER { get; set; }

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

        [StringLength(50)]
        public string CURRENT_NICKNAME { get; set; }

        public DateTime? BIRTH_DATE { get; set; }

        [StringLength(100)]
        public string BIRTH_PLACE { get; set; }

        [StringLength(100)]
        public string MOTHER_S_MAIDEN_NAME { get; set; }

        [StringLength(30)]
        public string CURRENT_MARITAL_STATUS { get; set; }

        [StringLength(50)]
        public string PEOPLE_ID_NUMBER { get; set; }

        public DateTime? PEOPLE_ID_ISSUE_DATE { get; set; }

        [StringLength(50)]
        public string PEOPLE_ID_ISSUE_PLACE { get; set; }

        [StringLength(20)]
        public string SOCIAL_SECURITY_NUMBER { get; set; }

        [StringLength(60)]
        public string CURRENT_MAJOR_CITIZENSHIP { get; set; }

        [StringLength(40)]
        public string CURRENT_PASSPORT_NUMBER { get; set; }

        [StringLength(60)]
        public string CURRENT_PASSPORT_ISSUE_PLACE { get; set; }

        public DateTime? CURRENT_PASSPORT_ISSUE_DATE { get; set; }

        public DateTime? CURRENT_PASSPORT_EXPIRATION_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TOTAL_YEARS_WORK_EXPERIENCE { get; set; }

        public string COMMENTS { get; set; }

        [StringLength(255)]
        public string ACADEMIC_TITLE { get; set; }

        public string CLOSEUP_PICTURE_1 { get; set; }

        public string CLOSEUP_PICTURE_2 { get; set; }

        [StringLength(255)]
        public string CURRENT_ADDRESS { get; set; }

        [StringLength(100)]
        public string CURRENT_CITY { get; set; }

        [StringLength(100)]
        public string CURRENT_COUNTRY { get; set; }

        [StringLength(100)]
        public string CURRENT_DISTRICT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CURRENT_GENDER { get; set; }

        [StringLength(50)]
        public string CURRENT_STATE { get; set; }

        [StringLength(100)]
        public string CURRENT_WARD { get; set; }

        [StringLength(255)]
        public string HOME_ADDRESS { get; set; }

        [StringLength(100)]
        public string HOME_CITY { get; set; }

        [StringLength(100)]
        public string HOME_COUNTRY { get; set; }

        [StringLength(100)]
        public string HOME_DISTRICT { get; set; }

        [StringLength(50)]
        public string HOME_STATE { get; set; }

        [StringLength(100)]
        public string HOME_WARD { get; set; }

        [StringLength(100)]
        public string CURRENT_PHONE_NUMBER { get; set; }

        [StringLength(100)]
        public string CURRENT_MOBILE_NUMBER { get; set; }

        [StringLength(250)]
        public string CURRENT_PERSONAL_EMAIL { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public DateTime? CREATED_DATETIME { get; set; }

        [StringLength(500)]
        public string UPDATED_UserName { get; set; }

        public DateTime? UPDATED_DATETIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTHOR> AUTHORs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_ATTENDEE> CONFERENCE_ATTENDEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION_CHAIR> CONFERENCE_SESSION_CHAIR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESENTER> PRESENTERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER> REVIEWERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPORT_STAFF> SUPPORT_STAFF { get; set; }
    }
}
