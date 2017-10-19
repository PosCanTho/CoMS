namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFERENCE_REGISTRATION_PACKAGE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONFERENCE_REGISTRATION_PACKAGE()
        {
            ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP = new HashSet<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>();
            REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE = new HashSet<REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_ID { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_NAME { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_NAME_EN { get; set; }

        public DateTime? EFFECTIVE_FROM_DATE { get; set; }

        public DateTime? EFFECTIVE_THRU_DATE { get; set; }

        public string DESCRIPTION { get; set; }

        public string DESCRIPTION_EN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_VALUE { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_VALUE_CURRENCY_UOM_NAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_PRICE { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_PRICE_CURRENCY_UOM_NAME { get; set; }

        public bool? BANK_TRANSFER_ACCEPTED { get; set; }

        [StringLength(500)]
        public string BANK_ACCOUNT_NAME { get; set; }

        [StringLength(150)]
        public string BANK_ACCOUNT_NUMBER { get; set; }

        [StringLength(150)]
        public string BANK_ROUTING_NUMBER { get; set; }

        [StringLength(150)]
        public string BANK_IBAN { get; set; }

        [StringLength(150)]
        public string BANK_BIC_SWIFT_CODE { get; set; }

        [StringLength(255)]
        public string BANK_BRANCH_ADDRESS { get; set; }

        [StringLength(100)]
        public string BANK_BRANCH_WARD { get; set; }

        [StringLength(100)]
        public string BANK_BRANCH_DISTRICT { get; set; }

        [StringLength(100)]
        public string BANK_BRANCH_CITY { get; set; }

        [StringLength(50)]
        public string BANK_BRANCH_STATE { get; set; }

        [StringLength(15)]
        public string BANK_BRANCH_ZIPCODE { get; set; }

        [StringLength(100)]
        public string BANK_BRANCH_COUNTRY { get; set; }

        [StringLength(50)]
        public string BANK_BRANCH_PHONE { get; set; }

        [StringLength(50)]
        public string BANK_BRANCH_EMAIL { get; set; }

        [StringLength(250)]
        public string BANK_BRANCH_WEBSITE { get; set; }

        [StringLength(500)]
        public string BANK_TRANSFER_NOTE_TEMPLATE { get; set; }

        [StringLength(250)]
        public string BANK_TRANSFER_ACCEPTED_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BANK_TRANSFER_SETTING_PERSON_ID { get; set; }

        public DateTime? BANK_TRANSFER_SETTING_DATE { get; set; }

        public bool? CREDIT_CARD_PAYMENT_ACCEPTED { get; set; }

        public bool? CREDIT_CARD_VISA_ACCEPTED { get; set; }

        public bool? CREDIT_CARD_MASTERCARD_ACCEPTED { get; set; }

        public bool? CREDIT_CARD_AMERICANEXPRESS_ACCEPTED { get; set; }

        public bool? CREDIT_CARD_DISCOVER_ACCEPTED { get; set; }

        public bool? CREDIT_CARD_JCB_ACCEPTED { get; set; }

        public bool? CREDIT_DINERSCLUBINTERNATIONAL_ACCEPTED { get; set; }

        [StringLength(500)]
        public string CREDIT_CARD_PAYMENT_NOTE_TEMPLATE { get; set; }

        [StringLength(250)]
        public string CREDIT_CARD_PAYMENT_ACCEPTED_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CREDIT_CARD_PAYMENT_SETTING_PERSON_ID { get; set; }

        public DateTime? CREDIT_CARD_PAYMENT_SETTING_DATE { get; set; }

        public bool? PAYPAL_PAYMENT_ACCEPTED { get; set; }

        [StringLength(250)]
        public string PAYPAL_PAYMENT_ACCEPTED_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAYPAL_PAYMENT_SETTING_PERSON_ID { get; set; }

        public DateTime? PAYPAL_PAYMENT_SETTING_DATE { get; set; }

        public bool? CHECK_PAYMENT_ACCEPTED { get; set; }

        [StringLength(500)]
        public string CHECK_PAY_TO_THE_ORDER_OF { get; set; }

        [StringLength(500)]
        public string CHECK_PAY_TO_THE_ORDER_OF_EN { get; set; }

        [StringLength(500)]
        public string CHECK_PAYMENT_NOTE_TEMPLATE { get; set; }

        public string CHECK_PAYMENT_DESCRIPTION { get; set; }

        public string CHECK_PAYMENT_DESCRIPTION_EN { get; set; }

        [StringLength(250)]
        public string CHECK_PAYMENT_ACCEPTED_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CHECK_PAYMENT_SETTING_PERSON_ID { get; set; }

        public DateTime? CHECK_PAYMENT_SETTING_DATE { get; set; }

        public bool? ONSITE_CASH_PAYMENT_ACCEPTED { get; set; }

        public string ONSITE_CASH_PAYMENT_DESCRIPTION { get; set; }

        public string ONSITE_CASH_PAYMENT_DESCRIPTION_EN { get; set; }

        [StringLength(250)]
        public string ONSITE_CASH_PAYMENT_ACCEPTED_SCRIPT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ONSITE_CASH_PAYMENT_SETTING_PERSON_ID { get; set; }

        public DateTime? ONSITE_CASH_PAYMENT_SETTING_DATE { get; set; }

        [StringLength(500)]
        public string CANCELLATION_DEADLINE_NAME_1 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_START_1 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_END_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_FEE_AMOUNT_1 { get; set; }

        [StringLength(150)]
        public string CANCELLATION_FEE_AMOUNT_CURRENCY_UOM_NAME_1 { get; set; }

        public bool? CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_1 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_SCRIPT_1 { get; set; }

        public bool? CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_1 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_SCRIPT_1 { get; set; }

        public bool? CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_1 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_SCRIPT_1 { get; set; }

        public bool? CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_1 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_SCRIPT_1 { get; set; }

        public bool? CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_1 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_SCRIPT_1 { get; set; }

        [StringLength(500)]
        public string CANCELLATION_DEADLINE_NAME_2 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_START_2 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_END_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_FEE_AMOUNT_2 { get; set; }

        [StringLength(150)]
        public string CANCELLATION_FEE_AMOUNT_CURRENCY_UOM_NAME_2 { get; set; }

        public bool? CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_2 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_SCRIPT_2 { get; set; }

        public bool? CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_2 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_SCRIPT_2 { get; set; }

        public bool? CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_2 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_SCRIPT_2 { get; set; }

        public bool? CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_2 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_SCRIPT_2 { get; set; }

        public bool? CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_2 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_SCRIPT_2 { get; set; }

        [StringLength(500)]
        public string CANCELLATION_DEADLINE_NAME_3 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_START_3 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_END_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_FEE_AMOUNT_3 { get; set; }

        [StringLength(150)]
        public string CANCELLATION_FEE_AMOUNT_CURRENCY_UOM_NAME_3 { get; set; }

        public bool? CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_3 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_SCRIPT_3 { get; set; }

        public bool? CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_3 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_SCRIPT_3 { get; set; }

        public bool? CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_3 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_SCRIPT_3 { get; set; }

        public bool? CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_3 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_SCRIPT_3 { get; set; }

        public bool? CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_3 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_SCRIPT_3 { get; set; }

        [StringLength(500)]
        public string CANCELLATION_DEADLINE_NAME_4 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_START_4 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_END_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_FEE_AMOUNT_4 { get; set; }

        [StringLength(150)]
        public string CANCELLATION_FEE_AMOUNT_CURRENCY_UOM_NAME_4 { get; set; }

        public bool? CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_4 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_SCRIPT_4 { get; set; }

        public bool? CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_4 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_SCRIPT_4 { get; set; }

        public bool? CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_4 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_SCRIPT_4 { get; set; }

        public bool? CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_4 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_SCRIPT_4 { get; set; }

        public bool? CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_4 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_SCRIPT_4 { get; set; }

        [StringLength(500)]
        public string CANCELLATION_DEADLINE_NAME_5 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_START_5 { get; set; }

        public DateTime? CANCELLATION_DEADLINE_TIMERANGE_END_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_FEE_AMOUNT_5 { get; set; }

        [StringLength(150)]
        public string CANCELLATION_FEE_AMOUNT_CURRENCY_UOM_NAME_5 { get; set; }

        public bool? CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_5 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_BANK_TRANSFER_ACCEPTED_SCRIPT_5 { get; set; }

        public bool? CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_5 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CREDIIT_CARD_PAYMENT_ACCEPTED_SCRIPT_5 { get; set; }

        public bool? CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_5 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_PAYPAL_PAYMENT_ACCEPTED_SCRIPT_5 { get; set; }

        public bool? CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_5 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_CHECK_PAYMENT_ACCEPTED_SCRIPT_5 { get; set; }

        public bool? CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_5 { get; set; }

        [StringLength(250)]
        public string CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_ACCEPTED_SCRIPT_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_1 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_1 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_2 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_2 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_3 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_3 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_4 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_4 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_5 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_5 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_6 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_6 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_6 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_6 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_6 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_7 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_7 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_7 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_7 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_7 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_8 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_8 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_8 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_8 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_8 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_9 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_9 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_9 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_9 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_9 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_10 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_10 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_NAME_EN_10 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_10 { get; set; }

        [StringLength(500)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_DESCRIPTION_EN_10 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_10 { get; set; }

        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_CURRENCY_UOM_NAME_10 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_10 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP> ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP { get; set; }

        public virtual CONFERENCE CONFERENCE { get; set; }

        public virtual CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE> REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE { get; set; }
    }
}
