namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REVIEWER")]
    public partial class REVIEWER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REVIEWER()
        {
            REVIEWER_PAPER_ABSTRACT_RELATIONSHIP = new HashSet<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>();
            REVIEWER_PAPER_TEXT_RELATIONSHIP = new HashSet<REVIEWER_PAPER_TEXT_RELATIONSHIP>();
        }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

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

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_BOARD_OF_REVIEW_ID { get; set; }

        [StringLength(500)]
        public string CONFERENCE_BOARD_OF_REVIEW_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_BOARD_OF_REVIEW_NAME_EN { get; set; }

        [StringLength(250)]
        public string CONFERENCE_BOARD_OF_REVIEW_TITLE { get; set; }

        [StringLength(250)]
        public string CONFERENCE_BOARD_OF_REVIEW_TITLE_EN { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        public bool? CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT { get; set; }

        [StringLength(250)]
        public string CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT_SETTING_DATE { get; set; }

        public bool? PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT { get; set; }

        [StringLength(250)]
        public string PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SETTING_DATE { get; set; }

        public bool? PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT { get; set; }

        [StringLength(250)]
        public string PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SETTING_DATE { get; set; }

        public bool? FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT { get; set; }

        [StringLength(250)]
        public string FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SETTING_DATE { get; set; }

        public bool? FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT { get; set; }

        [StringLength(250)]
        public string FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SETTING_PERSON_ID { get; set; }

        public DateTime? FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SETTING_DATE { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        public virtual CONFERENCE_BOARD_OF_REVIEW CONFERENCE_BOARD_OF_REVIEW { get; set; }

        public virtual PERSON PERSON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP> REVIEWER_PAPER_ABSTRACT_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER_PAPER_TEXT_RELATIONSHIP> REVIEWER_PAPER_TEXT_RELATIONSHIP { get; set; }
    }
}
