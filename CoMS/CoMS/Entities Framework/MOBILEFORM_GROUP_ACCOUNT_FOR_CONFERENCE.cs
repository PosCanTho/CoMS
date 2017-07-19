namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal GROUP_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        public string NOTE { get; set; }

        public string NOTE_EN { get; set; }

        public virtual ACCOUNT_FOR_CONFERENCE ACCOUNT_FOR_CONFERENCE { get; set; }

        public virtual MOBILEFORM_GROUP MOBILEFORM_GROUP { get; set; }
    }
}
