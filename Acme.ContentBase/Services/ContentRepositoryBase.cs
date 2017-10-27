#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Services
{
    public abstract class ContentRepositoryBase<TEntity> : IContentRepository<TEntity>
        where TEntity: ContentItem
    {
        #region Fields

        private DbContext _dbContext;

        #endregion

        #region Constructor(s)

        public ContentRepositoryBase( DbContext dbContext )
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Query Methods

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().OrderByDescending( m => m.DatePublished );
        }

        public IQueryable<TEntity> GetByStatus( Status status = Status.Published )
        {
            return _dbContext.Set<TEntity>().Where( m => m.Status == (int)status ).OrderByDescending( m => m.DatePublished );
        }

        public virtual async Task<TEntity> GetAsync( int id, Status status = Status.Published )
        {
            return await _dbContext.Set<TEntity>().Where( m => m.Status == (int)status).FirstOrDefaultAsync( d => ( d.Id == id ) );
        }

        #endregion

        #region CRUD Methods

        public virtual async Task<int> CreateAsync( TEntity item )
        {
            _dbContext.Set<TEntity>().Add( item );

            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync( TEntity entity )
        {
            _dbContext.Set<TEntity>().Remove( entity );

            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> EditAsync( TEntity entity )
        {
            _dbContext.Update( entity );

            return await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
