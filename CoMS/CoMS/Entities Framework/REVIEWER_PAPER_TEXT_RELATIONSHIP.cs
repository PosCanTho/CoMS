namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REVIEWER_PAPER_TEXT_RELATIONSHIP
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_BOARD_OF_REVIEW_ID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal PAPER_ID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER { get; set; }

        public DateTime? REVIEWED_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PROPOSED_REVISED_CONFERENCE_SESSION_TOPIC_ID { get; set; }

        [StringLength(500)]
        public string PROPOSED_REVISED_CONFERENCE_SESSION_TOPIC_NAME { get; set; }

        [StringLength(500)]
        public string PROPOSED_REVISED_CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }

        [StringLength(100)]
        public string PROPOSED_FULL_PAPER_OR_WORK_IN_PROGRESS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PROPOSED_TYPE_OF_STUDY_ID { get; set; }

        [StringLength(500)]
        public string PROPOSED_TYPE_OF_STUDY_NAME { get; set; }

        [StringLength(500)]
        public string PROPOSED_TYPE_OF_STUDY_NAME_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID { get; set; }

        [StringLength(500)]
        public string PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME { get; set; }

        [StringLength(500)]
        public string PROPOSED_CONFERENCE_PRESENTATION_TYPE_NAME_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_TEXT_REVIEW_RATING_POINT { get; set; }

        [StringLength(100)]
        public string SIGNIFICANT_REVISION_OR_MINIMAL_REVISION_OR_REVISION_NEEDED_OR_NO_REVISION_NEEDED { get; set; }

        public string REVIEW_TEXT { get; set; }

        public string REVIEW_TEXT_EN { get; set; }

        public bool? APPROVAL_OR_REJECTION_OF_PAPER_TEXT { get; set; }

        [StringLength(250)]
        public string APPROVAL_OR_REJECTION_OF_PAPER_TEXT_SCRIPT { get; set; }

        public DateTime? APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE { get; set; }

        public virtual PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW { get; set; }

        public virtual PAPER_TEXT PAPER_TEXT { get; set; }

        public virtual REVIEWER REVIEWER { get; set; }
    }
}
