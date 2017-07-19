namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_CONDITION_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ATTENDEE_LINE_OF_BUSINESS_TYPE_ID { get; set; }

        [StringLength(250)]
        public string CONFERENCE_ATTENDEE_LINE_OF_BUSINESS_TYPE_NAME { get; set; }

        [StringLength(250)]
        public string CONFERENCE_ATTENDEE_LINE_OF_BUSINESS_TYPE_NAME_EN { get; set; }

        public virtual CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS { get; set; }

        public virtual LINE_OF_BUSINES_TYPE LINE_OF_BUSINES_TYPE { get; set; }
    }
}
