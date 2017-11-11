#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Data.Models;
using Achilles.Acme.Content.Models;

#endregion

namespace Achilles.Acme.Content.ViewModels
{
    public abstract class ContentViewModel<TEntity> : IEntityViewModel<TEntity>, IContentViewModel
            where TEntity : IContentEntity, new()
    {
        public Status Status { get; set; }

        public ContentViewModel()
        {
            var entity = new TEntity();

            Status = entity.Status;
        }

        public abstract TEntity MapToEntity();

        public virtual void MapFromEntity( TEntity entity )
        {
            Status = entity.Status;
        }
    }
}
