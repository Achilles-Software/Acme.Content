#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Models;
using Achilles.Acme.Data.Models;
using System;

#endregion

namespace Achilles.Acme.Content.Data.Models
{
    public interface IContentEntity : IEntity, IAuditEntity, ITenantEntity, ISoftDeleteEntity
    {
        string Title { get; set; }

        Status Status { get; set; }

        DateTime DatePublished { get; set; }

        string SeoFriendlyTitle { get; set; }

        string SeoDescription { get; set; }

        Post Post { get; set; }
    }
}
