namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ANSWER_TO_CONFERENCE_SURVEY_QUESTION
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_SURVEY_QUESTION_ID { get; set; }

        public DateTime? START_DATETIME { get; set; }

        public DateTime? END_DATETIME { get; set; }

        public string CONFERENCE_SURVEY_QUESTION_ANSWER { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual CONFERENCE_SURVEY_QUESTION CONFERENCE_SURVEY_QUESTION { get; set; }
    }
}
