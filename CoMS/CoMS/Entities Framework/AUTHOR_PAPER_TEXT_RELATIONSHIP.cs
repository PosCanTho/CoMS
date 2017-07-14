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
    
    public partial class AUTHOR_PAPER_TEXT_RELATIONSHIP
    {
        public decimal PERSON_ID { get; set; }
        public decimal CONFERENCE_ID { get; set; }
        public decimal PAPER_ID { get; set; }
        public Nullable<decimal> ORGANIZATION_ID_1 { get; set; }
        public string ORGANIZATION_NAME_1 { get; set; }
        public string ORGANIZATION_NAME_EN_1 { get; set; }
        public Nullable<decimal> ORGANIZATION_ID_2 { get; set; }
        public string ORGANIZATION_NAME_2 { get; set; }
        public string ORGANIZATION_NAME_EN_2 { get; set; }
        public Nullable<decimal> ORGANIZATION_ID_3 { get; set; }
        public string ORGANIZATION_NAME_3 { get; set; }
        public string ORGANIZATION_NAME_EN_3 { get; set; }
        public Nullable<decimal> ORGANIZATION_ID_4 { get; set; }
        public string ORGANIZATION_NAME_4 { get; set; }
        public string ORGANIZATION_NAME_EN_4 { get; set; }
        public Nullable<decimal> ORGANIZATION_ID_5 { get; set; }
        public string ORGANIZATION_NAME_5 { get; set; }
        public string ORGANIZATION_NAME_EN_5 { get; set; }
        public Nullable<System.DateTime> FROM_DATE { get; set; }
        public string THRU_DATE { get; set; }
        public Nullable<short> AUTHOR_ORDER_NUMBER { get; set; }
        public Nullable<bool> CORRESPONDING_AUTHOR { get; set; }
    
        public virtual AUTHOR AUTHOR { get; set; }
        public virtual PAPER_TEXT PAPER_TEXT { get; set; }
    }
}
