namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_CONDITION_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal GENDER_TYPE_ID { get; set; }

        [StringLength(250)]
        public string GENDER_TYPE_NAME { get; set; }

        [StringLength(250)]
        public string GENDER_TYPE_NAME_EN { get; set; }

        public virtual CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS { get; set; }

        public virtual GENDER_TYPE GENDER_TYPE { get; set; }
    }
}
