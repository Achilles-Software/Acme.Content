#region Namespaces

using Achilles.Acme.Content.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Achilles.Acme.Content
{
    public partial class ContentDbContext : DbContext
    {
        public ContentDbContext( DbContextOptions<ContentDbContext> options )
            : base( options )
        {
        }

        //public virtual DbSet<ContentBase> ContentBaseSet { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            //modelBuilder.Entity<Achilles.Acme.Content.Models.ContentBase>()
            //    .ToTable( "cms_ContentBase" );

            //modelBuilder.Entity<ContentBase>()
            //    .HasMany( e => e.Tags )
            //    .WithMany( e => e.ContentBaseSet )
            //    .Map( m => m.ToTable( "cms_ContentBaseTags" ).MapLeftKey( "ContentId" ).MapRightKey( "TagId" ) );
        }
    }
}
