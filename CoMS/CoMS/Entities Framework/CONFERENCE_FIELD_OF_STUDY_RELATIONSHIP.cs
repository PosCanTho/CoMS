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
    
    public partial class CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP
    {
        public decimal CONFERENCE_ID { get; set; }
        public decimal FIELD_OF_STUDY_ID { get; set; }
        public System.DateTime FROM_DATE { get; set; }
        public Nullable<System.DateTime> THRU_DATE { get; set; }
        public Nullable<System.DateTime> SETTING_DATE { get; set; }
        public Nullable<bool> MAIN_FIELD_OF_STUDY { get; set; }
        public string NOTE { get; set; }
    
        public virtual CONFERENCE CONFERENCE { get; set; }
        public virtual FIELD_OF_STUDY FIELD_OF_STUDY { get; set; }
    }
}
