namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORGANIZATION")]
    public partial class ORGANIZATION
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal ORGANIZATION_ID { get; set; }

        [StringLength(50)]
        public string ORGANIZATION_CODE { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME { get; set; }

        [StringLength(500)]
        public string ORGANIZATION_NAME_EN { get; set; }

        [StringLength(255)]
        public string ADDRESS { get; set; }

        [StringLength(100)]
        public string WARD { get; set; }

        [StringLength(100)]
        public string DISTRICT { get; set; }

        [StringLength(100)]
        public string CITY { get; set; }

        [StringLength(50)]
        public string STATE { get; set; }

        [StringLength(100)]
        public string COUNTRY { get; set; }

        [StringLength(150)]
        public string ORGANIZATION_TELEPHONE { get; set; }

        [StringLength(150)]
        public string ORGANIZATION_FAX { get; set; }

        [StringLength(150)]
        public string ORGANIZATION_EMAIL { get; set; }

        [StringLength(200)]
        public string ORGANIZATION_WEBSITE { get; set; }

        [StringLength(50)]
        public string ZIPCODE { get; set; }

        [StringLength(50)]
        public string POSTAL_CODE { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        public DateTime? ESTABLISHED_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ESTABLISHMENT_DOCUMENT_ID { get; set; }

        [StringLength(150)]
        public string ORGANIZATION_LOGO { get; set; }

        [Column(TypeName = "image")]
        public byte[] ORGANIZATION_LOGO_FILE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ROOT_ORGANIZATION_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ORGANIZATION_ORDER_NUMBER { get; set; }

        public bool? DELETED { get; set; }

        [StringLength(250)]
        public string DELETED_SCRIPT { get; set; }
    }
}
