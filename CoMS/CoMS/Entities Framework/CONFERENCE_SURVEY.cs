namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_SURVEY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_SURVEY()
        {
            ACCOUNT_DOING_CONFERENCE_SURVEY = new HashSet<ACCOUNT_DOING_CONFERENCE_SURVEY>();
            CONFERENCE_SURVEY_QUESTION = new HashSet<CONFERENCE_SURVEY_QUESTION>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_SURVEY_ID { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_NAME { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_NAME_EN { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        public bool? SAVED_UNCOMPLETED_ANSWERS { get; set; }

        [StringLength(50)]
        public string PUBLIC_OR_PRIVATE_CONFERENCE_SURVEY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SURVEY_FOR_CONFERENCE_SESSION_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_1 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_1 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_2 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_2 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_3 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_3 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_4 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_4 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_5 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_5 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_6 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_6 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_7 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_7 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_8 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_8 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_9 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_9 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_GROUP_ID_10 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_10 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_GROUP_NAME_EN_10 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_1 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_1 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_1 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_2 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_2 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_2 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_3 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_3 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_3 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_4 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_4 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_4 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_5 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_5 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_5 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_6 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_6 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_6 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_6 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_7 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_7 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_7 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_7 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_8 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_8 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_8 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_8 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_9 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_9 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_9 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_9 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_10 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_10 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_10 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_10 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_11 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_11 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_11 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_11 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_12 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_12 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_12 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_12 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_13 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_13 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_13 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_13 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_14 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_14 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_14 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_14 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_15 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_15 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_15 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_15 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_16 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_16 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_16 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_16 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_17 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_17 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_17 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_17 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_18 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_18 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_18 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_18 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_19 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_19 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_19 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_19 { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_UserName_20 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_LAST_NAME_20 { get; set; }

        [StringLength(50)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_FIRST_NAME_20 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_ACCOUNT_CURRENT_MIDDLE_NAME_20 { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public DateTime? CREATED_DATETIME { get; set; }

        public bool? DELETED { get; set; }

        [StringLength(250)]
        public string DELETED_SCRIPT { get; set; }

        [StringLength(500)]
        public string DELETED_UserName { get; set; }

        public DateTime? DELETED_DATETIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_DOING_CONFERENCE_SURVEY> ACCOUNT_DOING_CONFERENCE_SURVEY { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SURVEY_QUESTION> CONFERENCE_SURVEY_QUESTION { get; set; }
    }
}
