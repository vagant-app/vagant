using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Vagant.Domain.Entities;

namespace Vagant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        { }

        public DbSet<FileData> Files { get; set; }

        public DbSet<UserContactInfo> UserContactInfos { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventComment> EventComments { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<EventInstrument> EventInstruments { get; set; }

        public DbSet<EventRating> EventRatings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
