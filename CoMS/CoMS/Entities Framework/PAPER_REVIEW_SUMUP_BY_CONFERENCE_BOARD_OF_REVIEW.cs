namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW()
        {
            REVIEWER_PAPER_TEXT_RELATIONSHIP = new HashSet<REVIEWER_PAPER_TEXT_RELATIONSHIP>();
        }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CONFERENCE_BOARD_OF_REVIEW_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal PAPER_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE { get; set; }

        public DateTime? LAST_REVISED_DATE { get; set; }

        public DateTime? FIRST_REVIEWED_DATE { get; set; }

        public DateTime? FINAL_REVIEWED_DATE { get; set; }

        public bool? WITHDRAWN { get; set; }

        public DateTime? WITHDRAWN_DATE { get; set; }

        public bool? FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT { get; set; }

        [StringLength(250)]
        public string FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_SCRIPT { get; set; }

        public DateTime? FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID { get; set; }

        [StringLength(500)]
        public string FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME { get; set; }

        [StringLength(500)]
        public string FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }

        [StringLength(100)]
        public string FINAL_APPROVED_FULL_PAPER_OR_WORK_IN_PROGRESS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FINAL_APPROVED_TYPE_OF_STUDY_ID { get; set; }

        [StringLength(500)]
        public string FINAL_APPROVED_TYPE_OF_STUDY_NAME { get; set; }

        [StringLength(500)]
        public string FINAL_APPROVED_TYPE_OF_STUDY_NAME_EN { get; set; }

        public bool? FINAL_APPROVED_FOR_PRESENTATION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID { get; set; }

        [StringLength(500)]
        public string FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME { get; set; }

        [StringLength(500)]
        public string FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_NAME_EN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER_PAPER_TEXT_RELATIONSHIP> REVIEWER_PAPER_TEXT_RELATIONSHIP { get; set; }
    }
}
