#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Models;
using Achilles.Acme.Data;
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
