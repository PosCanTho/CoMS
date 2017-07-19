namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APPROVED_CONFERENCE_ATTENDEE_TYPES
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_CONDITION_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ATTENDEE_TYPE_ID { get; set; }

        [StringLength(250)]
        public string CONFERENCE_ATTENDEE_TYPE_NAME { get; set; }

        [StringLength(250)]
        public string CONFERENCE_ATTENDEE_TYPE_NAME_EN { get; set; }

        public virtual CONFERENCE_ATTENDEE_TYPE CONFERENCE_ATTENDEE_TYPE { get; set; }

        public virtual CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS { get; set; }
    }
}
