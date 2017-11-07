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

        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<Conference_Location> Conference_Location { get; set; }
        public virtual DbSet<Conference_Map> Conference_Map { get; set; }
        public virtual DbSet<Conversation_Reply> Conversation_Reply { get; set; }
        public virtual DbSet<Manage_Device> Manage_Device { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookmark>()
                .Property(e => e.BOOKMARK_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bookmark>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bookmark>()
                .Property(e => e.PERSON_ID_BOOKMARK)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Conference_Location>()
                .Property(e => e.CONFERENCE_LOCATION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Conference_Location>()
                .Property(e => e.CONFERENCE_MAP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Conference_Map>()
                .Property(e => e.CONFERENCE_MAP_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Conference_Map>()
                .Property(e => e.FACILITY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Conference_Map>()
                .Property(e => e.CONFERENCE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Conversation_Reply>()
                .Property(e => e.CONVERSATION_REPLY_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Conversation_Reply>()
                .Property(e => e.PERSON_ID_FROM)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Conversation_Reply>()
                .Property(e => e.PERSON_ID_TO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Conversation_Reply>()
                .Property(e => e.PERSON_ID_DELETE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Manage_Device>()
                .Property(e => e.MANAGE_DEVICE_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Manage_Device>()
                .Property(e => e.PERSON_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Notification>()
                .Property(e => e.NOTIFICATION_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Notification>()
                .Property(e => e.PERSON_ID_FROM)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Notification>()
                .Property(e => e.PERSON_ID_TO)
                .HasPrecision(18, 0);
        }
    }
}
