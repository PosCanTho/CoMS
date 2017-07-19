namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOBILEFORM_MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOBILEFORM_MENU()
        {
            MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU = new HashSet<MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU>();
            MOBILEFORM_GROUP_MENU_FOR_CONFERENCE = new HashSet<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal MENU_ID { get; set; }

        [StringLength(250)]
        public string MENU_NAME { get; set; }

        [StringLength(250)]
        public string MENU_NAME_EN { get; set; }

        [StringLength(50)]
        public string MOBILEAPP_OR_MOBILEWEB { get; set; }

        [StringLength(500)]
        public string MOBILE_PLATFORM_NAME { get; set; }

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
        public virtual ICollection<MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU> MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE> MOBILEFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }
    }
}
