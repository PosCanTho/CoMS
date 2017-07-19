namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WINFORM_GROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WINFORM_GROUP()
        {
            WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE = new HashSet<WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE>();
            WINFORM_GROUP_FUNCTION_FOR_CONFERENCE = new HashSet<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE>();
            WINFORM_GROUP_MENU_FOR_CONFERENCE = new HashSet<WINFORM_GROUP_MENU_FOR_CONFERENCE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal GROUP_ID { get; set; }

        [StringLength(500)]
        public string GROUP_NAME { get; set; }

        [StringLength(500)]
        public string GROUP_NAME_EN { get; set; }

        [StringLength(50)]
        public string DESIGNATED_CONFERENCE_USER_TYPE_NAME { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ROOT_GROUP_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GROUP_ORDER_NUMBER { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public DateTime? CREATED_DATETIME { get; set; }

        [StringLength(500)]
        public string UPDATED_UserName { get; set; }

        public DateTime? UPDATED_DATETIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE> WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE> WINFORM_GROUP_FUNCTION_FOR_CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WINFORM_GROUP_MENU_FOR_CONFERENCE> WINFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }
    }
}
