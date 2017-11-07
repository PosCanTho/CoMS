namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FOLLOWER_RELATIONSHIP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string FOLLOWED_UserName { get; set; }

        [Column(TypeName = "image")]
        public byte[] FOLLOWED_AVATAR_PICTURE { get; set; }

        [StringLength(50)]
        public string FOLLOWED_CURRENT_LAST_NAME { get; set; }

        [StringLength(50)]
        public string FOLLOWED_CURRENT_FIRST_NAME { get; set; }

        [StringLength(500)]
        public string FOLLOWED_CURRENT_MIDDLE_NAME { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string FOLLOWING_UserName { get; set; }

        [Column(TypeName = "image")]
        public byte[] FOLLOWING_AVATAR_PICTURE { get; set; }

        [StringLength(50)]
        public string FOLLOWING_CURRENT_LAST_NAME { get; set; }

        [StringLength(50)]
        public string FOLLOWING_CURRENT_FIRST_NAME { get; set; }

        [StringLength(500)]
        public string FOLLOWING_CURRENT_MIDDLE_NAME { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual ACCOUNT ACCOUNT1 { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }
    }
}
