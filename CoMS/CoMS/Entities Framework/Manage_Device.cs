namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Manage_Device
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal MANAGE_DEVICE_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [Required]
        public string DEVICE_TOKEN { get; set; }

        public DateTime CREATE_DATE { get; set; }

        public DateTime? UPDATE_DATE { get; set; }
    }
}
