namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ALL_TYPE_NAME
    {
        [Key]
        [StringLength(255)]
        public string TYPE_NAME_ID { get; set; }

        public int? TYPE { get; set; }

        [StringLength(255)]
        public string TYPE_NAME_NAME { get; set; }

        [StringLength(255)]
        public string TYPE_NAME_NAME_EN { get; set; }

        [StringLength(255)]
        public string TYPE_NAME_NAME_SHORT { get; set; }

        [StringLength(255)]
        public string TYPE_NAME_NAME_SHORT_EN { get; set; }

        [StringLength(255)]
        public string TYPE_VALUE { get; set; }
    }
}
