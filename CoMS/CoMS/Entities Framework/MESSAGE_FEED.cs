namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MESSAGE_FEED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MESSAGE_FEED()
        {
            MESSAGE_FEED1 = new HashSet<MESSAGE_FEED>();
            PERSON_LIKING_MESSAGE_FEED = new HashSet<PERSON_LIKING_MESSAGE_FEED>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal MESSAGE_FEED_ID { get; set; }

        public DateTime? FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        [Required]
        [StringLength(250)]
        public string UserName { get; set; }

        [Column(TypeName = "image")]
        public byte[] AVATAR_PICTURE { get; set; }

        [StringLength(50)]
        public string CURRENT_LAST_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_FIRST_NAME { get; set; }

        [StringLength(500)]
        public string CURRENT_MIDDLE_NAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? REPLYING_TO_MESSAGE_FEED_ID { get; set; }

        [StringLength(50)]
        public string PUBLIC_OR_PRIVATE_MESSAGE { get; set; }

        public string MESSAGE_CONTENT { get; set; }

        [Column(TypeName = "image")]
        public byte[] ATTACHED_PHOTO { get; set; }

        [StringLength(250)]
        public string ATTACHED_PHOTO_FILENAME { get; set; }

        public string ATTACHED_PHOTO_NOTE { get; set; }

        [StringLength(250)]
        public string ATTACHED_PHOTO_LONGITUDE { get; set; }

        [StringLength(250)]
        public string ATTACHED_PHOTO_LATITUDE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_1 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_1 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_2 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_2 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_3 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_3 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_3 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_4 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_4 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_4 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_5 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_5 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_5 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_6 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_6 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_6 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_7 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_7 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_7 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_8 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_8 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_8 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_9 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_9 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_9 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RECIPIENT_MESSAGING_GROUP_ID_10 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_MESSAGING_GROUP_AVATAR_PICTURE_10 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_10 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_MESSAGING_GROUP_NAME_EN_10 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_1 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_1 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_1 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_1 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_2 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_2 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_2 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_2 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_3 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_3 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_3 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_3 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_3 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_4 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_4 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_4 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_4 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_4 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_5 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_5 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_5 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_5 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_5 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_6 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_6 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_6 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_6 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_6 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_7 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_7 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_7 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_7 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_7 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_8 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_8 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_8 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_8 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_8 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_9 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_9 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_9 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_9 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_9 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_10 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_10 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_10 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_10 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_10 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_11 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_11 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_11 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_11 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_11 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_12 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_12 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_12 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_12 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_12 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_13 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_13 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_13 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_13 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_13 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_14 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_14 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_14 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_14 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_14 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_15 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_15 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_15 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_15 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_15 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_16 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_16 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_16 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_16 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_16 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_17 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_17 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_17 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_17 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_17 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_18 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_18 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_18 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_18 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_18 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_19 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_19 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_19 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_19 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_19 { get; set; }

        [StringLength(250)]
        public string RECIPIENT_UserName_20 { get; set; }

        [Column(TypeName = "image")]
        public byte[] RECIPIENT_AVATAR_PICTURE_20 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_LAST_NAME_20 { get; set; }

        [StringLength(50)]
        public string RECIPIENT_CURRENT_FIRST_NAME_20 { get; set; }

        [StringLength(500)]
        public string RECIPIENT_CURRENT_MIDDLE_NAME_20 { get; set; }

        public int? NUMBER_OF_LIKES { get; set; }

        public int? NUMBER_OF_SHARING { get; set; }

        public bool? DELETED { get; set; }

        [StringLength(250)]
        public string DELETED_SCRIPT { get; set; }

        [StringLength(500)]
        public string DELETED_UserName { get; set; }

        public DateTime? DELETED_DATETIME { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MESSAGE_FEED> MESSAGE_FEED1 { get; set; }

        public virtual MESSAGE_FEED MESSAGE_FEED2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERSON_LIKING_MESSAGE_FEED> PERSON_LIKING_MESSAGE_FEED { get; set; }
    }
}
