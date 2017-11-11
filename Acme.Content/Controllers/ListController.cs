#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Data.Models;
using Achilles.Acme.Data.Services;
using Achilles.Acme.Extensions;
using Achilles.Acme.Plugins;
using Achilles.Acme.Security.Data.Models;
using Achilles.Acme.UI.Paging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Controllers
{
    public abstract class ListController<TEntity> : Controller
        where TEntity : class, IEntity
    {
        #region Fields

        private IService<TEntity> _service;

        // FIXME: page size comes from configuration
        private const int _PageSize = 15;

        #endregion

        #region Constructor(s)

        public ListController(
            IService<TEntity> service )
        {
            _service = service;
        }

        #endregion

        #region List Methods

        [HttpGet]
        [Route( "[action]/{page:int?}" )]
        public async Task<JsonResult> GetList( int page = 1 )
        {
            PagedListViewModel model = new PagedListViewModel
            {
                List = new PaginatedList<TEntity>( _service.GetAll(), page, _PageSize )
            };

            return Json( new { Content = await this.RenderViewToStringAsync( "_List", model, isMainPage: false ), Pager = model.List.Pager } );
        }

        [Route( "[action]/{page:int?}" )]
        public IActionResult List( int page = 1 )
        {
            PagedListViewModel model = new PagedListViewModel
            {
                List = new PaginatedList<TEntity>( _service.GetAll(), page, _PageSize )
            };

            return View( model );
        }

        // TJT: Feature WIP...

        //[HttpGet]
        //[Route( "[action]/{page:int}" )]
        //public ActionResult More( int? page )
        //{
        //    PagedListViewModel model = new PagedListViewModel();
        //    model.GetListUrl = Url.Content( "~/articles/home/morelist" );

        //    if ( !page.HasValue )
        //        page = 1;

        //    model.List = new PaginatedList<TEntity>( _service.GetAll(), page.Value, _PageSize );

        //    return PartialView( "_List", model );
        //}

        #endregion
    }
}