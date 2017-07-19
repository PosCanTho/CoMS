namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WINFORM_FUNCTION_FOR_WINFORM_MENU
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal FUNCTION_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal MENU_ID { get; set; }

        [Key]
        [Column(Order = 2)]
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

        public virtual WINFORM_FUNCTION WINFORM_FUNCTION { get; set; }

        public virtual WINFORM_MENU WINFORM_MENU { get; set; }
    }
}
