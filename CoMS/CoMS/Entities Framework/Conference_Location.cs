namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Conference_Location
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_LOCATION_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_MAP_ID { get; set; }

        public double? LOCATION_LAT { get; set; }

        public double? LOCATION_LONG { get; set; }

        public string DESCRIPTION { get; set; }

        public virtual Conference_Map Conference_Map { get; set; }
    }
}
