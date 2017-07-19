namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_SESSION_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID { get; set; }

        public string NOTE { get; set; }

        public string NOTE_EN { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        public virtual CONFERENCE_REGISTRATION_PACKAGE CONFERENCE_REGISTRATION_PACKAGE { get; set; }

        public virtual CONFERENCE_SESSION CONFERENCE_SESSION { get; set; }
    }
}
