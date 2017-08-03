namespace CoMS.Entities_Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MYDB : DbContext
    {
        public MYDB()
            : base("name=MYDB")
        {
        }

        public virtual DbSet<BOOKMARK> BOOKMARKs { get; set; }
        public virtual DbSet<CONVERSATION> CONVERSATIONs { get; set; }
        public virtual DbSet<CONVERSATION_REPLY> CONVERSATION_REPLY { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BOOKMARK>()
                .Property(e => e.BOOKMARK_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BOOKMARK>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BOOKMARK>()
                .Property(e => e.PERSON_ID_BOOKMARK)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONVERSATION>()
                .Property(e => e.CONVERSATION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONVERSATION>()
                .Property(e => e.PERSON_ID_ONE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONVERSATION>()
                .Property(e => e.PERSON_ID_TWO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONVERSATION_REPLY>()
                .Property(e => e.CONVERSATION_REPLY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONVERSATION_REPLY>()
                .Property(e => e.PERSON_ID_FROM)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONVERSATION_REPLY>()
                .Property(e => e.PERSON_ID_TO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONVERSATION_REPLY>()
                .Property(e => e.PERSON_ID_DELETE)
                .HasPrecision(18, 0);
        }
    }
}
