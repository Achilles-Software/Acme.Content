using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achilles.Acme.Content.Services
{
    /// <summary>
    /// Interface for Acme content repositories.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContentRepository<T>
    {
        #region Repository Query Methods

        Task<T> GetAsync( int id, bool isPublished = true );
        IQueryable<T> GetAll( bool isPublished = true );

        #endregion

        #region Repository CRUD Methods

        Task<int> CreateAsync( T item );
        Task<int> EditAsync( T item );
        Task<int> DeleteAsync( T item );

        #endregion
    }
}
