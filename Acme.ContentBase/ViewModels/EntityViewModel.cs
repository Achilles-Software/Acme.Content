using Achilles.Acme.Content.Data.Models;
using Achilles.Acme.Content.Models;
using Achilles.Acme.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achilles.Acme.Content.ViewModels
{
    public abstract class EntityViewModel<TEntity> : IEntityViewModel<TEntity>
        where TEntity : IEntity
    {
        public abstract TEntity MapToEntity();

        public abstract void MapFromEntity( TEntity entity );
    }
}
