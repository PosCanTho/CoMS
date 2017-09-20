namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Conversation_Reply
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CONVERSATION_REPLY_ID { get; set; }

        public string MESSAGE { get; set; }

        public DateTime? TIME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERSON_ID_FROM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERSON_ID_TO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERSON_ID_DELETE { get; set; }
    }
}
