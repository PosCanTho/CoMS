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
    
    public partial class TYPE_OF_STUDY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TYPE_OF_STUDY()
        {
            this.CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP = new HashSet<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP>();
            this.TYPE_OF_STUDY1 = new HashSet<TYPE_OF_STUDY>();
        }
    
        public decimal TYPE_OF_STUDY_ID { get; set; }
        public string TYPE_OF_STUDY_NAME { get; set; }
        public string TYPE_OF_STUDY_NAME_EN { get; set; }
        public string DESCRIPTION { get; set; }
        public string DESCRIPTION_EN { get; set; }
        public Nullable<decimal> ROOT_TYPE_OF_STUDY_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP> CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TYPE_OF_STUDY> TYPE_OF_STUDY1 { get; set; }
        public virtual TYPE_OF_STUDY TYPE_OF_STUDY2 { get; set; }
    }
}
