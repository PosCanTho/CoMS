namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PERSON_LIKING_MESSAGE_FEED
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal MESSAGE_FEED_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string UserName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERSON_ID { get; set; }

        [StringLength(50)]
        public string CURRENT_LAST_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_FIRST_NAME { get; set; }

        [StringLength(500)]
        public string CURRENT_MIDDLE_NAME { get; set; }

        public DateTime? LIKED_DATETIME { get; set; }

        public virtual MESSAGE_FEED MESSAGE_FEED { get; set; }
    }
}
