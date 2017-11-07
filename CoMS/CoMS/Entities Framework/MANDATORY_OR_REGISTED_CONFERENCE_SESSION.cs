namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MANDATORY_OR_REGISTED_CONFERENCE_SESSION
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal PERSON_ID { get; set; }

        [StringLength(50)]
        public string CURRENT_LAST_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_FIRST_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_MIDDLE_NAME { get; set; }

        [StringLength(255)]
        public string CURRENT_PERSONAL_TITLE { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CONFERENCE_SESSION_ID { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN { get; set; }

        public DateTime? START_DATETIME { get; set; }

        public DateTime? END_DATETIME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OVERLAPPING_CONFERENCE_SESSION_ID_1 { get; set; }

        [StringLength(250)]
        public string OVERLAPPING_MANDATORY_FUNCTION_OR_REGISTERED_SESSION_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OVERLAPPING_CONFERENCE_SESSION_ID_2 { get; set; }

        [StringLength(250)]
        public string OVERLAPPING_MANDATORY_FUNCTION_OR_REGISTERED_SESSION_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OVERLAPPING_CONFERENCE_SESSION_ID_3 { get; set; }

        [StringLength(250)]
        public string OVERLAPPING_MANDATORY_FUNCTION_OR_REGISTERED_SESSION_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OVERLAPPING_CONFERENCE_SESSION_ID_4 { get; set; }

        [StringLength(250)]
        public string OVERLAPPING_MANDATORY_FUNCTION_OR_REGISTERED_SESSION_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OVERLAPPING_CONFERENCE_SESSION_ID_5 { get; set; }

        [StringLength(250)]
        public string OVERLAPPING_MANDATORY_FUNCTION_OR_REGISTERED_SESSION_5 { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        public virtual CONFERENCE_SESSION CONFERENCE_SESSION { get; set; }

        public virtual PERSON PERSON { get; set; }
    }
}
