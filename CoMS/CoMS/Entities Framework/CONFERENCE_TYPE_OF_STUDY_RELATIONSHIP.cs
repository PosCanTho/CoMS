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
    
    public partial class CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP
    {
        public decimal CONFERENCE_ID { get; set; }
        public decimal TYPE_OF_STUDY_ID { get; set; }
        public System.DateTime FROM_DATE { get; set; }
        public Nullable<System.DateTime> THRU_DATE { get; set; }
        public Nullable<System.DateTime> SETTING_DATE { get; set; }
    
        public virtual CONFERENCE CONFERENCE { get; set; }
        public virtual TYPE_OF_STUDY TYPE_OF_STUDY { get; set; }
    }
}
