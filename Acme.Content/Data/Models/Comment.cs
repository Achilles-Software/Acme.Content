#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Data;
using Achilles.Acme.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Achilles.Acme.Content.Data.Models
{
    [Table("cms_Comments")]
    [ContentBaseEntity]
    public class Comment : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public ICollection<Comment> Responses { get; set; } = new List<Comment>();
    }
}
