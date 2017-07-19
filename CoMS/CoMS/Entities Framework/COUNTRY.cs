namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COUNTRY")]
    public partial class COUNTRY
    {
        [Key]
        [StringLength(100)]
        public string COUNTRY_ID { get; set; }

        [StringLength(100)]
        public string COUNTRY_NAME { get; set; }

        [StringLength(100)]
        public string COUNTRY_NAME_EN { get; set; }

        [StringLength(100)]
        public string COUNTRY_NAME_SHORT { get; set; }

        [StringLength(100)]
        public string COUNTRY_NAME_SHORT_EN { get; set; }
    }
}
