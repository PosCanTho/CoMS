namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_ID { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_NAME { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_NAME_EN { get; set; }

        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_DESCRIPTION { get; set; }

        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_DESCRIPTION_EN { get; set; }
    }
}
