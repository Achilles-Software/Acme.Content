#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Models;
using Achilles.Acme.Content.Services;
using Achilles.Acme.Extensions;
using Achilles.Acme.UI.Paging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Mvc
{
    public abstract class AdminControllerBase<TEntity> : Controller
            where TEntity : class
    {
        #region Fields

        private IContentService<TEntity> _service;

        // FIXME: page size comes from configuration
        private const int _PageSize = 15;

        #endregion

        #region Constructor(s)

        public AdminControllerBase( IContentService<TEntity> service )
        {
            _service = service;
        }

        #endregion

        #region Actions

        #endregion

        #region Query Methods

        [Route( "[action]" )]
        public async Task<JsonResult> GetList( int? page )
        {
            PagedListViewModel model = new PagedListViewModel();

            if ( !page.HasValue )
                page = 1;

            model.List = new PaginatedList<TEntity>( _service.GetAll(), page.Value, _PageSize );

            return Json( new { Content = await this.RenderViewToStringAsync( "_List", model, isMainPage: false ), Pager = model.List.Pager } );
        }

        [Route( "[action]" )]
        public IActionResult List( int? page )
        {
            PagedListViewModel model = new PagedListViewModel();
            model.GetListUrl = Url.Content( "~/articles/admin/getlist" );
            model.PartialView = "_List";

            if ( !page.HasValue )
                page = 1;

            model.List = new PaginatedList<TEntity>( _service.GetAll(), page.Value, _PageSize );
            model.List.Pager.Action = Url.Content( "~/articles/admin/list" );

            return View( model );
        }

        #endregion

        #region CRUD

        [HttpPost]
        public async Task<IActionResult> Create( TEntity entity )
        {
            if ( !ModelState.IsValid )
            {
                return View( entity );
            }

            var result = await _service.CreateAsync( entity );

            if ( result.Succeeded )
            {
                RedirectToAction( "List" );
            }
            else
            {
                if ( result.ErrorType == ContentServiceErrorType.Validation )
                {
                    foreach ( var validationError in result.Errors )
                    {
                        ModelState.AddModelError( validationError.Key, validationError.ErrorMessage );
                    }

                    return View( entity );
                }
            }

            return View( "Error" );
        }

        [Route( "[action]" )]
        public async Task<IActionResult> Edit( int id )
        {
            TEntity entity = await _service.GetAsync( id );

            if ( entity == null )
            {
                return NotFound();
            }

            return View( entity );
        }

        [HttpPost, ActionName( "Edit" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost( int id )
        {
            TEntity entityToUpdate = await _service.GetAsync( id );

            if ( entityToUpdate == null )
            {
                return NotFound();
            }

            var isModelUpdated = await TryUpdateModelAsync<TEntity>( entityToUpdate, "Article" );

            if ( !isModelUpdated )
            {
                return View( entityToUpdate );
            }

            var result = await _service.EditAsync( entityToUpdate  );

            if ( !result.Succeeded )
            {
                return View( entityToUpdate );
            }

            return RedirectToAction( "List" );
        }

        [Route( "[action]" )]
        public virtual async Task<IActionResult> Delete( int? id )
        {
            if ( id == null )
            {
                return NotFound();
            }

            var entity = await _service.GetAsync( id.Value );

            if ( entity == null )
            {
                return NotFound();
            }

            return View( entity );
        }


        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed( int id )
        {
            var entity = await _service.GetAsync( id );

            if ( entity == null )
            {
                return NotFound();
            }

            var result = await _service.DeleteAsync( entity );

            if ( !result.Succeeded )
            {
                ModelState.AddModelError( "", "Delete Failed. Try again." );

                return View( entity );
            }

            return RedirectToAction( "List" );
        }
       
        #endregion
    }
}