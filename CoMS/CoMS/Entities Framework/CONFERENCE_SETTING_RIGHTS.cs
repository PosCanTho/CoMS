namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_SETTING_RIGHTS
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_ABSTRACT_AUTOMATIC_APPROVAL_PERCENTILE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_ABSTRACT_AUTOMATIC_REJECTION_PERCENTILE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_TEXT_AUTOMATIC_APPROVAL_PERCENTILE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SUGGESTED_PAPER_TEXT_AUTOMATIC_REJECTION_PERCENTILE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TECHNICAL_CHAIR_RIGHT_PERSON_ID_1 { get; set; }

        [StringLength(250)]
        public string TECHNICAL_CHAIR_RIGHT_SCRIPT_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TECHNICAL_CHAIR_RIGHT_PERSON_ID_2 { get; set; }

        [StringLength(250)]
        public string TECHNICAL_CHAIR_RIGHT_SCRIPT_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TECHNICAL_CHAIR_RIGHT_PERSON_ID_3 { get; set; }

        [StringLength(250)]
        public string TECHNICAL_CHAIR_RIGHT_SCRIPT_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TECHNICAL_CHAIR_RIGHT_PERSON_ID_4 { get; set; }

        [StringLength(250)]
        public string TECHNICAL_CHAIR_RIGHT_SCRIPT_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TECHNICAL_CHAIR_RIGHT_PERSON_ID_5 { get; set; }

        [StringLength(250)]
        public string TECHNICAL_CHAIR_RIGHT_SCRIPT_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_1 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_2 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_3 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_4 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_5 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_1 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_2 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_3 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_4 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_5 { get; set; }

        [StringLength(250)]
        public string SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_1 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_2 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_3 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_4 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_5 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_1 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_2 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_3 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_4 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_5 { get; set; }

        [StringLength(250)]
        public string SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT_5 { get; set; }
    }
}
