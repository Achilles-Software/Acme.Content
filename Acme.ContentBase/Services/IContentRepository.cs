#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Models;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Services
{
    /// <summary>
    /// Interface for Acme content repositories.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IContentRepository<TEntity>
        where TEntity : class
    {
        #region Repository Query Methods

        Task<TEntity> GetAsync( int id, Status status = Status.Published );

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetByStatus( Status status = Status.Published );

        #endregion

        #region Repository CRUD Methods

        Task<int> CreateAsync( TEntity item );
        Task<int> EditAsync( TEntity item );
        Task<int> DeleteAsync( TEntity item );

        #endregion
    }
}
