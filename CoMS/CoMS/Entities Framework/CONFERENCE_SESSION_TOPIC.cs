namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_SESSION_TOPIC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_SESSION_TOPIC()
        {
            CONFERENCE_SESSION = new HashSet<CONFERENCE_SESSION>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_SESSION_TOPIC_ID { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        public string CONFERENCE_MAIN_THEME { get; set; }

        public string CONFERENCE_MAIN_THEME_EN { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFERENCE_SESSION> CONFERENCE_SESSION { get; set; }
    }
}
