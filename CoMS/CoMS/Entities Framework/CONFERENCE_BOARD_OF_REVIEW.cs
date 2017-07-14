//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class CONFERENCE_BOARD_OF_REVIEW
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_BOARD_OF_REVIEW()
        {
            this.REVIEWERs = new HashSet<REVIEWER>();
        }
    
        public decimal CONFERENCE_BOARD_OF_REVIEW_ID { get; set; }
        public Nullable<decimal> CONFERENCE_ID { get; set; }
        public Nullable<decimal> ROOT_CONFERENCE_BOARD_OF_REVIEW_ID { get; set; }
        public string CONFERENCE_BOARD_OF_REVIEW_NAME { get; set; }
        public string CONFERENCE_BOARD_OF_REVIEW_NAME_EN { get; set; }
        public string CONFERENCE_BOARD_OF_REVIEW_TITLE { get; set; }
        public string CONFERENCE_BOARD_OF_REVIEW_TITLE_EN { get; set; }
        public Nullable<System.DateTime> FROM_DATE { get; set; }
        public Nullable<System.DateTime> THRU_DATE { get; set; }
        public string DESCRIPTION { get; set; }
        public string DESCRIPTION_EN { get; set; }
        public Nullable<System.DateTime> PAPER_ABSTRACT_REVIEW_DEADLINE_1 { get; set; }
        public Nullable<System.DateTime> PAPER_ABSTRACT_REVIEW_DEADLINE_2 { get; set; }
        public Nullable<decimal> PAPER_ABSTRACT_REVIEW_RATING_SCALE { get; set; }
        public Nullable<decimal> PAPER_ABSTRACT_REVIEW_RATING_SCALE_STEP { get; set; }
        public Nullable<decimal> PAPER_ABSTRACT_REVIEW_RATING_SCALE_START_POINT { get; set; }
        public Nullable<decimal> PAPER_ABSTRACT_REVIEW_RATING_SCALE_END_POINT { get; set; }
        public Nullable<decimal> PAPER_TEXT_REVIEW_RATING_SCALE { get; set; }
        public Nullable<decimal> PAPER_TEXT_REVIEW_RATING_SCALE_STEP { get; set; }
        public Nullable<decimal> PAPER_TEXT_REVIEW_RATING_SCALE_START_POINT { get; set; }
        public Nullable<decimal> PAPER_TEXT_REVIEW_RATING_SCALE_END_POINT { get; set; }
        public Nullable<decimal> PAPER_ABSTRACT_AUTOMATIC_APPROVAL_PERCENTILE { get; set; }
        public Nullable<decimal> PAPER_ABSTRACT_AUTOMATIC_REJECTION_PERCENTILE { get; set; }
        public Nullable<decimal> PAPER_TEXT_AUTOMATIC_APPROVAL_PERCENTILE { get; set; }
        public Nullable<decimal> PAPER_TEXT_AUTOMATIC_REJECTION_PERCENTILE { get; set; }
    
        public virtual CONFERENCE CONFERENCE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER> REVIEWERs { get; set; }
    }
}
