namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TYPE_OF_STUDY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TYPE_OF_STUDY()
        {
            CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP = new HashSet<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP>();
            TYPE_OF_STUDY1 = new HashSet<TYPE_OF_STUDY>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal TYPE_OF_STUDY_ID { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME { get; set; }

        [StringLength(500)]
        public string TYPE_OF_STUDY_NAME_EN { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ROOT_TYPE_OF_STUDY_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP> CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TYPE_OF_STUDY> TYPE_OF_STUDY1 { get; set; }

        public virtual TYPE_OF_STUDY TYPE_OF_STUDY2 { get; set; }
    }
}
