namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal PAPER_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_SESSION_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PRESENTATION_SLOT_NUMBER { get; set; }

        [StringLength(50)]
        public string ON_SCHEDULE_OR_CANCELLED_OR_MOVED_PRESENTATION_SLOT { get; set; }

        public DateTime? PRESENTATION_SLOT_ACTUAL_START_DATETIME { get; set; }

        public DateTime? PRESENTATION_SLOT_ACTUAL_END_DATETIME { get; set; }

        [StringLength(50)]
        public string ON_TIME_START_OR_EARLY_START_OR_LATE_START { get; set; }

        [StringLength(50)]
        public string ON_TIME_END_OR_EARLY_END_OR_LATE_END { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MOVED_TO_CONFERENCE_SESSION_ID { get; set; }

        public short? MOVED_TO_PRESENTATION_SLOT_NUMBER { get; set; }

        public string NOTE { get; set; }

        public virtual CONFERENCE_SESSION CONFERENCE_SESSION { get; set; }

        public virtual PAPER_TEXT PAPER_TEXT { get; set; }
    }
}
