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
    
    public partial class CONFERENCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE()
        {
            this.ACCOUNT_FOR_CONFERENCE = new HashSet<ACCOUNT_FOR_CONFERENCE>();
            this.AUTHORs = new HashSet<AUTHOR>();
            this.CONFERENCE_ATTENDEE = new HashSet<CONFERENCE_ATTENDEE>();
            this.CONFERENCE_BOARD_OF_REVIEW = new HashSet<CONFERENCE_BOARD_OF_REVIEW>();
            this.CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP = new HashSet<CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP>();
            this.CONFERENCE_REGISTRATION_PACKAGE = new HashSet<CONFERENCE_REGISTRATION_PACKAGE>();
            this.CONFERENCE_REGISTRATION_PACKAGE_OFFERING = new HashSet<CONFERENCE_REGISTRATION_PACKAGE_OFFERING>();
            this.CONFERENCE_SESSION_CHAIR = new HashSet<CONFERENCE_SESSION_CHAIR>();
            this.CONFERENCE_SESSION = new HashSet<CONFERENCE_SESSION>();
            this.CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP = new HashSet<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP>();
            this.MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE = new HashSet<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE>();
            this.MOBILEFORM_GROUP_MENU_FOR_CONFERENCE = new HashSet<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE>();
            this.PRESENTERs = new HashSet<PRESENTER>();
            this.REVIEWERs = new HashSet<REVIEWER>();
            this.SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE = new HashSet<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE>();
            this.CONFERENCE_SESSION_TOPIC = new HashSet<CONFERENCE_SESSION_TOPIC>();
            this.SUPPORT_STAFF = new HashSet<SUPPORT_STAFF>();
        }
    
        public decimal CONFERENCE_ID { get; set; }
        public string CONFERENCE_NAME { get; set; }
        public string CONFERENCE_NAME_EN { get; set; }
        public Nullable<decimal> CONFERENCE_TYPE_ID { get; set; }
        public string CONFERENCE_TYPE_NAME { get; set; }
        public string CONFERENCE_TYPE_NAME_EN { get; set; }
        public Nullable<System.DateTime> FROM_DATE { get; set; }
        public Nullable<System.DateTime> THRU_DATE { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_1 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_1 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_1 { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_2 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_2 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_2 { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_3 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_3 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_3 { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_4 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_4 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_4 { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_5 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_5 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_5 { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_6 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_6 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_6 { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_7 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_7 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_7 { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_8 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_8 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_8 { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_9 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_9 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_9 { get; set; }
        public Nullable<decimal> ORGANIZING_ORGANIZATION_ID_10 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_10 { get; set; }
        public string ORGANIZING_ORGANIZATION_NAME_EN_10 { get; set; }
        public Nullable<decimal> MAIN_FIELD_OF_STUDY_ID { get; set; }
        public string MAIN_FIELD_OF_STUDY_NAME { get; set; }
        public string MAIN_FIELD_OF_STUDY_NAME_EN { get; set; }
        public string CONFERENCE_MAIN_THEME { get; set; }
        public string CONFERENCE_MAIN_THEME_EN { get; set; }
        public Nullable<short> NUMBER_OF_PAPER_ABSTRACT_SUBMISSION_DEADLINES { get; set; }
        public Nullable<System.DateTime> PAPER_ABSTRACT_DEADLINE_1 { get; set; }
        public Nullable<System.DateTime> PAPER_ABSTRACT_DEADLINE_2 { get; set; }
        public Nullable<System.DateTime> PAPER_ABSTRACT_DEADLINE_3 { get; set; }
        public Nullable<System.DateTime> PAPER_ABSTRACT_DEADLINE_4 { get; set; }
        public Nullable<System.DateTime> PAPER_ABSTRACT_DEADLINE_5 { get; set; }
        public Nullable<int> WORD_COUNT_LIMIT_OF_PAPER_ABSTRACT { get; set; }
        public Nullable<short> NUMBER_OF_PAPER_TEXT_SUBMISSION_DEADLINES { get; set; }
        public Nullable<System.DateTime> PAPER_TEXT_DEADLINE_1 { get; set; }
        public Nullable<System.DateTime> PAPER_TEXT_DEADLINE_2 { get; set; }
        public Nullable<System.DateTime> PAPER_TEXT_DEADLINE_3 { get; set; }
        public Nullable<System.DateTime> PAPER_TEXT_DEADLINE_4 { get; set; }
        public Nullable<System.DateTime> PAPER_TEXT_DEADLINE_5 { get; set; }
        public Nullable<short> LIMIT_NUMBER_OF_PAGES_OF_PAPER_TEXT { get; set; }
        public Nullable<decimal> SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE { get; set; }
        public Nullable<decimal> SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_STEP { get; set; }
        public Nullable<decimal> SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_START_POINT { get; set; }
        public Nullable<decimal> SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_END_POINT { get; set; }
        public Nullable<decimal> SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE { get; set; }
        public Nullable<decimal> SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_STEP { get; set; }
        public Nullable<decimal> SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_START_POINT { get; set; }
        public Nullable<decimal> SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_END_POINT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_FOR_CONFERENCE> ACCOUNT_FOR_CONFERENCE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTHOR> AUTHORs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_ATTENDEE> CONFERENCE_ATTENDEE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_BOARD_OF_REVIEW> CONFERENCE_BOARD_OF_REVIEW { get; set; }
        public virtual CONFERENCE_TYPE CONFERENCE_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP> CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_REGISTRATION_PACKAGE> CONFERENCE_REGISTRATION_PACKAGE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_REGISTRATION_PACKAGE_OFFERING> CONFERENCE_REGISTRATION_PACKAGE_OFFERING { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION_CHAIR> CONFERENCE_SESSION_CHAIR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION> CONFERENCE_SESSION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP> CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE> MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE> MOBILEFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESENTER> PRESENTERs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWER> REVIEWERs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE> SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION_TOPIC> CONFERENCE_SESSION_TOPIC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPORT_STAFF> SUPPORT_STAFF { get; set; }
    }
}
