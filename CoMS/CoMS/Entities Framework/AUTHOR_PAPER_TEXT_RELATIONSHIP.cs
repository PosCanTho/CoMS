namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AUTHOR_PAPER_TEXT_RELATIONSHIP
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal PAPER_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZATION_ID_1 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_1 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_EN_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZATION_ID_2 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_2 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_EN_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZATION_ID_3 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_3 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_EN_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZATION_ID_4 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_4 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_EN_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZATION_ID_5 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_5 { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_EN_5 { get; set; }

        public DateTime? FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        public short? AUTHOR_ORDER_NUMBER { get; set; }

        public bool? CORRESPONDING_AUTHOR { get; set; }

        public virtual AUTHOR AUTHOR { get; set; }

        public virtual PAPER_TEXT PAPER_TEXT { get; set; }
    }
}
