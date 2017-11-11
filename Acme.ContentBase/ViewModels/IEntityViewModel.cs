using Achilles.Acme.Content.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achilles.Acme.Content.ViewModels
{
    public interface IEntityViewModel<TEntity>
    {
        TEntity MapToEntity();

        void MapFromEntity( TEntity entity );
    }
}
