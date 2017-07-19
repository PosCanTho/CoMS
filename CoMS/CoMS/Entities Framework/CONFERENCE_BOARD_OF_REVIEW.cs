namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_BOARD_OF_REVIEW
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_BOARD_OF_REVIEW()
        {
            REVIEWERs = new HashSet<REVIEWER>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_BOARD_OF_REVIEW_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ROOT_CONFERENCE_BOARD_OF_REVIEW_ID { get; set; }

        [StringLength(500)]
        public string CONFERENCE_BOARD_OF_REVIEW_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_BOARD_OF_REVIEW_NAME_EN { get; set; }

        [StringLength(250)]
        public string CONFERENCE_BOARD_OF_REVIEW_TITLE { get; set; }

        [StringLength(250)]
        public string CONFERENCE_BOARD_OF_REVIEW_TITLE_EN { get; set; }

        public DateTime? FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        public DateTime? PAPER_ABSTRACT_REVIEW_DEADLINE_1 { get; set; }

        public DateTime? PAPER_ABSTRACT_REVIEW_DEADLINE_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_ABSTRACT_REVIEW_RATING_SCALE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_ABSTRACT_REVIEW_RATING_SCALE_STEP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_ABSTRACT_REVIEW_RATING_SCALE_START_POINT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_ABSTRACT_REVIEW_RATING_SCALE_END_POINT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_TEXT_REVIEW_RATING_SCALE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_TEXT_REVIEW_RATING_SCALE_STEP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_TEXT_REVIEW_RATING_SCALE_START_POINT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_TEXT_REVIEW_RATING_SCALE_END_POINT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_ABSTRACT_AUTOMATIC_APPROVAL_PERCENTILE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_ABSTRACT_AUTOMATIC_REJECTION_PERCENTILE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_TEXT_AUTOMATIC_APPROVAL_PERCENTILE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAPER_TEXT_AUTOMATIC_REJECTION_PERCENTILE { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER> REVIEWERs { get; set; }
    }
}
