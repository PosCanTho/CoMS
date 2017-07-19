namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRESENTER_CONFERENCE_SESSION_RELATIONSHIP
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal PAPER_ID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal CONFERENCE_SESSION_ID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PRESENTATION_SLOT_NUMBER { get; set; }

        public short? ACTUAL_PRESENTATION_SLOT_NUMBER { get; set; }

        public DateTime? ACTUAL_PRESENTATION_SLOT_START_DATETIME { get; set; }

        public DateTime? ACTUAL_PRESENTATION_SLOT_END_DATETIME { get; set; }

        public bool? ABSENT { get; set; }

        public virtual CONFERENCE_SESSION CONFERENCE_SESSION { get; set; }

        public virtual PAPER_TEXT PAPER_TEXT { get; set; }

        public virtual PRESENTER PRESENTER { get; set; }
    }
}
