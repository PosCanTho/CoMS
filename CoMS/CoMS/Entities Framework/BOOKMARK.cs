namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bookmark")]
    public partial class Bookmark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal BOOKMARK_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERSON_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PERSON_ID_BOOKMARK { get; set; }

        [StringLength(600)]
        public string NAME_BOOKMARK { get; set; }

        [StringLength(250)]
        public string IMAGE_BOOKMARK { get; set; }

        public string DESCRIPTION { get; set; }

        public DateTime CREATE_DATE { get; set; }
    }
}
