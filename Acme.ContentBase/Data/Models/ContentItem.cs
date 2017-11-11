#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Achilles.Acme.Content.Data.Models
{
    /// <summary>
    /// The base class implentation for a derived CMS content type item.
    /// </summary>
    public abstract class ContentItem : IContentEntity
    {
        public ContentItem()
        {
            Post = new Post();
        }

        [Key]
        public int Id { get; set; }

        public string TenantId { get; set; }

        public bool? IsDeleted { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public string ModifiedByUserId { get; set; }

        [Required]
        public DateTime DateModified { get; set; } = DateTime.Now;

        [Required]
        public DateTime DatePublished { get; set; } = DateTime.Now;

        [Required]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public Status Status { get; set; } = Status.Draft;

        [Required]
        [StringLength( 128 )]
        public string Title { get; set; }

        [StringLength(128)]
        public string SeoFriendlyTitle { get; set; }

        [StringLength( 256 )]
        public string SeoDescription { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
