namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WINFORM_FUNCTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WINFORM_FUNCTION()
        {
            WINFORM_FUNCTION_FOR_WINFORM_MENU = new HashSet<WINFORM_FUNCTION_FOR_WINFORM_MENU>();
            WINFORM_GROUP_FUNCTION_FOR_CONFERENCE = new HashSet<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal FUNCTION_ID { get; set; }

        [StringLength(255)]
        public string FUNCTION_NAME { get; set; }

        [StringLength(255)]
        public string FUNCTION_NAME_EN { get; set; }

        [StringLength(255)]
        public string FORM_NAME { get; set; }

        [StringLength(255)]
        public string FORM_NAME_EN { get; set; }

        [StringLength(500)]
        public string FORM_URL { get; set; }

        public bool? FORM_DEACTIVATED { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [StringLength(500)]
        public string FORM_ICON { get; set; }

        [StringLength(50)]
        public string SYSTEM_OR_USER_FUNCTION { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public DateTime? CREATED_DATETIME { get; set; }

        [StringLength(500)]
        public string UPDATED_UserName { get; set; }

        public DateTime? UPDATED_DATETIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WINFORM_FUNCTION_FOR_WINFORM_MENU> WINFORM_FUNCTION_FOR_WINFORM_MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE> WINFORM_GROUP_FUNCTION_FOR_CONFERENCE { get; set; }
    }
}
