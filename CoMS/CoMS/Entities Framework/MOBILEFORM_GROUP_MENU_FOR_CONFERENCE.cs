namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOBILEFORM_GROUP_MENU_FOR_CONFERENCE
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal MENU_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal GROUP_ID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        public string NOTE { get; set; }

        public string NOTE_EN { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public DateTime? CREATED_DATETIME { get; set; }

        [StringLength(500)]
        public string UPDATED_UserName { get; set; }

        public DateTime? UPDATED_DATETIME { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        public virtual MOBILEFORM_MENU MOBILEFORM_MENU { get; set; }
    }
}
