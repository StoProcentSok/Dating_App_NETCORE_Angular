using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserLike> Likes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEventParticipation> EventsParticipations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //forming primary key for table
            builder.Entity<UserLike>()
                .HasKey(k => new { k.SourceUserId, k.LikedUserId });

            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade); //DeleteBehaviour.NoAction when on sql server!

            builder.Entity<UserLike>()
                .HasOne(s => s.LikedUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.LikedUserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<UserEventParticipation>()
                .HasKey(k => new { k.SourceUserId, k.EventToParticipateIniId });

            builder.Entity<UserEventParticipation>()
                .HasOne(s => s.SourceUser)
                .WithMany(e => e.UserEvents)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserEventParticipation>()
                .HasOne(s => s.EventToParticipateIn)
                .WithMany(l => l.ParticipatingUsers)
                .HasForeignKey(s => s.EventToParticipateIniId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}