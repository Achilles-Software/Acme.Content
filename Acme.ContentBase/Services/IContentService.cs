#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

//using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Services
{
    /// <summary>
    /// Required Interface for ACME CMS content type services.
    /// </summary>
    /// <typeparam name="T">Content type model</typeparam>
    public interface IContentService<T>
    {
        #region ModelState

        // TODO: Resolve model state issues
        //ModelStateDictionary ModelState { get; set; }
        
        #endregion

        #region Query Methods

        Task<T> GetAsync( int id, bool isPublished = true );
        IQueryable<T> GetAll( bool isPublished = true );

        #endregion

        #region CRUD Methods

        Task<ContentServiceResult> CreateAsync( T item );
        Task<ContentServiceResult> EditAsync( T item );
        Task<ContentServiceResult> DeleteAsync( T item );

        #endregion
    }
}
