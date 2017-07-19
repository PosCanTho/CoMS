namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_REGISTRATION_PACKAGE_OFFERING
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_ID { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_NAME { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_NAME_EN { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }
    }
}
