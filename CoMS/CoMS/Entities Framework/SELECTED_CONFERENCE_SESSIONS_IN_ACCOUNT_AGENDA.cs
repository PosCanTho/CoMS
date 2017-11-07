namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_ID { get; set; }

        public string CONFERENCE_NAME { get; set; }

        public string CONFERENCE_NAME_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_1 { get; set; }

        public DateTime? START_DATETIME_1 { get; set; }

        public DateTime? END_DATETIME_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_1 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_1 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_1 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_2 { get; set; }

        public DateTime? START_DATETIME_2 { get; set; }

        public DateTime? END_DATETIME_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_2 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_2 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_2 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_3 { get; set; }

        public DateTime? START_DATETIME_3 { get; set; }

        public DateTime? END_DATETIME_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_3 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_3 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_3 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_4 { get; set; }

        public DateTime? START_DATETIME_4 { get; set; }

        public DateTime? END_DATETIME_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_4 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_4 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_4 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_5 { get; set; }

        public DateTime? START_DATETIME_5 { get; set; }

        public DateTime? END_DATETIME_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_5 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_5 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_5 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_6 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_6 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_6 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_6 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_6 { get; set; }

        public DateTime? START_DATETIME_6 { get; set; }

        public DateTime? END_DATETIME_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_6 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_6 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_6 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_7 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_7 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_7 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_7 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_7 { get; set; }

        public DateTime? START_DATETIME_7 { get; set; }

        public DateTime? END_DATETIME_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_7 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_7 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_7 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_8 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_8 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_8 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_8 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_8 { get; set; }

        public DateTime? START_DATETIME_8 { get; set; }

        public DateTime? END_DATETIME_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_8 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_8 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_8 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_9 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_9 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_9 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_9 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_9 { get; set; }

        public DateTime? START_DATETIME_9 { get; set; }

        public DateTime? END_DATETIME_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_9 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_9 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_9 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_10 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_10 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_10 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_10 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_10 { get; set; }

        public DateTime? START_DATETIME_10 { get; set; }

        public DateTime? END_DATETIME_10 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_10 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_10 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_10 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_10 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_11 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_11 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_11 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_11 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_11 { get; set; }

        public DateTime? START_DATETIME_11 { get; set; }

        public DateTime? END_DATETIME_11 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_11 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_11 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_11 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_11 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_12 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_12 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_12 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_12 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_12 { get; set; }

        public DateTime? START_DATETIME_12 { get; set; }

        public DateTime? END_DATETIME_12 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_12 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_12 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_12 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_12 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_13 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_13 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_13 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_13 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_13 { get; set; }

        public DateTime? START_DATETIME_13 { get; set; }

        public DateTime? END_DATETIME_13 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_13 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_13 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_13 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_13 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_14 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_14 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_14 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_14 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_14 { get; set; }

        public DateTime? START_DATETIME_14 { get; set; }

        public DateTime? END_DATETIME_14 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_14 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_14 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_14 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_14 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_15 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_15 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_15 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_15 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_15 { get; set; }

        public DateTime? START_DATETIME_15 { get; set; }

        public DateTime? END_DATETIME_15 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_15 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_15 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_15 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_15 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_16 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_16 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_16 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_16 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_16 { get; set; }

        public DateTime? START_DATETIME_16 { get; set; }

        public DateTime? END_DATETIME_16 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_16 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_16 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_16 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_16 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_17 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_17 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_17 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_17 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_17 { get; set; }

        public DateTime? START_DATETIME_17 { get; set; }

        public DateTime? END_DATETIME_17 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_17 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_17 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_17 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_17 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_18 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_18 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_18 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_18 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_18 { get; set; }

        public DateTime? START_DATETIME_18 { get; set; }

        public DateTime? END_DATETIME_18 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_18 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_18 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_18 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_18 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_19 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_19 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_19 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_19 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_19 { get; set; }

        public DateTime? START_DATETIME_19 { get; set; }

        public DateTime? END_DATETIME_19 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_19 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_19 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_19 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_19 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_20 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_20 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_20 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_20 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_20 { get; set; }

        public DateTime? START_DATETIME_20 { get; set; }

        public DateTime? END_DATETIME_20 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_20 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_20 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_20 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_20 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_21 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_21 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_21 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_21 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_21 { get; set; }

        public DateTime? START_DATETIME_21 { get; set; }

        public DateTime? END_DATETIME_21 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_21 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_21 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_21 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_21 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_22 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_22 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_22 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_22 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_22 { get; set; }

        public DateTime? START_DATETIME_22 { get; set; }

        public DateTime? END_DATETIME_22 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_22 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_22 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_22 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_22 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_23 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_23 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_23 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_23 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_23 { get; set; }

        public DateTime? START_DATETIME_23 { get; set; }

        public DateTime? END_DATETIME_23 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_23 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_23 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_23 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_23 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_24 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_24 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_24 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_24 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_24 { get; set; }

        public DateTime? START_DATETIME_24 { get; set; }

        public DateTime? END_DATETIME_24 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_24 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_24 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_24 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_24 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_25 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_25 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_25 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_25 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_25 { get; set; }

        public DateTime? START_DATETIME_25 { get; set; }

        public DateTime? END_DATETIME_25 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_25 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_25 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_25 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_25 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_26 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_26 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_26 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_26 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_26 { get; set; }

        public DateTime? START_DATETIME_26 { get; set; }

        public DateTime? END_DATETIME_26 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_26 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_26 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_26 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_26 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_27 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_27 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_27 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_27 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_27 { get; set; }

        public DateTime? START_DATETIME_27 { get; set; }

        public DateTime? END_DATETIME_27 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_27 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_27 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_27 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_27 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_28 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_28 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_28 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_28 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_28 { get; set; }

        public DateTime? START_DATETIME_28 { get; set; }

        public DateTime? END_DATETIME_28 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_28 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_28 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_28 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_28 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_29 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_29 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_29 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_29 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_29 { get; set; }

        public DateTime? START_DATETIME_29 { get; set; }

        public DateTime? END_DATETIME_29 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_29 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_29 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_29 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_29 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_SESSION_ID_30 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_30 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_TOPIC_NAME_EN_30 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_30 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_SESSION_NAME_EN_30 { get; set; }

        public DateTime? START_DATETIME_30 { get; set; }

        public DateTime? END_DATETIME_30 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FACILITY_ID_30 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_30 { get; set; }

        [StringLength(255)]
        public string FACILITY_NAME_EN_30 { get; set; }

        [StringLength(250)]
        public string MANDATORY_FUNCTION_OR_REGISTERED_SESSION_OR_SELF_SELECTION_30 { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }
    }
}
