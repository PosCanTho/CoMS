namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MESSAGING_GROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MESSAGING_GROUP()
        {
            ACCOUNT_MESSAGING_GROUP_MEMBERSHIP = new HashSet<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal MESSAGING_GROUP_ID { get; set; }

        [Column(TypeName = "image")]
        public byte[] AVATAR_PICTURE { get; set; }

        [StringLength(250)]
        public string AVATAR_PICTURE_FILENAME { get; set; }

        [StringLength(250)]
        public string MESSAGING_GROUP_NAME { get; set; }

        [StringLength(250)]
        public string MESSAGING_GROUP_NAME_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        [StringLength(50)]
        public string PUBLIC_OR_PRIVATE_GROUP { get; set; }

        public DateTime? START_DATETIME { get; set; }

        public DateTime? END_DATETIME { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public DateTime? CREATED_DATETIME { get; set; }

        public bool? DELETED { get; set; }

        [StringLength(250)]
        public string DELETED_SCRIPT { get; set; }

        [StringLength(500)]
        public string DELETED_UserName { get; set; }

        public DateTime? DELETED_DATETIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP> ACCOUNT_MESSAGING_GROUP_MEMBERSHIP { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }
    }
}
