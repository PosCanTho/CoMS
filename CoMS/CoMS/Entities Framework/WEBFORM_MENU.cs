namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WEBFORM_MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WEBFORM_MENU()
        {
            WEBFORM_FUNCTION_FOR_WEBFORM_MENU = new HashSet<WEBFORM_FUNCTION_FOR_WEBFORM_MENU>();
            WEBFORM_GROUP_MENU_FOR_CONFERENCE = new HashSet<WEBFORM_GROUP_MENU_FOR_CONFERENCE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal MENU_ID { get; set; }

        [StringLength(250)]
        public string MENU_NAME { get; set; }

        [StringLength(250)]
        public string MENU_NAME_EN { get; set; }

        [StringLength(500)]
        public string MENU_ICON { get; set; }

        public short? MENU_ORDER_NUMBER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MENU_ID_ROOT { get; set; }

        [StringLength(50)]
        public string SYSTEM_OR_USER_MENU { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public DateTime? CREATED_DATETIME { get; set; }

        [StringLength(500)]
        public string UPDATED_UserName { get; set; }

        public DateTime? UPDATED_DATETIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEBFORM_FUNCTION_FOR_WEBFORM_MENU> WEBFORM_FUNCTION_FOR_WEBFORM_MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEBFORM_GROUP_MENU_FOR_CONFERENCE> WEBFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }
    }
}
