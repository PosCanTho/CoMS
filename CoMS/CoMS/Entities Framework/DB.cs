namespace CoMS.Entities_Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP> ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP { get; set; }
        public virtual DbSet<ACCOUNT_DEVICE_RELATIONSHIP> ACCOUNT_DEVICE_RELATIONSHIP { get; set; }
        public virtual DbSet<ACCOUNT_DOING_CONFERENCE_SURVEY> ACCOUNT_DOING_CONFERENCE_SURVEY { get; set; }
        public virtual DbSet<ACCOUNT_FOR_CONFERENCE> ACCOUNT_FOR_CONFERENCE { get; set; }
        public virtual DbSet<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP> ACCOUNT_MESSAGING_GROUP_MEMBERSHIP { get; set; }
        public virtual DbSet<ALL_TYPE_NAME> ALL_TYPE_NAME { get; set; }
        public virtual DbSet<ANSWER_TO_CONFERENCE_SURVEY_QUESTION> ANSWER_TO_CONFERENCE_SURVEY_QUESTION { get; set; }
        public virtual DbSet<APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE> APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE { get; set; }
        public virtual DbSet<APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS> APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS { get; set; }
        public virtual DbSet<APPROVED_CONFERENCE_ATTENDEE_TYPES> APPROVED_CONFERENCE_ATTENDEE_TYPES { get; set; }
        public virtual DbSet<AUTHOR> AUTHORs { get; set; }
        public virtual DbSet<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP> AUTHOR_PAPER_ABSTRACT_RELATIONSHIP { get; set; }
        public virtual DbSet<AUTHOR_PAPER_TEXT_RELATIONSHIP> AUTHOR_PAPER_TEXT_RELATIONSHIP { get; set; }
        public virtual DbSet<CONFERENCE> CONFERENCEs { get; set; }
        public virtual DbSet<CONFERENCE_ATTENDEE> CONFERENCE_ATTENDEE { get; set; }
        public virtual DbSet<CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION> CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION { get; set; }
        public virtual DbSet<CONFERENCE_ATTENDEE_TYPE> CONFERENCE_ATTENDEE_TYPE { get; set; }
        public virtual DbSet<CONFERENCE_BOARD_OF_REVIEW> CONFERENCE_BOARD_OF_REVIEW { get; set; }
        public virtual DbSet<CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP> CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP { get; set; }
        public virtual DbSet<CONFERENCE_PRESENTATION_TYPE> CONFERENCE_PRESENTATION_TYPE { get; set; }
        public virtual DbSet<CONFERENCE_REGISTRATION_PACKAGE> CONFERENCE_REGISTRATION_PACKAGE { get; set; }
        public virtual DbSet<CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS> CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS { get; set; }
        public virtual DbSet<CONFERENCE_REGISTRATION_PACKAGE_OFFERING> CONFERENCE_REGISTRATION_PACKAGE_OFFERING { get; set; }
        public virtual DbSet<CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE> CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE { get; set; }
        public virtual DbSet<CONFERENCE_SESSION> CONFERENCE_SESSION { get; set; }
        public virtual DbSet<CONFERENCE_SESSION_CHAIR> CONFERENCE_SESSION_CHAIR { get; set; }
        public virtual DbSet<CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP> CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP { get; set; }
        public virtual DbSet<CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT> CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT { get; set; }
        public virtual DbSet<CONFERENCE_SESSION_TOPIC> CONFERENCE_SESSION_TOPIC { get; set; }
        public virtual DbSet<CONFERENCE_SETTING_RIGHTS> CONFERENCE_SETTING_RIGHTS { get; set; }
        public virtual DbSet<CONFERENCE_SURVEY> CONFERENCE_SURVEY { get; set; }
        public virtual DbSet<CONFERENCE_SURVEY_QUESTION> CONFERENCE_SURVEY_QUESTION { get; set; }
        public virtual DbSet<CONFERENCE_TYPE> CONFERENCE_TYPE { get; set; }
        public virtual DbSet<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP> CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP { get; set; }
        public virtual DbSet<COUNTRY> COUNTRies { get; set; }
        public virtual DbSet<FACILITY> FACILITies { get; set; }
        public virtual DbSet<FIELD_OF_STUDY> FIELD_OF_STUDY { get; set; }
        public virtual DbSet<FOLLOWER_RELATIONSHIP> FOLLOWER_RELATIONSHIP { get; set; }
        public virtual DbSet<GENDER_TYPE> GENDER_TYPE { get; set; }
        public virtual DbSet<LINE_OF_BUSINES_TYPE> LINE_OF_BUSINES_TYPE { get; set; }
        public virtual DbSet<MANDATORY_OR_REGISTED_CONFERENCE_SESSION> MANDATORY_OR_REGISTED_CONFERENCE_SESSION { get; set; }
        public virtual DbSet<MESSAGE_FEED> MESSAGE_FEED { get; set; }
        public virtual DbSet<MESSAGING_GROUP> MESSAGING_GROUP { get; set; }
        public virtual DbSet<MOBILEFORM_FUNCTION> MOBILEFORM_FUNCTION { get; set; }
        public virtual DbSet<MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU> MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU { get; set; }
        public virtual DbSet<MOBILEFORM_GROUP> MOBILEFORM_GROUP { get; set; }
        public virtual DbSet<MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE> MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE { get; set; }
        public virtual DbSet<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE> MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE { get; set; }
        public virtual DbSet<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE> MOBILEFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }
        public virtual DbSet<MOBILEFORM_MENU> MOBILEFORM_MENU { get; set; }
        public virtual DbSet<ORGANIZATION> ORGANIZATIONs { get; set; }
        public virtual DbSet<PAPER_ABSTRACT> PAPER_ABSTRACT { get; set; }
        public virtual DbSet<PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW> PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW { get; set; }
        public virtual DbSet<PAPER_TEXT> PAPER_TEXT { get; set; }
        public virtual DbSet<PERSON> People { get; set; }
        public virtual DbSet<PERSON_LIKING_MESSAGE_FEED> PERSON_LIKING_MESSAGE_FEED { get; set; }
        public virtual DbSet<PRESENTER> PRESENTERs { get; set; }
        public virtual DbSet<PRESENTER_CONFERENCE_SESSION_RELATIONSHIP> PRESENTER_CONFERENCE_SESSION_RELATIONSHIP { get; set; }
        public virtual DbSet<REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE> REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE { get; set; }
        public virtual DbSet<REVIEWER> REVIEWERs { get; set; }
        public virtual DbSet<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP> REVIEWER_PAPER_ABSTRACT_RELATIONSHIP { get; set; }
        public virtual DbSet<REVIEWER_PAPER_TEXT_RELATIONSHIP> REVIEWER_PAPER_TEXT_RELATIONSHIP { get; set; }
        public virtual DbSet<SAMPLE_CONFERENCE_SURVEY_QUESTION> SAMPLE_CONFERENCE_SURVEY_QUESTION { get; set; }
        public virtual DbSet<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA> SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA { get; set; }
        public virtual DbSet<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE> SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE { get; set; }
        public virtual DbSet<SUPPORT_STAFF> SUPPORT_STAFF { get; set; }
        public virtual DbSet<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP> SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP { get; set; }
        public virtual DbSet<TYPE_OF_STUDY> TYPE_OF_STUDY { get; set; }
        public virtual DbSet<WEBFORM_FUNCTION> WEBFORM_FUNCTION { get; set; }
        public virtual DbSet<WEBFORM_FUNCTION_FOR_WEBFORM_MENU> WEBFORM_FUNCTION_FOR_WEBFORM_MENU { get; set; }
        public virtual DbSet<WEBFORM_GROUP> WEBFORM_GROUP { get; set; }
        public virtual DbSet<WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE> WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE { get; set; }
        public virtual DbSet<WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE> WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE { get; set; }
        public virtual DbSet<WEBFORM_GROUP_MENU_FOR_CONFERENCE> WEBFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }
        public virtual DbSet<WEBFORM_MENU> WEBFORM_MENU { get; set; }
        public virtual DbSet<WINFORM_FUNCTION> WINFORM_FUNCTION { get; set; }
        public virtual DbSet<WINFORM_FUNCTION_FOR_WINFORM_MENU> WINFORM_FUNCTION_FOR_WINFORM_MENU { get; set; }
        public virtual DbSet<WINFORM_GROUP> WINFORM_GROUP { get; set; }
        public virtual DbSet<WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE> WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE { get; set; }
        public virtual DbSet<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE> WINFORM_GROUP_FUNCTION_FOR_CONFERENCE { get; set; }
        public virtual DbSet<WINFORM_GROUP_MENU_FOR_CONFERENCE> WINFORM_GROUP_MENU_FOR_CONFERENCE { get; set; }
        public virtual DbSet<WINFORM_MENU> WINFORM_MENU { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.CURRENT_GENDER)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.CURRENT_HOME_ORGANIZATION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasOptional(e => e.ACCOUNT_DEVICE_RELATIONSHIP)
                .WithRequired(e => e.ACCOUNT);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.ACCOUNT_DOING_CONFERENCE_SURVEY)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.ACCOUNT_FOR_CONFERENCE)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.ANSWER_TO_CONFERENCE_SURVEY_QUESTION)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.FOLLOWER_RELATIONSHIP)
                .WithRequired(e => e.ACCOUNT)
                .HasForeignKey(e => e.FOLLOWED_UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.FOLLOWER_RELATIONSHIP1)
                .WithRequired(e => e.ACCOUNT1)
                .HasForeignKey(e => e.FOLLOWING_UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.MESSAGE_FEED)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.PAYMENT_AMOUNT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_FEE_AMOUNT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_AMOUNT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_BANK_TRANSFER_AMOUNT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_BANK_TRANSFER_PROCESSED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_CREDIT_CARD_PAYMENT_AMOUNT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_CREDIT_CARD_PAYMENT_PROCESSED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_PAYPAL_PAYMENT_AMOUNT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_PAYPAL_PAYMENT_PROCESSED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_CHECK_PAYMENT_AMOUNT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_CHECK_PAYMENT_PROCESSED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_AMOUNT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP>()
                .Property(e => e.CANCELLATION_REFUND_ONSITE_CASH_PAYMENT_PROCESSED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_DEVICE_RELATIONSHIP>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_DEVICE_RELATIONSHIP>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_DOING_CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_DOING_CONFERENCE_SURVEY>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.Reg_GenforConf_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.Reg_GenforConf_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ADMIN_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.REVIEWER_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.AUTHOR_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.PRESENTER_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ATTENDEE_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.SUPPORT_STAFF_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .HasMany(e => e.MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE)
                .WithRequired(e => e.ACCOUNT_FOR_CONFERENCE)
                .HasForeignKey(e => new { e.UserName, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .HasMany(e => e.WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE)
                .WithRequired(e => e.ACCOUNT_FOR_CONFERENCE)
                .HasForeignKey(e => new { e.UserName, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT_FOR_CONFERENCE>()
                .HasMany(e => e.WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE)
                .WithRequired(e => e.ACCOUNT_FOR_CONFERENCE)
                .HasForeignKey(e => new { e.UserName, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP>()
                .Property(e => e.MESSAGING_GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT_MESSAGING_GROUP_MEMBERSHIP>()
                .Property(e => e.DELETED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ANSWER_TO_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ANSWER_TO_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_CONDITION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE>()
                .Property(e => e.GENDER_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_CONDITION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS>()
                .Property(e => e.CONFERENCE_ATTENDEE_LINE_OF_BUSINESS_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<APPROVED_CONFERENCE_ATTENDEE_TYPES>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_CONDITION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<APPROVED_CONFERENCE_ATTENDEE_TYPES>()
                .Property(e => e.CONFERENCE_ATTENDEE_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR>()
                .HasMany(e => e.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP)
                .WithRequired(e => e.AUTHOR)
                .HasForeignKey(e => new { e.PERSON_ID, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AUTHOR>()
                .HasMany(e => e.AUTHOR_PAPER_TEXT_RELATIONSHIP)
                .WithRequired(e => e.AUTHOR)
                .HasForeignKey(e => new { e.PERSON_ID, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.PAPER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.PAPER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AUTHOR_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.ORGANIZATION_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.CONFERENCE_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_6)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_7)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_8)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_9)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.ORGANIZING_ORGANIZATION_ID_10)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.MAIN_FIELD_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_STEP)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_START_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.SUGGESTED_PAPER_ABSTRACT_REVIEW_RATING_SCALE_END_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_STEP)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_START_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE>()
                .Property(e => e.SUGGESTED_PAPER_TEXT_REVIEW_RATING_SCALE_END_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.ACCOUNT_FOR_CONFERENCE)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.AUTHORs)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.CONFERENCE_ATTENDEE)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.CONFERENCE_SESSION_CHAIR)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.CONFERENCE_SESSION)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.CONFERENCE_SURVEY)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.FOLLOWER_RELATIONSHIP)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.MANDATORY_OR_REGISTED_CONFERENCE_SESSION)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.MESSAGE_FEED)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.MESSAGING_GROUP)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.MOBILEFORM_GROUP_MENU_FOR_CONFERENCE)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.PRESENTERs)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.REVIEWERs)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.CONFERENCE_SESSION_TOPIC)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.SUPPORT_STAFF)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.WEBFORM_GROUP_MENU_FOR_CONFERENCE)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.WINFORM_GROUP_FUNCTION_FOR_CONFERENCE)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE>()
                .HasMany(e => e.WINFORM_GROUP_MENU_FOR_CONFERENCE)
                .WithRequired(e => e.CONFERENCE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.CURRENT_HOME_ORGANIZATION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_6)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_7)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_8)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_9)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .Property(e => e.REGISTERED_CONFERENCE_REGISTRATION_PACKAGE_ID_10)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE>()
                .HasMany(e => e.CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION)
                .WithRequired(e => e.CONFERENCE_ATTENDEE)
                .HasForeignKey(e => new { e.PERSON_ID, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION>()
                .Property(e => e.CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE_TYPE>()
                .Property(e => e.CONFERENCE_ATTENDEE_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_ATTENDEE_TYPE>()
                .HasMany(e => e.APPROVED_CONFERENCE_ATTENDEE_TYPES)
                .WithRequired(e => e.CONFERENCE_ATTENDEE_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.CONFERENCE_BOARD_OF_REVIEW_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.ROOT_CONFERENCE_BOARD_OF_REVIEW_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_ABSTRACT_REVIEW_RATING_SCALE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_ABSTRACT_REVIEW_RATING_SCALE_STEP)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_ABSTRACT_REVIEW_RATING_SCALE_START_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_ABSTRACT_REVIEW_RATING_SCALE_END_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_TEXT_REVIEW_RATING_SCALE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_TEXT_REVIEW_RATING_SCALE_STEP)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_TEXT_REVIEW_RATING_SCALE_START_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_TEXT_REVIEW_RATING_SCALE_END_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_ABSTRACT_AUTOMATIC_APPROVAL_PERCENTILE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_ABSTRACT_AUTOMATIC_REJECTION_PERCENTILE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_TEXT_AUTOMATIC_APPROVAL_PERCENTILE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_TEXT_AUTOMATIC_REJECTION_PERCENTILE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_BOARD_OF_REVIEW>()
                .HasMany(e => e.REVIEWERs)
                .WithRequired(e => e.CONFERENCE_BOARD_OF_REVIEW)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP>()
                .Property(e => e.FIELD_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_PRESENTATION_TYPE>()
                .Property(e => e.CONFERENCE_PRESENTATION_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_PRESENTATION_TYPE>()
                .HasMany(e => e.SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE)
                .WithRequired(e => e.CONFERENCE_PRESENTATION_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_VALUE)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_PRICE)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.BANK_TRANSFER_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CREDIT_CARD_PAYMENT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.PAYPAL_PAYMENT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CHECK_PAYMENT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.ONSITE_CASH_PAYMENT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CANCELLATION_FEE_AMOUNT_1)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CANCELLATION_FEE_AMOUNT_2)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CANCELLATION_FEE_AMOUNT_3)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CANCELLATION_FEE_AMOUNT_4)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CANCELLATION_FEE_AMOUNT_5)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_1)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_2)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_3)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_4)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_5)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_6)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_6)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_7)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_7)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_8)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_8)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_9)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_9)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID_10)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE_10)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.PREREQUISITE_CONFERENCE_REGISTRATION_PACKAGE_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_6)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_7)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_8)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_9)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.EXCLUDED_CONFERENCE_REGISTRATION_PACKAGE_ID_10)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .HasMany(e => e.ACCOUNT_CONFERENCE_REGISTRATION_PACKAGE_RELATIONSHIP)
                .WithRequired(e => e.CONFERENCE_REGISTRATION_PACKAGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .HasOptional(e => e.CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS)
                .WithRequired(e => e.CONFERENCE_REGISTRATION_PACKAGE);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE>()
                .HasMany(e => e.REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE)
                .WithRequired(e => e.CONFERENCE_REGISTRATION_PACKAGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_CONDITION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS>()
                .HasMany(e => e.APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE)
                .WithRequired(e => e.CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS>()
                .HasMany(e => e.APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS)
                .WithRequired(e => e.CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS>()
                .HasMany(e => e.APPROVED_CONFERENCE_ATTENDEE_TYPES)
                .WithRequired(e => e.CONFERENCE_REGISTRATION_PACKAGE_CONDITIONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE_OFFERING>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE_OFFERING>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE_OFFERING>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE_OFFERING>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_VALUE)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .Property(e => e.CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .Property(e => e.CONFERENCE_SESSION_TOPIC_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .Property(e => e.FACILITY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .Property(e => e.PRESENTATION_REVIEW_RATING_SCALE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .Property(e => e.PRESENTATION_REVIEW_RATING_SCALE_STEP)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .Property(e => e.PRESENTATION_REVIEW_RATING_SCALE_START_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .Property(e => e.PRESENTATION_REVIEW_RATING_SCALE_END_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .HasMany(e => e.CONFERENCE_ATTENDEE_IN_REGISTERED_CONFERENCE_SESSION)
                .WithRequired(e => e.CONFERENCE_SESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .HasMany(e => e.CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP)
                .WithRequired(e => e.CONFERENCE_SESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .HasMany(e => e.CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT)
                .WithRequired(e => e.CONFERENCE_SESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .HasMany(e => e.MANDATORY_OR_REGISTED_CONFERENCE_SESSION)
                .WithRequired(e => e.CONFERENCE_SESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .HasMany(e => e.PRESENTER_CONFERENCE_SESSION_RELATIONSHIP)
                .WithRequired(e => e.CONFERENCE_SESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .HasMany(e => e.REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE)
                .WithRequired(e => e.CONFERENCE_SESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .HasMany(e => e.SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE)
                .WithRequired(e => e.CONFERENCE_SESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SESSION>()
                .HasMany(e => e.SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP)
                .WithRequired(e => e.CONFERENCE_SESSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SESSION_CHAIR>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION_CHAIR>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION_CHAIR>()
                .HasMany(e => e.CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP)
                .WithRequired(e => e.CONFERENCE_SESSION_CHAIR)
                .HasForeignKey(e => new { e.PERSON_ID, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION_CHAIR_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT>()
                .Property(e => e.PAPER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT>()
                .Property(e => e.CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT>()
                .Property(e => e.MOVED_TO_CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION_TOPIC>()
                .Property(e => e.CONFERENCE_SESSION_TOPIC_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SESSION_TOPIC>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SUGGESTED_PAPER_ABSTRACT_AUTOMATIC_APPROVAL_PERCENTILE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SUGGESTED_PAPER_ABSTRACT_AUTOMATIC_REJECTION_PERCENTILE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SUGGESTED_PAPER_TEXT_AUTOMATIC_APPROVAL_PERCENTILE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SUGGESTED_PAPER_TEXT_AUTOMATIC_REJECTION_PERCENTILE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.TECHNICAL_CHAIR_RIGHT_PERSON_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.TECHNICAL_CHAIR_RIGHT_PERSON_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.TECHNICAL_CHAIR_RIGHT_PERSON_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.TECHNICAL_CHAIR_RIGHT_PERSON_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.TECHNICAL_CHAIR_RIGHT_PERSON_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SETTING_RIGHTS>()
                .Property(e => e.SETTING_FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_PERSON_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.SURVEY_FOR_CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_6)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_7)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_8)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_9)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_GROUP_ID_10)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_1)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_2)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_3)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_4)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_5)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_6)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_7)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_8)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_9)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_10)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_11)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_12)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_13)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_14)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_15)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_16)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_17)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_18)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_19)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CONFERENCE_SURVEY_UserName_20)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .Property(e => e.DELETED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .HasMany(e => e.ACCOUNT_DOING_CONFERENCE_SURVEY)
                .WithRequired(e => e.CONFERENCE_SURVEY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SURVEY>()
                .HasMany(e => e.CONFERENCE_SURVEY_QUESTION)
                .WithRequired(e => e.CONFERENCE_SURVEY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_POINT_A)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_POINT_B)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_POINT_C)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_POINT_D)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_POINT_E)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_POINT_F)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_POINT_G)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CONFERENCE_SURVEY_QUESTION_POINT_H)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.MINIMUM_RATING_SCALE_VALUE)
                .HasPrecision(6, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.MAXIMUM_RATING_SCALE_VALUE)
                .HasPrecision(6, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.RATING_SCALE_STEP_VALUE)
                .HasPrecision(6, 2);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.DELETED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<CONFERENCE_SURVEY_QUESTION>()
                .HasMany(e => e.ANSWER_TO_CONFERENCE_SURVEY_QUESTION)
                .WithRequired(e => e.CONFERENCE_SURVEY_QUESTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONFERENCE_TYPE>()
                .Property(e => e.CONFERENCE_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP>()
                .Property(e => e.TYPE_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FACILITY>()
                .Property(e => e.FACILITY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FACILITY>()
                .Property(e => e.ROOT_FACILITY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FIELD_OF_STUDY>()
                .Property(e => e.FIELD_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FIELD_OF_STUDY>()
                .Property(e => e.ROOT_FIELD_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FIELD_OF_STUDY>()
                .HasMany(e => e.CONFERENCE_FIELD_OF_STUDY_RELATIONSHIP)
                .WithRequired(e => e.FIELD_OF_STUDY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FIELD_OF_STUDY>()
                .HasMany(e => e.FIELD_OF_STUDY1)
                .WithOptional(e => e.FIELD_OF_STUDY2)
                .HasForeignKey(e => e.ROOT_FIELD_OF_STUDY_ID);

            modelBuilder.Entity<FOLLOWER_RELATIONSHIP>()
                .Property(e => e.FOLLOWED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<FOLLOWER_RELATIONSHIP>()
                .Property(e => e.FOLLOWING_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<FOLLOWER_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GENDER_TYPE>()
                .Property(e => e.GENDER_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GENDER_TYPE>()
                .HasMany(e => e.APPROVED_CONFERENCE_ATTENDEE_GENDER_TYPE)
                .WithRequired(e => e.GENDER_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LINE_OF_BUSINES_TYPE>()
                .Property(e => e.LINE_OF_BUSINESS_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LINE_OF_BUSINES_TYPE>()
                .HasMany(e => e.APPROVED_CONFERENCE_ATTENDEE_LINE_OF_BUSINESS)
                .WithRequired(e => e.LINE_OF_BUSINES_TYPE)
                .HasForeignKey(e => e.CONFERENCE_ATTENDEE_LINE_OF_BUSINESS_TYPE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>()
                .Property(e => e.CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>()
                .Property(e => e.FACILITY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>()
                .Property(e => e.OVERLAPPING_CONFERENCE_SESSION_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>()
                .Property(e => e.OVERLAPPING_CONFERENCE_SESSION_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>()
                .Property(e => e.OVERLAPPING_CONFERENCE_SESSION_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>()
                .Property(e => e.OVERLAPPING_CONFERENCE_SESSION_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MANDATORY_OR_REGISTED_CONFERENCE_SESSION>()
                .Property(e => e.OVERLAPPING_CONFERENCE_SESSION_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.MESSAGE_FEED_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.REPLYING_TO_MESSAGE_FEED_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_6)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_7)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_8)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_9)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_MESSAGING_GROUP_ID_10)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_1)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_2)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_3)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_4)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_5)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_6)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_7)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_8)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_9)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_10)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_11)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_12)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_13)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_14)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_15)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_16)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_17)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_18)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_19)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.RECIPIENT_UserName_20)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .Property(e => e.DELETED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE_FEED>()
                .HasMany(e => e.MESSAGE_FEED1)
                .WithOptional(e => e.MESSAGE_FEED2)
                .HasForeignKey(e => e.REPLYING_TO_MESSAGE_FEED_ID);

            modelBuilder.Entity<MESSAGE_FEED>()
                .HasMany(e => e.PERSON_LIKING_MESSAGE_FEED)
                .WithRequired(e => e.MESSAGE_FEED)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MESSAGING_GROUP>()
                .Property(e => e.MESSAGING_GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGING_GROUP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MESSAGING_GROUP>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGING_GROUP>()
                .Property(e => e.DELETED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGING_GROUP>()
                .HasMany(e => e.ACCOUNT_MESSAGING_GROUP_MEMBERSHIP)
                .WithRequired(e => e.MESSAGING_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOBILEFORM_FUNCTION>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_FUNCTION>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_FUNCTION>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_FUNCTION>()
                .HasMany(e => e.MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU)
                .WithRequired(e => e.MOBILEFORM_FUNCTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOBILEFORM_FUNCTION>()
                .HasMany(e => e.MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE)
                .WithRequired(e => e.MOBILEFORM_FUNCTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU>()
                .Property(e => e.MENU_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_GROUP>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP>()
                .Property(e => e.ROOT_GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP>()
                .Property(e => e.GROUP_ORDER_NUMBER)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_GROUP>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_GROUP>()
                .HasMany(e => e.MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE)
                .WithRequired(e => e.MOBILEFORM_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOBILEFORM_GROUP>()
                .HasMany(e => e.MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE)
                .WithRequired(e => e.MOBILEFORM_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_GROUP_ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.MENU_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_MENU>()
                .Property(e => e.MENU_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_MENU>()
                .Property(e => e.MENU_ID_ROOT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOBILEFORM_MENU>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_MENU>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MOBILEFORM_MENU>()
                .HasMany(e => e.MOBILEFORM_FUNCTION_FOR_MOBILEFORM_MENU)
                .WithRequired(e => e.MOBILEFORM_MENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOBILEFORM_MENU>()
                .HasMany(e => e.MOBILEFORM_GROUP_MENU_FOR_CONFERENCE)
                .WithRequired(e => e.MOBILEFORM_MENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORGANIZATION>()
                .Property(e => e.ORGANIZATION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ORGANIZATION>()
                .Property(e => e.ORGANIZATION_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORGANIZATION>()
                .Property(e => e.ESTABLISHMENT_DOCUMENT_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ORGANIZATION>()
                .Property(e => e.ROOT_ORGANIZATION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ORGANIZATION>()
                .Property(e => e.ORGANIZATION_ORDER_NUMBER)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.PAPER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_SESSION_TOPIC_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.TYPE_OF_STUDY_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_PRESENTATION_TYPE_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_SESSION_TOPIC_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.TYPE_OF_STUDY_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_PRESENTATION_TYPE_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_SESSION_TOPIC_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.TYPE_OF_STUDY_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_PRESENTATION_TYPE_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_SESSION_TOPIC_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.TYPE_OF_STUDY_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_PRESENTATION_TYPE_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_SESSION_TOPIC_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.TYPE_OF_STUDY_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.CONFERENCE_PRESENTATION_TYPE_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_ABSTRACT_REVIEWER_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .Property(e => e.ASSIGNED_CONFERENCE_SESSION_TOPIC_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .HasMany(e => e.AUTHOR_PAPER_ABSTRACT_RELATIONSHIP)
                .WithRequired(e => e.PAPER_ABSTRACT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .HasOptional(e => e.PAPER_TEXT)
                .WithRequired(e => e.PAPER_ABSTRACT);

            modelBuilder.Entity<PAPER_ABSTRACT>()
                .HasMany(e => e.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP)
                .WithRequired(e => e.PAPER_ABSTRACT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.CONFERENCE_BOARD_OF_REVIEW_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.PAPER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.FINAL_APPROVED_TYPE_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW>()
                .Property(e => e.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW>()
                .HasMany(e => e.REVIEWER_PAPER_TEXT_RELATIONSHIP)
                .WithRequired(e => e.PAPER_REVIEW_SUMUP_BY_CONFERENCE_BOARD_OF_REVIEW)
                .HasForeignKey(e => new { e.CONFERENCE_BOARD_OF_REVIEW_ID, e.CONFERENCE_ID, e.PAPER_ID, e.PAPER_TEXT_SUBMISSION_DEADLINE_ORDER_NUMBER })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAPER_TEXT>()
                .Property(e => e.PAPER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_TEXT>()
                .Property(e => e.FINAL_APPROVAL_OR_REJECTION_OF_PAPER_TEXT_REVIEWER_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_TEXT>()
                .Property(e => e.FINAL_ASSIGNED_CONFERENCE_SESSION_TOPIC_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_TEXT>()
                .Property(e => e.FINAL_APPROVED_TYPE_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_TEXT>()
                .Property(e => e.FINAL_APPROVED_CONFERENCE_PRESENTATION_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PAPER_TEXT>()
                .HasMany(e => e.AUTHOR_PAPER_TEXT_RELATIONSHIP)
                .WithRequired(e => e.PAPER_TEXT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAPER_TEXT>()
                .HasMany(e => e.CONFERENCE_SESSION_PAPER_PRESENTATION_SLOT)
                .WithRequired(e => e.PAPER_TEXT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAPER_TEXT>()
                .HasMany(e => e.PRESENTER_CONFERENCE_SESSION_RELATIONSHIP)
                .WithRequired(e => e.PAPER_TEXT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAPER_TEXT>()
                .HasMany(e => e.REVIEWER_PAPER_TEXT_RELATIONSHIP)
                .WithRequired(e => e.PAPER_TEXT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.INSTRUCTOR_ID_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.STUDENT_ID_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.TOTAL_YEARS_WORK_EXPERIENCE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.CURRENT_GENDER)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.AUTHORs)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.CONFERENCE_ATTENDEE)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.CONFERENCE_SESSION_CHAIR)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.MANDATORY_OR_REGISTED_CONFERENCE_SESSION)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.PRESENTERs)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.REVIEWERs)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.SUPPORT_STAFF)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON_LIKING_MESSAGE_FEED>()
                .Property(e => e.MESSAGE_FEED_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PERSON_LIKING_MESSAGE_FEED>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON_LIKING_MESSAGE_FEED>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRESENTER>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRESENTER>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRESENTER>()
                .HasMany(e => e.PRESENTER_CONFERENCE_SESSION_RELATIONSHIP)
                .WithRequired(e => e.PRESENTER)
                .HasForeignKey(e => new { e.PERSON_ID, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRESENTER_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRESENTER_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.PAPER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRESENTER_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRESENTER_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REGISTERED_CONFERENCE_SESSION_IN_CONFERENCE_REGISTRATION_PACKAGE>()
                .Property(e => e.CONFERENCE_REGISTRATION_PACKAGE_OFFERING_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER>()
                .Property(e => e.CONFERENCE_BOARD_OF_REVIEW_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER>()
                .Property(e => e.CONFERENCE_BOARD_OF_REVIEW_CHAIR_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER>()
                .Property(e => e.PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER>()
                .Property(e => e.PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER>()
                .Property(e => e.FINAL_PAPER_ABSTRACT_APPROVAL_OR_REJECTION_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER>()
                .Property(e => e.FINAL_PAPER_TEXT_APPROVAL_OR_REJECTION_RIGHT_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER>()
                .HasMany(e => e.REVIEWER_PAPER_ABSTRACT_RELATIONSHIP)
                .WithRequired(e => e.REVIEWER)
                .HasForeignKey(e => new { e.PERSON_ID, e.CONFERENCE_BOARD_OF_REVIEW_ID, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REVIEWER>()
                .HasMany(e => e.REVIEWER_PAPER_TEXT_RELATIONSHIP)
                .WithRequired(e => e.REVIEWER)
                .HasForeignKey(e => new { e.PERSON_ID, e.CONFERENCE_BOARD_OF_REVIEW_ID, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_BOARD_OF_REVIEW_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.PAPER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.PROPOSED_CONFERENCE_SESSION_TOPIC_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.PROPOSED_TYPE_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_ABSTRACT_RELATIONSHIP>()
                .Property(e => e.PAPER_ABSTRACT_REVIEW_RATING_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<REVIEWER_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_BOARD_OF_REVIEW_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.PAPER_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.PROPOSED_REVISED_CONFERENCE_SESSION_TOPIC_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.PROPOSED_TYPE_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.PROPOSED_CONFERENCE_PRESENTATION_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REVIEWER_PAPER_TEXT_RELATIONSHIP>()
                .Property(e => e.PAPER_TEXT_REVIEW_RATING_POINT)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.SAMPLE_CONFERENCE_SURVEY_QUESTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.SAMPLE_CONFERENCE_SURVEY_QUESTION_POINT_A)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.SAMPLE_CONFERENCE_SURVEY_QUESTION_POINT_B)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.SAMPLE_CONFERENCE_SURVEY_QUESTION_POINT_C)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.SAMPLE_CONFERENCE_SURVEY_QUESTION_POINT_D)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.SAMPLE_CONFERENCE_SURVEY_QUESTION_POINT_E)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.SAMPLE_CONFERENCE_SURVEY_QUESTION_POINT_F)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.SAMPLE_CONFERENCE_SURVEY_QUESTION_POINT_G)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.SAMPLE_CONFERENCE_SURVEY_QUESTION_POINT_H)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.MINIMUM_RATING_SCALE_VALUE)
                .HasPrecision(6, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.MAXIMUM_RATING_SCALE_VALUE)
                .HasPrecision(6, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.RATING_SCALE_STEP_VALUE)
                .HasPrecision(6, 2);

            modelBuilder.Entity<SAMPLE_CONFERENCE_SURVEY_QUESTION>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_3)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_4)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_5)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_6)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_6)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_7)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_7)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_8)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_8)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_9)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_9)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_10)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_10)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_11)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_11)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_12)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_12)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_13)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_13)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_14)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_14)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_15)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_15)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_16)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_16)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_17)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_17)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_18)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_18)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_19)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_19)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_20)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_20)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_21)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_21)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_22)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_22)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_23)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_23)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_24)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_24)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_25)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_25)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_26)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_26)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_27)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_27)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_28)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_28)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_29)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_29)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.CONFERENCE_SESSION_ID_30)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTED_CONFERENCE_SESSIONS_IN_ACCOUNT_AGENDA>()
                .Property(e => e.FACILITY_ID_30)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE>()
                .Property(e => e.CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SESSION_TOPIC_CONFERENCE_PRESENTATION_TYPE>()
                .Property(e => e.CONFERENCE_PRESENTATION_TYPE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPORT_STAFF>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPORT_STAFF>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPORT_STAFF>()
                .HasMany(e => e.SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP)
                .WithRequired(e => e.SUPPORT_STAFF)
                .HasForeignKey(e => new { e.PERSON_ID, e.CONFERENCE_ID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.CONFERENCE_SESSION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.MC_ROLE_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.TRANSLATOR_ROLE_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.FandB_SUPPORT_ROLE_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPORT_STAFF_CONFERENCE_SESSION_RELATIONSHIP>()
                .Property(e => e.TECHNICAL_SUPPORT_ROLE_SETTING_PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TYPE_OF_STUDY>()
                .Property(e => e.TYPE_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TYPE_OF_STUDY>()
                .Property(e => e.ROOT_TYPE_OF_STUDY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TYPE_OF_STUDY>()
                .HasMany(e => e.CONFERENCE_TYPE_OF_STUDY_RELATIONSHIP)
                .WithRequired(e => e.TYPE_OF_STUDY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TYPE_OF_STUDY>()
                .HasMany(e => e.TYPE_OF_STUDY1)
                .WithOptional(e => e.TYPE_OF_STUDY2)
                .HasForeignKey(e => e.ROOT_TYPE_OF_STUDY_ID);

            modelBuilder.Entity<WEBFORM_FUNCTION>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_FUNCTION>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_FUNCTION>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_FUNCTION>()
                .HasMany(e => e.WEBFORM_FUNCTION_FOR_WEBFORM_MENU)
                .WithRequired(e => e.WEBFORM_FUNCTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WEBFORM_FUNCTION>()
                .HasMany(e => e.WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE)
                .WithRequired(e => e.WEBFORM_FUNCTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WEBFORM_FUNCTION_FOR_WEBFORM_MENU>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_FUNCTION_FOR_WEBFORM_MENU>()
                .Property(e => e.MENU_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_FUNCTION_FOR_WEBFORM_MENU>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_FUNCTION_FOR_WEBFORM_MENU>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_GROUP>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP>()
                .Property(e => e.ROOT_GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP>()
                .Property(e => e.GROUP_ORDER_NUMBER)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_GROUP>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_GROUP>()
                .HasMany(e => e.WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE)
                .WithRequired(e => e.WEBFORM_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WEBFORM_GROUP>()
                .HasMany(e => e.WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE)
                .WithRequired(e => e.WEBFORM_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WEBFORM_GROUP>()
                .HasMany(e => e.WEBFORM_GROUP_MENU_FOR_CONFERENCE)
                .WithRequired(e => e.WEBFORM_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_GROUP_ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.MENU_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_MENU>()
                .Property(e => e.MENU_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_MENU>()
                .Property(e => e.MENU_ID_ROOT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WEBFORM_MENU>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_MENU>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WEBFORM_MENU>()
                .HasMany(e => e.WEBFORM_FUNCTION_FOR_WEBFORM_MENU)
                .WithRequired(e => e.WEBFORM_MENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WEBFORM_MENU>()
                .HasMany(e => e.WEBFORM_GROUP_MENU_FOR_CONFERENCE)
                .WithRequired(e => e.WEBFORM_MENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WINFORM_FUNCTION>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_FUNCTION>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_FUNCTION>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_FUNCTION>()
                .HasMany(e => e.WINFORM_FUNCTION_FOR_WINFORM_MENU)
                .WithRequired(e => e.WINFORM_FUNCTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WINFORM_FUNCTION>()
                .HasMany(e => e.WINFORM_GROUP_FUNCTION_FOR_CONFERENCE)
                .WithRequired(e => e.WINFORM_FUNCTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WINFORM_FUNCTION_FOR_WINFORM_MENU>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_FUNCTION_FOR_WINFORM_MENU>()
                .Property(e => e.MENU_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_FUNCTION_FOR_WINFORM_MENU>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_FUNCTION_FOR_WINFORM_MENU>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_GROUP>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP>()
                .Property(e => e.ROOT_GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP>()
                .Property(e => e.GROUP_ORDER_NUMBER)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_GROUP>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_GROUP>()
                .HasMany(e => e.WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE)
                .WithRequired(e => e.WINFORM_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WINFORM_GROUP>()
                .HasMany(e => e.WINFORM_GROUP_FUNCTION_FOR_CONFERENCE)
                .WithRequired(e => e.WINFORM_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WINFORM_GROUP>()
                .HasMany(e => e.WINFORM_GROUP_MENU_FOR_CONFERENCE)
                .WithRequired(e => e.WINFORM_GROUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_GROUP_ACCOUNT_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.FUNCTION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_GROUP_FUNCTION_FOR_CONFERENCE>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.MENU_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.GROUP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_GROUP_MENU_FOR_CONFERENCE>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_MENU>()
                .Property(e => e.MENU_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_MENU>()
                .Property(e => e.MENU_ID_ROOT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<WINFORM_MENU>()
                .Property(e => e.CREATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_MENU>()
                .Property(e => e.UPDATED_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<WINFORM_MENU>()
                .HasMany(e => e.WINFORM_FUNCTION_FOR_WINFORM_MENU)
                .WithRequired(e => e.WINFORM_MENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WINFORM_MENU>()
                .HasMany(e => e.WINFORM_GROUP_MENU_FOR_CONFERENCE)
                .WithRequired(e => e.WINFORM_MENU)
                .WillCascadeOnDelete(false);
        }
    }
}
