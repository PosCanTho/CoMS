namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FACILITY")]
    public partial class FACILITY
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal FACILITY_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string FACILITY_NAME { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN { get; set; }

        [StringLength(100)]
        public string FACILITY_TYPE_NAME { get; set; }

        [StringLength(100)]
        public string FACILITY_TYPE_NAME_EN { get; set; }

        [StringLength(50)]
        public string AREA { get; set; }

        public int? MAX_NUMBER_OF_PEOPLE { get; set; }

        public string DESCRIPTION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ROOT_FACILITY_ID { get; set; }

        [StringLength(255)]
        public string ADDRESS { get; set; }

        [StringLength(100)]
        public string CITY { get; set; }

        [StringLength(100)]
        public string COUNTRY { get; set; }

        [StringLength(100)]
        public string DISTRICT { get; set; }

        [StringLength(50)]
        public string STATE { get; set; }

        [StringLength(100)]
        public string WARD { get; set; }

        [StringLength(100)]
        public string FACILITY_USAGE_STATUS { get; set; }
    }
}
