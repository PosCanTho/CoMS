namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACCOUNT_MESSAGING_GROUP_MEMBERSHIP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal MESSAGING_GROUP_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime START_DATETIME { get; set; }

        public DateTime? END_DATETIME { get; set; }

        public bool? MESSAGING_GROUP_MODERATOR { get; set; }

        [StringLength(250)]
        public string MESSAGING_GROUP_MODERATOR_SCRIPT { get; set; }

        [StringLength(50)]
        public string GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED { get; set; }

        [StringLength(250)]
        public string GROUP_ASSIGNED_OR_GROUP_JOIN_REQUEST_OR_GROUP_JOIN_REQUEST_APPROVED_SCRIPT { get; set; }

        public string NOTE { get; set; }

        public string NOTE_EN { get; set; }

        [StringLength(500)]
        public string CREATED_UserName { get; set; }

        public bool? DELETED { get; set; }

        [StringLength(250)]
        public string DELETED_SCRIPT { get; set; }

        [StringLength(500)]
        public string DELETED_UserName { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual MESSAGING_GROUP MESSAGING_GROUP { get; set; }
    }
}
