#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Achilles.Acme.Content.Data.Models
{
    [Table("cms_Posts")]
    public class Post
    {
        public Post() // string contentTypeUId )
        {
            //ContentTypeUId = contentTypeUId;

            // TODO: Make access easier...

            //Tags = new JoinCollectionFacade<Tag, ContentBaseTags>(
            //    ContentBaseTags, // The associative entity model
            //    m => m.Tag, // The selector function
            //    c => new ContentBaseTags() { ContentBase = this, Tag = c } ); // The creator function
        }

        [Key]
        public int PostId { get; set; }

        [Required]
        public string ContentTypeUId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        // Many-Many join entity
        public ICollection<PostTags> PostTags { get; } = new List<PostTags>();

        [NotMapped]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}