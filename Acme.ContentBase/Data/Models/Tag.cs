#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Achilles.Acme.Content.Data.Models
{
    [Table( "cms_Tags" )]
    [ContentBaseEntity]
    public partial class Tag
    {
        public Tag()
        {
            // TODO: Simplify access to Posts navigation...

            //Posts = new JoinCollectionFacade<Post, PostTags>(
            //    PostTags, // The associative entity model
            //    m => m.Post, // The selector function
            //    c => new PostTags() { Post = this, Tag = c } ); // The creator function
        }

        [Key]
        public int TagId { get; set; }

        public int? ParentTagId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Many-Many join entity
        public ICollection<PostTags> PostTags { get; } = new List<PostTags>();

        [NotMapped]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
