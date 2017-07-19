namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CONFERENCE_SESSION_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        public bool? MC_ROLE { get; set; }

        [StringLength(150)]
        public string MC_ROLE_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MC_ROLE_SETTING_PERSON_ID { get; set; }

        public DateTime? MC_ROLE_SETTING_DATE { get; set; }

        public string MC_ROLE_NOTE { get; set; }

        public string MC_ROLE_NOTE_EN { get; set; }

        public bool? TRANSLATOR_ROLE { get; set; }

        [StringLength(150)]
        public string TRANSLATOR_ROLE_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TRANSLATOR_ROLE_SETTING_PERSON_ID { get; set; }

        public DateTime? TRANSLATOR_ROLE_SETTING_DATE { get; set; }

        public string TRANSLATOR_ROLE_NOTE { get; set; }

        public string TRANSLATOR_ROLE_NOTE_EN { get; set; }

        public bool? FandB_SUPPORT_ROLE { get; set; }

        [StringLength(150)]
        public string FandB_SUPPORT_ROLE_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FandB_SUPPORT_ROLE_SETTING_PERSON_ID { get; set; }

        public DateTime? FandB_SUPPORT_ROLE_SETTING_DATE { get; set; }

        public string FandB_SUPPORT_ROLE_NOTE { get; set; }

        public string FandB_SUPPORT_ROLE_NOTE_EN { get; set; }

        public bool? TECHNICAL_SUPPORT_ROLE { get; set; }

        [StringLength(150)]
        public string TECHNICAL_SUPPORT_ROLE_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TECHNICAL_SUPPORT_ROLE_SETTING_PERSON_ID { get; set; }

        public DateTime? TECHNICAL_SUPPORT_ROLE_SETTING_DATE { get; set; }

        public string TECHNICAL_SUPPORT_ROLE_NOTE { get; set; }

        public string TECHNICAL_SUPPORT_ROLE_NOTE_EN { get; set; }

        public virtual CONFERENCE_SESSION CONFERENCE_SESSION { get; set; }

        public virtual SUPPORT_STAFF SUPPORT_STAFF { get; set; }
    }
}
