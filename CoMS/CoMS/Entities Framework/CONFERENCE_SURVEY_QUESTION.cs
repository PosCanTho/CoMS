namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_SURVEY_QUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_SURVEY_QUESTION()
        {
            ANSWER_TO_CONFERENCE_SURVEY_QUESTION = new HashSet<ANSWER_TO_CONFERENCE_SURVEY_QUESTION>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_SURVEY_QUESTION_ID { get; set; }

        [Column("CONFERENCE_SURVEY_QUESTION")]
        public string CONFERENCE_SURVEY_QUESTION1 { get; set; }

        public string CONFERENCE_SURVEY_QUESTION_EN { get; set; }

        [StringLength(100)]
        public string CONFERENCE_SURVEY_QUESTION_TYPE_NAME { get; set; }

        [StringLength(100)]
        public string CONFERENCE_SURVEY_QUESTION_TYPE_NAME_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_SURVEY_ID { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_NAME { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_NAME_EN { get; set; }

        public int? CONFERENCE_SURVEY_QUESTION_ORDER_NUMBER { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_QUESTION_OPTION_A { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_QUESTION_POINT_A { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_QUESTION_OPTION_B { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_QUESTION_POINT_B { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_QUESTION_OPTION_C { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_QUESTION_POINT_C { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_QUESTION_OPTION_D { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_QUESTION_POINT_D { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_QUESTION_OPTION_E { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_QUESTION_POINT_E { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_QUESTION_OPTION_F { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_QUESTION_POINT_F { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_QUESTION_OPTION_G { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_QUESTION_POINT_G { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SURVEY_QUESTION_OPTION_H { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SURVEY_QUESTION_POINT_H { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MINIMUM_RATING_SCALE_VALUE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MAXIMUM_RATING_SCALE_VALUE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RATING_SCALE_STEP_VALUE { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public DateTime? CREATED_DATETIME { get; set; }

        public DateTime? LATEST_UPDATED_DATETIME { get; set; }

        public bool? DELETED { get; set; }

        [StringLength(250)]
        public string DELETED_SCRIPT { get; set; }

        [StringLength(500)]
        public string DELETED_UserName { get; set; }

        public DateTime? DELETED_DATETIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWER_TO_CONFERENCE_SURVEY_QUESTION> ANSWER_TO_CONFERENCE_SURVEY_QUESTION { get; set; }

        public virtual CONFERENCE_SURVEY CONFERENCE_SURVEY { get; set; }
    }
}
