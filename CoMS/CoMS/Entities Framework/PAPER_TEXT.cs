namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAPER_TEXT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAPER_TEXT()
        {
            AUTHOR_PAPER_TEXT_RELATIONSHIP = new HashSet<AUTHOR_PAPER_TEXT_RELATIONSHIP>();
            CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT = new HashSet<CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT>();
            PRESENTER_CONFERENCE_SESSION_RELATIONSHIP = new HashSet<PRESENTER_CONFERENCE_SESSION_RELATIONSHIP>();
            REVIEWER_PAPER_TEXT_RELATIONSHIP = new HashSet<REVIEWER_PAPER_TEXT_RELATIONSHIP>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal PAPER_ID { get; set; }

        [StringLength(50)]
        public string PAPER_NUMBER_OR_CODE { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_1 { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_EN_1 { get; set; }

        public string PAPER_TEXT_1 { get; set; }

        public string PAPER_TEXT_EN_1 { get; set; }

        public string PAPER_TEXT_ATTACHED_FILENAME_1 { get; set; }

        public short? NUMBER_OF_PAGES_OF_PAPER_TEXT_1 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_1 { get; set; }

        public DateTime? LAST_REVISED_DATE_1 { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_2 { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_EN_2 { get; set; }

        public string PAPER_TEXT_2 { get; set; }

        public string PAPER_TEXT_EN_2 { get; set; }

        public string PAPER_TEXT_ATTACHED_FILENAME_2 { get; set; }

        public short? NUMBER_OF_PAGES_OF_PAPER_TEXT_2 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_2 { get; set; }

        public DateTime? LAST_REVISED_DATE_2 { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_3 { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_EN_3 { get; set; }

        public string PAPER_TEXT_3 { get; set; }

        public string PAPER_TEXT_EN_3 { get; set; }

        public string PAPER_TEXT_ATTACHED_FILENAME_3 { get; set; }

        public short? NUMBER_OF_PAGES_OF_PAPER_TEXT_3 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_3 { get; set; }

        public DateTime? LAST_REVISED_DATE_3 { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_4 { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_EN_4 { get; set; }

        public string PAPER_TEXT_4 { get; set; }

        public string PAPER_TEXT_EN_4 { get; set; }

        public string PAPER_TEXT_ATTACHED_FILENAME_4 { get; set; }

        public short? NUMBER_OF_PAGES_OF_PAPER_TEXT_4 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_4 { get; set; }

        public DateTime? LAST_REVISED_DATE_4 { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_5 { get; set; }

        [StringLength(500)]
        public string PAPER_TEXT_TITLE_EN_5 { get; set; }

        public string PAPER_TEXT_5 { get; set; }

        public string PAPER_TEXT_EN_5 { get; set; }

        public string PAPER_TEXT_ATTACHED_FILENAME_5 { get; set; }

        public short? NUMBER_OF_PAGES_OF_PAPER_TEXT_5 { get; set; }

        public DateTime? FIRST_SUBMITTED_DATE_5 { get; set; }

        public DateTime? LAST_REVISED_DATE_5 { get; set; }

        public bool? PAPER_TEXT_WITHDRAWN { get; set; }

        [StringLength(250)]
        public string PAPER_TEXT_WITHDRAWN_SCRIPT { get; set; }

        public DateTime? PAPER_TEXT_WITHDRAWN_DATE { get; set; }

        public string PAPER_TEXT_WITHDRAWN_NOTE { get; set; }

        public bool? FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT { get; set; }

        [StringLength(250)]
        public string FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_SCRIPT { get; set; }

        public DateTime? FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID { get; set; }

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
        public virtual ICollection<AUTHOR_PAPER_TEXT_RELATIONSHIP> AUTHOR_PAPER_TEXT_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT> CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT { get; set; }

        public virtual PAPER_ABSTRACT PAPER_ABSTRACT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESENTER_CONFERENCE_SESSION_RELATIONSHIP> PRESENTER_CONFERENCE_SESSION_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER_PAPER_TEXT_RELATIONSHIP> REVIEWER_PAPER_TEXT_RELATIONSHIP { get; set; }
    }
}
