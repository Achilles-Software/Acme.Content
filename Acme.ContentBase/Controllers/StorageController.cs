#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Content.Data.Models;
using Achilles.Acme.Content.Helpers;
using Achilles.Acme.Content.ViewModels;
using Achilles.Acme.Data.Models;
using Achilles.Acme.Data.Services;
using Achilles.Acme.Plugins;
using Achilles.Acme.Security.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Controllers
{
    public abstract class StorageController<TEntity, TEntityVM> : ListController<TEntity> 
        where TEntity : class, IEntity
        where TEntityVM : IEntityViewModel<TEntity>, new()
    {
        #region Fields

        private IPlugin _plugin;
        private IService<TEntity> _service;
        private UserManager<SecurityUser> _userManager;

        // FIXME: page size comes from configuration
        private const int _PageSize = 15;

        #endregion

        #region Constructor(s)

        public StorageController(
            IPlugin plugin,
            IService<TEntity> service,
            UserManager<SecurityUser> userManager ) : base( service ) 
        {
            _plugin = plugin;
            _service = service;
            _userManager = userManager;
        }

        #endregion

        #region CRUD Methods

        [HttpGet]
        [Route( "[action]/id" )]
        public async Task<IActionResult> Details( int id )
        {
            var entity = await _service.GetAsync( id );

            if ( entity == null )
            {
                return NotFound();
            }

            return View( entity );
        }

        [HttpGet]
        [Route( "[action]" )]
        public IActionResult Create()
        {
            var entityVM = new TEntityVM();

            return View( entityVM );
        }

        [HttpPost, ActionName( "Create" )]
        [ValidateAntiForgeryToken]
        [Route( "[action]" )]
        public async Task<IActionResult> CreatePost( TEntityVM entityViewModel )
        {
            if ( !ModelState.IsValid )
            {
                return View( entityViewModel );
            }

            var entityVM = entityViewModel as IEntityViewModel<TEntity>;
            var entity = entityVM.MapToEntity();

            if ( entity is IContentEntity contentEntity )
            {
                contentEntity.SeoFriendlyTitle = SeoHelpers.SeoFriendlyTitle( contentEntity.Title );
                contentEntity.Post.ContentTypeUId = _plugin.UId.ToString();
            }

            if ( entity is IAuditEntity auditableEntity )
            {
                var userId = _userManager.GetUserId( User );

                auditableEntity.CreatedByUserId = userId;
                auditableEntity.ModifiedByUserId = userId;
            }

            var result = await _service.CreateAsync( entity );

            if ( result.Succeeded )
            {
                return RedirectToAction( "List" );
            }
            if ( result.ErrorType == ServiceErrorType.Validation )
            {
                foreach ( var validationError in result.Errors )
                {
                    ModelState.AddModelError( validationError.Key, validationError.ErrorMessage );
                }
            }
            else
            {
                foreach ( var error in result.Errors )
                {
                    ModelState.AddModelError( "", error.ErrorMessage );
                }
            }

            return View( entityVM );
        }

        [HttpGet]
        [Route( "[action]/{id:int}" )]
        public async Task<IActionResult> Edit( int id )
        {
            TEntity entity = await _service.GetAsync( id );

            if ( entity == null )
            {
                return NotFound();
            }

            var entityVM = new TEntityVM();

            entityVM.MapFromEntity( entity );

            return View( entityVM );
        }

        [HttpPost, ActionName( "Edit" )]
        [ValidateAntiForgeryToken]
        [Route( "[action]/{id:int}")]
        public async Task<IActionResult> EditPost( int id )
        {
            TEntity entityToUpdate = await _service.GetAsync( id );

            if ( entityToUpdate == null )
            {
                return NotFound();
            }

            if ( entityToUpdate is IContentEntity contentEntity )
            {
                contentEntity.SeoFriendlyTitle = SeoHelpers.SeoFriendlyTitle( contentEntity.Title );

                // FIXME: The ContentTypeUId is not populated by the service layer. The line below should not be required.
                contentEntity.Post.ContentTypeUId = _plugin.UId.ToString();
            }

            if ( entityToUpdate is IAuditEntity auditableEntity )
            {
                var userId = _userManager.GetUserId( User );

                auditableEntity.ModifiedByUserId = userId;
            }

            var isModelUpdated = await TryUpdateModelAsync( entityToUpdate );

            if ( !isModelUpdated )
            {
                var entityVM = new TEntityVM();

                entityVM.MapFromEntity( entityToUpdate );

                return View( entityVM );
            }

            var result = await _service.EditAsync( entityToUpdate  );

            if ( !result.Succeeded )
            {
                // TODO: Error indication here...

                var entityVM = new TEntityVM();

                entityVM.MapFromEntity( entityToUpdate );

                return View( entityVM );
            }

            return RedirectToAction( "List" );
        }

        [HttpGet]
        [Route( "[action]/{id:int}" )]
        public virtual async Task<IActionResult> Delete( int id )
        {
            var entity = await _service.GetAsync( id );

            if ( entity == null )
            {
                return NotFound();
            }

            return View( entity );
        }

        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        [Route( "[action]/{id:int}" )]
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