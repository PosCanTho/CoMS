namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONVERSATION")]
    public partial class CONVERSATION
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CONVERSATION_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERSON_ID_ONE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERSON_ID_TWO { get; set; }

        public DateTime? CREATE_DATE { get; set; }
    }
}
