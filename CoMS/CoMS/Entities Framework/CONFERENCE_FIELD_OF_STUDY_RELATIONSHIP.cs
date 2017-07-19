namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal FIELD_OF_STUDY_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        public DateTime? SETTING_DATE { get; set; }

        public bool? MAIN_FIELD_OF_STUDY { get; set; }

        public string NOTE { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        public virtual FIELD_OF_STUDY FIELD_OF_STUDY { get; set; }
    }
}
