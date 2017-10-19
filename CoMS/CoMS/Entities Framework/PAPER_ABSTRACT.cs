namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAPER_ABSTRACT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAPER_ABSTRACT()
        {
            AUTHOR_PAPER_ABSTRACT_RELATIONSHIP = new HashSet<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP>();
            REVIEWER_PAPER_ABSTRACT_RELATIONSHIP = new HashSet<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal PAPER_ID { get; set; }

        [StringLength(50)]
        public string PAPER_NUMBER_OR_CODE { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_1 { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_EN_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_TOPIC_ID_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_1 { get; set; }

        public string PAPER_ABSTRACT_TEXT_1 { get; set; }

        public string PAPER_ABSTRACT_TEXT_EN_1 { get; set; }

        public string PAPER_ABSTRACT_ATTACHED_FILENAME_1 { get; set; }

        public int? WORD_COUNT_OF_PAPER_ABSTRACT_1 { get; set; }

        public string KEYWORDS_1 { get; set; }

        [StringLength(100)]
        public string FULL_PAPER_OR_WORK_IN_PROGRESS_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TYPE_OF_STUDY_ID_1 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_1 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_EN_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_PRESENTATION_TYPE_ID_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_EN_1 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_1 { get; set; }

        public DateTime? LAST_REVISED_DATE_1 { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_2 { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_EN_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_TOPIC_ID_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_2 { get; set; }

        public string PAPER_ABSTRACT_TEXT_2 { get; set; }

        public string PAPER_ABSTRACT_TEXT_EN_2 { get; set; }

        public string PAPER_ABSTRACT_ATTACHED_FILENAME_2 { get; set; }

        public int? WORD_COUNT_OF_PAPER_ABSTRACT_2 { get; set; }

        public string KEYWORDS_2 { get; set; }

        [StringLength(100)]
        public string FULL_PAPER_OR_WORK_IN_PROGRESS_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TYPE_OF_STUDY_ID_2 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_2 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_EN_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_PRESENTATION_TYPE_ID_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_EN_2 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_2 { get; set; }

        public DateTime? LAST_REVISED_DATE_2 { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_3 { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_EN_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_TOPIC_ID_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_3 { get; set; }

        public string PAPER_ABSTRACT_TEXT_3 { get; set; }

        public string PAPER_ABSTRACT_TEXT_EN_3 { get; set; }

        public string PAPER_ABSTRACT_ATTACHED_FILENAME_3 { get; set; }

        public int? WORD_COUNT_OF_PAPER_ABSTRACT_3 { get; set; }

        public string KEYWORDS_3 { get; set; }

        [StringLength(100)]
        public string FULL_PAPER_OR_WORK_IN_PROGRESS_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TYPE_OF_STUDY_ID_3 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_3 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_EN_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_PRESENTATION_TYPE_ID_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_EN_3 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_3 { get; set; }

        public DateTime? LAST_REVISED_DATE_3 { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_4 { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_EN_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_TOPIC_ID_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_4 { get; set; }

        public string PAPER_ABSTRACT_TEXT_4 { get; set; }

        public string PAPER_ABSTRACT_TEXT_EN_4 { get; set; }

        public string PAPER_ABSTRACT_ATTACHED_FILENAME_4 { get; set; }

        public int? WORD_COUNT_OF_PAPER_ABSTRACT_4 { get; set; }

        public string KEYWORDS_4 { get; set; }

        [StringLength(100)]
        public string FULL_PAPER_OR_WORK_IN_PROGRESS_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TYPE_OF_STUDY_ID_4 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_4 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_EN_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_PRESENTATION_TYPE_ID_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_EN_4 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_4 { get; set; }

        public DateTime? LAST_REVISED_DATE_4 { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_5 { get; set; }

        [StringLength(500)]
        public string PAPER_ABSTRACT_TITLE_EN_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_TOPIC_ID_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_5 { get; set; }

        public string PAPER_ABSTRACT_TEXT_5 { get; set; }

        public string PAPER_ABSTRACT_TEXT_EN_5 { get; set; }

        public string PAPER_ABSTRACT_ATTACHED_FILENAME_5 { get; set; }

        public int? WORD_COUNT_OF_PAPER_ABSTRACT_5 { get; set; }

        public string KEYWORDS_5 { get; set; }

        [StringLength(100)]
        public string FULL_PAPER_OR_WORK_IN_PROGRESS_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TYPE_OF_STUDY_ID_5 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_5 { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_EN_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_PRESENTATION_TYPE_ID_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_PRESENTATION_TYPE_NAME_EN_5 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_5 { get; set; }

        public DateTime? LAST_REVISED_DATE_5 { get; set; }

        public bool? PAPER_ABSTRACT_WITHDRAWN { get; set; }

        [StringLength(250)]
        public string PAPER_ABSTRACT_WITHDRAWN_SCRIPT { get; set; }

        public DateTime? PAPER_ABSTRACT_WITHDRAWN_DATE { get; set; }

        public string PAPER_ABSTRACT_WITHDRAWN_NOTE { get; set; }

        public bool? FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT { get; set; }

        [StringLength(250)]
        public string FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_SCRIPT { get; set; }

        public DateTime? FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ASSIGNED_CONFERENCE_SESSION_TOPIC_ID { get; set; }

        [StringLength(500)]
        public string ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME { get; set; }

        [StringLength(500)]
        public string ASSIGNED_CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP> AUTHOR_PAPER_ABSTRACT_RELATIONSHIP { get; set; }

        public virtual PAPER_TEXT PAPER_TEXT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP> REVIEWER_PAPER_ABSTRACT_RELATIONSHIP { get; set; }
    }
}
