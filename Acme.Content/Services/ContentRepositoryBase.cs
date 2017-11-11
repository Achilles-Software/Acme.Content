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
using Achilles.Acme.Data.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Services
{
    public abstract class ContentRepositoryBase<TEntity> : RepositoryBase<TEntity>, IContentRepository<TEntity>
        where TEntity: ContentItem
    {
        #region Fields

        private DbContext _dbContext;

        #endregion

        #region Constructor(s)

        public ContentRepositoryBase( DbContext dbContext ) : base( dbContext )
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
            return _dbContext.Set<TEntity>().Where( m => m.Status == status ).OrderByDescending( m => m.DatePublished );
        }

        public virtual async Task<TEntity> GetAsync( int id, Status status = Status.Published )
        {
            return await _dbContext.Set<TEntity>().Where( m => m.Status == status ).FirstOrDefaultAsync( d => ( d.Id == id ) );
        }

        #endregion
    }
}
