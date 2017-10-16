#region Namespaces

using Achilles.Acme.Content.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Achilles.Acme.Content.Data
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext( DbContextOptions options )
            : base( options )
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostTags> PostTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            // Build the Many-Many entity relationship for PostTags
            modelBuilder.Entity<PostTags>()
                .ToTable( "cms_PostTags" );

            modelBuilder.Entity<PostTags>()
                .HasKey( t => new { t.PostId, t.TagId } );
        }
    }
}
