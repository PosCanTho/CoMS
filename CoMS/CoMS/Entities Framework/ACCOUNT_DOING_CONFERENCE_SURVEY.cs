namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACCOUNT_DOING_CONFERENCE_SURVEY
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CONFERENCE_SURVEY_ID { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_NAME { get; set; }

        [StringLength(250)]
        public string CONFERENCE_SURVEY_NAME_EN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string CURRENT_LAST_NAME { get; set; }

        [StringLength(50)]
        public string CURRENT_FIRST_NAME { get; set; }

        [StringLength(500)]
        public string CURRENT_MIDDLE_NAME { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime START_DATETIME { get; set; }

        public DateTime? END_DATETIME { get; set; }

        [StringLength(50)]
        public string COMPLETED_OR_UNCOMPLETED { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual CONFERENCE_SURVEY CONFERENCE_SURVEY { get; set; }
    }
}
