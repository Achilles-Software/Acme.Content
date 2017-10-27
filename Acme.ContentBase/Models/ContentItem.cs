#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Entities;
using Achilles.Acme.Content.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Achilles.Acme.Content.Models
{
    /// <summary>
    /// The base class implentation for a derived CMS content type item.
    /// </summary>
    public abstract class ContentItem : IContentEntity, ITenantEntity
    {
        public ContentItem()// string pluginId, string userId, string title )
        {
            //Title = title;
            //SeoFriendlyTitle = SeoHelpers.SeoFriendlyTitle( Title );
            //CreatedByUserId = userId;

            Post = new Post();// pluginId );
        }

        [Key]
        public int Id { get; set; }

        public string TenantId { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public DateTime DateModified { get; set; } = DateTime.Now;

        [Required]
        public DateTime DatePublished { get; set; } = DateTime.Now;

        [Required]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        // Deprecated - Use Status
        public bool IsPublished { get; set; } = false;

        [Required]
        public int Status { get; set; } = (int) Achilles.Acme.Content.Models.Status.Draft;

        [Required]
        public bool IsSticky { get; set; } = false;

        [Required]
        [StringLength( 128 )]
        public string Title { get; set; }

        [StringLength(128)]
        public string SeoFriendlyTitle { get; set; }

        [StringLength( 256 )]
        public string SeoDescription { get; set; }

        [ForeignKey( "Post" )]
        public int PostIdReference { get; set; }

        public Post Post { get; set; }
    }
}
