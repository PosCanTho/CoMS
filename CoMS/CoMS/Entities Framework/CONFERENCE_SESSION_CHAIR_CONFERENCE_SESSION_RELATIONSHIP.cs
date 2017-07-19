namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CONFERENCE_SESSION_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        public virtual CONFERENCE_SESSION CONFERENCE_SESSION { get; set; }

        public virtual CONFERENCE_SESSION_CHAIR CONFERENCE_SESSION_CHAIR { get; set; }
    }
}
