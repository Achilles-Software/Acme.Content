#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Models;
using Achilles.Acme.Plugins;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Services
{
    /// <summary>
    /// Interface for Acme CMS content type services.
    /// </summary>
    /// <typeparam name="TEntity">Content type entity</typeparam>
    public interface IContentService<TEntity>
    {
        #region Identification

        IPlugin Plugin { get; }

        #endregion

        #region Validation

        ContentServiceResult Validate( TEntity model );
        
        #endregion

        #region

        Task<TEntity> GetAsync( int id, Status status = Status.Published );

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetByStatus( Status status = Status.Published );

        #endregion

        #region CRUD Methods

        Task<ContentServiceResult> CreateAsync( TEntity item );
        Task<ContentServiceResult> EditAsync( TEntity item );
        Task<ContentServiceResult> DeleteAsync( TEntity item );

        #endregion
    }
}
