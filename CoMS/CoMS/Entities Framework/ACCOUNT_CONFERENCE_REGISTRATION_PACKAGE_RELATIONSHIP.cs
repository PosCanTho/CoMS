namespace CoMS.Entities_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CONFERENCE_REGISTRATION_PACKAGE_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string CONFERENCE_REGISTRATION_PACKAGE_HANDLING { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime FROM_DATE { get; set; }

        public DateTime? THRU_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PAYMENT_AMOUNT { get; set; }

        [StringLength(150)]
        public string PAYMENT_AMOUNT_CURRENCY_UOM_NAME { get; set; }

        public bool? PAID_IN_FULL { get; set; }

        public DateTime? PAYMENT_DATETIME { get; set; }

        [StringLength(500)]
        public string PAYMENT_IP_ADDRESS { get; set; }

        [StringLength(500)]
        public string BANK_TRANSFER_NOTE { get; set; }

        [StringLength(500)]
        public string BANK_TRANSFER_NOTE_EN { get; set; }

        [StringLength(150)]
        public string BANK_TRANSFER_PAYMENT_REFERENCE_NUMBER { get; set; }

        [StringLength(150)]
        public string CREDIT_CARD_NUMBER { get; set; }

        [StringLength(250)]
        public string CREDIT_CARD_FULL_NAME { get; set; }

        public short? CREDIT_CARD_EXPIRATION_MONTH { get; set; }

        public int? CREDIT_CARD_EXPIRATION_YEAR { get; set; }

        public int? CREDIT_CARD_SECURITY_CODE { get; set; }

        [StringLength(255)]
        public string CREDIT_CARD_ADDRESS { get; set; }

        [StringLength(100)]
        public string CREDIT_CARD_WARD { get; set; }

        [StringLength(100)]
        public string CREDIT_CARD_DISTRICT { get; set; }

        [StringLength(100)]
        public string CREDIT_CARD_CITY { get; set; }

        [StringLength(50)]
        public string CREDIT_CARD_STATE { get; set; }

        [StringLength(15)]
        public string CREDIT_CARD_ZIPCODE { get; set; }

        [StringLength(100)]
        public string CREDIT_CARD_COUNTRY { get; set; }

        [StringLength(50)]
        public string CREDIT_CARD_PHONE { get; set; }

        [StringLength(500)]
        public string CREDIT_CARD_NOTE { get; set; }

        [StringLength(500)]
        public string CREDIT_CARD_NOTE_EN { get; set; }

        [StringLength(250)]
        public string CREDIT_CARD_TRANSACTION_ID { get; set; }

        [StringLength(500)]
        public string PAYPAL_PAYMENT_NOTE { get; set; }

        [StringLength(250)]
        public string PAYPAL_PAYMENT_TRANSACTION_ID { get; set; }

        [StringLength(250)]
        public string CHECK_PAYMENT_STATUS_NAME { get; set; }

        [StringLength(250)]
        public string CHECK_PAYMENT_STATUS_NAME_EN { get; set; }

        [StringLength(500)]
        public string CHECK_PAYMENT_NOTE { get; set; }

        [StringLength(500)]
        public string CHECK_PAYMENT_NOTE_EN { get; set; }

        [StringLength(250)]
        public string CHECK_PAYMENT_NUMBER { get; set; }

        [StringLength(250)]
        public string ONSITE_CASH_PAYMENT_STATUS_NAME { get; set; }

        [StringLength(500)]
        public string ONSITE_CASH_PAYMENT_NOTE { get; set; }

        [StringLength(500)]
        public string ONSITE_CASH_PAYMENT_NOTE_EN { get; set; }

        [StringLength(50)]
        public string ONSITE_CASH_PAYMENT_PAYEE_LAST_NAME { get; set; }

        [StringLength(50)]
        public string ONSITE_CASH_PAYMENT_PAYEE_FIRST_NAME { get; set; }

        [StringLength(500)]
        public string ONSITE_CASH_PAYMENT_PAYEE_MIDDLE_NAME { get; set; }

        [StringLength(50)]
        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERINGS_ACCEPTED_OR_REJECTED { get; set; }

        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERINGS_ACCEPTANCE_NOTE { get; set; }

        public string CONFERENCE_REGISTRATION_PACKAGE_OFFERINGS_REJECTION_REASONS { get; set; }

        public DateTime? CANCELLATION_DATE { get; set; }

        [StringLength(500)]
        public string CANCELLATION_DEADLINE_NAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_FEE_AMOUNT { get; set; }

        [StringLength(150)]
        public string CANCELLATION_FEE_AMOUNT_CURRENCY_UOM_NAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_REFUND_AMOUNT { get; set; }

        [StringLength(150)]
        public string CANCELLATION_REFUND_AMOUNT_CURRENCY_UOM_NAME { get; set; }

        public bool? CANCELLATION_REFUND_BANK_TRANSFER_SELECTED { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_REFUND_BANK_TRANSFER_AMOUNT { get; set; }

        [StringLength(150)]
        public string CANCELLATION_REFUND_BANK_TRANSFER_AMOUNT_CURRENCY_UOM_NAME { get; set; }

        public DateTime? CANCELLATION_REFUND_BANK_TRANSFER_DATE { get; set; }

        [StringLength(500)]
        public string CANCELLATION_REFUND_BANK_TRANSFER_PROCESSED_UserName { get; set; }

        public bool? CANCELLATION_REFUND_CREDIT_CARD_PAYMENT_SELECTED { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_REFUND_CREDIT_CARD_PAYMENT_AMOUNT { get; set; }

        [StringLength(150)]
        public string CANCELLATION_REFUND_CREDIT_CARD_PAYMENT_AMOUNT_CURRENCY_UOM_NAME { get; set; }

        public DateTime? CANCELLATION_REFUND_CREDIT_CARD_PAYMENT_DATE { get; set; }

        [StringLength(500)]
        public string CANCELLATION_REFUND_CREDIT_CARD_PAYMENT_PROCESSED_UserName { get; set; }

        public bool? CANCELLATION_REFUND_PAYPAL_PAYMENT_SELECTED { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_REFUND_PAYPAL_PAYMENT_AMOUNT { get; set; }

        [StringLength(150)]
        public string CANCELLATION_REFUND_PAYPAL_PAYMENT_AMOUNT_CURRENCY_UOM_NAME { get; set; }

        public DateTime? CANCELLATION_REFUND_PAYPAL_PAYMENT_DATE { get; set; }

        [StringLength(500)]
        public string CANCELLATION_REFUND_PAYPAL_PAYMENT_PROCESSED_UserName { get; set; }

        public bool? CANCELLATION_REFUND_CHECK_PAYMENT_SELECTED { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_REFUND_CHECK_PAYMENT_AMOUNT { get; set; }

        [StringLength(150)]
        public string CANCELLATION_REFUND_CHECK_PAYMENT_AMOUNT_CURRENCY_UOM_NAME { get; set; }

        public DateTime? CANCELLATION_REFUND_CHECK_PAYMENT_DATE { get; set; }

        [StringLength(500)]
        public string CANCELLATION_REFUND_CHECK_PAYMENT_PROCESSED_UserName { get; set; }

        public bool? CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_SELECTED { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_AMOUNT { get; set; }

        [StringLength(150)]
        public string CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_AMOUNT_CURRENCY_UOM_NAME { get; set; }

        public DateTime? CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_DATE { get; set; }

        [StringLength(500)]
        public string CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_PROCESSED_UserName { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual CONFERENCE_REGISTRATION_PACKAGE CONFERENCE_REGISTRATION_PACKAGE { get; set; }
    }
}
