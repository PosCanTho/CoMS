namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_SESSION_ID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CONFERENCE_PRESENTATION_TYPE_ID { get; set; }

        public DateTime FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        public DateTime? SETTING_DATE { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        public virtual CONFERENCE_PRESENTATION_TYPE CONFERENCE_PRESENTATION_TYPE { get; set; }

        public virtual CONFERENCE_SESSION CONFERENCE_SESSION { get; set; }
    }
}
