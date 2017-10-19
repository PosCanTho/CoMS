namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal NOTIFICATION_ID { get; set; }

        [StringLength(200)]
        public string TITLE { get; set; }

        public string MESSAGE { get; set; }

        [StringLength(500)]
        public string IMAGE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PERSON_ID_FROM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PERSON_ID_TO { get; set; }

        public bool? READED { get; set; }

        public DateTime? CREATE_DATE { get; set; }
    }
}
