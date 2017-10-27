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
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Services
{
    public abstract class ContentServiceBase<TEntity> : IContentService<TEntity>
        where TEntity : class
    {
        #region Fields

        protected IPlugin _plugin;
        private IContentRepository<TEntity> _repository;

        #endregion

        #region Constructor(s)

        public ContentServiceBase( IPlugin plugin, IContentRepository<TEntity> repository )
        {
            _plugin = plugin;
            _repository = repository;
        }

        #endregion

        #region Properties

        public IPlugin Plugin { get; }

        #endregion

        #region Validation

        public abstract ContentServiceResult Validate( TEntity model );

        #endregion

        #region Query Methods

        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IQueryable<TEntity> GetByStatus( Status status = Status.Published )
        {
            return _repository.GetByStatus( status );
        }

        public virtual async Task<TEntity> GetAsync( int id, Status status = Status.Published )
        {
            return await _repository.GetAsync( id, status );
        }

        #endregion

        #region CRUD Methods

        public virtual async Task<ContentServiceResult> CreateAsync( TEntity item )
        {
            var validationResult = Validate( item );

            if ( !validationResult.Succeeded )
            {
                return validationResult;
            }

            try
            {
                await _repository.CreateAsync( item );
            }
            catch ( DbUpdateException e )
            {
                return ContentServiceResult.Failed( ContentServiceErrorType.Unknown, e );
            }

            return ContentServiceResult.Success;
        }

        public virtual async Task<ContentServiceResult> DeleteAsync( TEntity item )
        {
            var validationResult = Validate( item );

            if ( !validationResult.Succeeded )
            {
                return validationResult;
            }

            try
            {
                await _repository.DeleteAsync( item );
            }
            catch ( DbUpdateException e )
            {
                return ContentServiceResult.Failed( ContentServiceErrorType.Unknown, new ContentServiceError( string.Empty, e ) );
            }

            return ContentServiceResult.Success;
        }

        public virtual async Task<ContentServiceResult> EditAsync( TEntity item )
        {
            try
            {
                await _repository.EditAsync( item );
            }
            catch ( Exception e )
            {
                return ContentServiceResult.Failed( ContentServiceErrorType.Unknown, e );
            }

            return ContentServiceResult.Success;
        }

        #endregion
    }
}
