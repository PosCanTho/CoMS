namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT()
        {
            ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP = new HashSet<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>();
            ACCOUNT_DOING_CONFERENCE_SURVEY = new HashSet<ACCOUNT_DOING_CONFERENCE_SURVEY>();
            ACCOUNT_FOR_CONFERENCE = new HashSet<ACCOUNT_FOR_CONFERENCE>();
            ACCOUNT_MESSAGING_GROUP_MEMBERSHIP = new HashSet<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP>();
            ANSWER_TO_CONFERENCE_SURVEY_QUESTION = new HashSet<ANSWER_TO_CONFERENCE_SURVEY_QUESTION>();
            FOLLOWER_RELATIONSHIP = new HashSet<FOLLOWER_RELATIONSHIP>();
            FOLLOWER_RELATIONSHIP1 = new HashSet<FOLLOWER_RELATIONSHIP>();
            MESSAGE_FEED = new HashSet<MESSAGE_FEED>();
            SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA = new HashSet<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>();
        }

        [Key]
        [StringLength(250)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public byte[] Password { get; set; }

        [StringLength(500)]
        public string Password_Temp { get; set; }

        [Column(TypeName = "image")]
        public byte[] AVATAR_PICTURE { get; set; }

        [StringLength(50)]
        public string CURRENT_LAST_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_FIRST_NAME { get; set; }

        [StringLength(500)]
        public string CURRENT_MIDDLE_NAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CURRENT_GENDER { get; set; }

        [StringLength(50)]
        public string CURRENT_PHONE { get; set; }

        [StringLength(50)]
        public string CURRENT_EMAIL { get; set; }

        [StringLength(255)]
        public string CURRENT_ADDRESS { get; set; }

        [StringLength(100)]
        public string CURRENT_WARD { get; set; }

        [StringLength(100)]
        public string CURRENT_DISTRICT { get; set; }

        [StringLength(100)]
        public string CURRENT_CITY { get; set; }

        [StringLength(50)]
        public string CURRENT_STATE { get; set; }

        [StringLength(15)]
        public string CURRENT_ZIPCODE { get; set; }

        [StringLength(100)]
        public string CURRENT_COUNTRY { get; set; }

        public bool? CURRENT_ADDRESS_VISIBLE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CURRENT_HOME_ORGANIZATION_ID { get; set; }

        [StringLength(500)]
        public string CURRENT_HOME_ORGANIZATION_NAME { get; set; }

        [StringLength(500)]
        public string CURRENT_HOME_ORGANIZATION_NAME_EN { get; set; }

        [StringLength(500)]
        public string OFFICIAL_IMAGE { get; set; }

        [StringLength(100)]
        public string EMERGENCY_CONTACT_FULLNAME { get; set; }

        [StringLength(50)]
        public string EMERGENCY_CONTACT_RELATIONSHIP { get; set; }

        [StringLength(50)]
        public string EMERGENCY_CONTACT_RELATIONSHIP_EN { get; set; }

        [StringLength(50)]
        public string EMERGENCY_CONTACT_PHONE_NUMBER { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsSuspended { get; set; }

        public DateTime? FROM_SUSPENDED_DATE { get; set; }

        public DateTime? TO_SUSPENDED_DATE { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public bool? IsChangePass { get; set; }

        public bool? IsGenPass { get; set; }

        public bool? IsGenUserName { get; set; }

        public DateTime? Reg_GenUserNameDate { get; set; }

        public bool? IsAdmin { get; set; }

        [StringLength(250)]
        public string IsAdminScript { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public DateTime? CREATED_DATETIME { get; set; }

        [StringLength(500)]
        public string UPDATED_UserName { get; set; }

        public DateTime? UPDATED_DATETIME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERSON_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP> ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP { get; set; }

        public virtual ACCOUNT_DEVICE_RELATIONSHIP ACCOUNT_DEVICE_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_DOING_CONFERENCE_SURVEY> ACCOUNT_DOING_CONFERENCE_SURVEY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_FOR_CONFERENCE> ACCOUNT_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP> ACCOUNT_MESSAGING_GROUP_MEMBERSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWER_TO_CONFERENCE_SURVEY_QUESTION> ANSWER_TO_CONFERENCE_SURVEY_QUESTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOLLOWER_RELATIONSHIP> FOLLOWER_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOLLOWER_RELATIONSHIP> FOLLOWER_RELATIONSHIP1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MESSAGE_FEED> MESSAGE_FEED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA> SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA { get; set; }
    }
}
