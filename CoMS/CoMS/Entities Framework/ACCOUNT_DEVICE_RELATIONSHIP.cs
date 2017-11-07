namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACCOUNT_DEVICE_RELATIONSHIP
    {
        [Key]
        [StringLength(250)]
        public string UserName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [Required]
        public string DEVICE_TOKEN { get; set; }

        public DateTime FIRST_LOGINED_DATE { get; set; }

        public DateTime? LAST_REVISED_DATE { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }
    }
}
