#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Plugins;

using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

using System;
using System.Reflection;

#endregion

namespace Achilles.Acme.Content
{
    public class ContentModule : PluginBase
    {
        #region Fields

        private static Guid _id = new Guid( "9BD93A15-7693-4A0E-B58E-95F5B8C05113" );

        #endregion

        #region Module Registration / Initialization

        public override void Initialize( IServiceCollection services )
        {
            base.Initialize( services );
        }

        protected override void RegisterSettings( IServiceCollection services )
        {
        }

        protected override void RegisterViews( IServiceCollection services )
        {
            services.Configure<RazorViewEngineOptions>( options =>
            {
                options.FileProviders.Add( new EmbeddedFileProvider(
                    this.GetType().GetTypeInfo().Assembly,
                    baseNamespace: "Acme.Content.EmbeddedViews" ) );
            } );
        }

        protected override void RegisterRoutes( RouteCollection routes )
        {
        }

        protected override void RegisterServices( IServiceCollection serviceCollection )
        {
            // Add module services..
            serviceCollection.AddSingleton<ContentModule>( this );
        }

        #endregion

        #region IPlugin Members

        public override Guid Id
        {
            get { return _id; }
        }

        public override string Description
        {
            get { return "Achilles Acme CMS Content Module."; }
        }

        public override string Name
        {
            get { return "Content"; }
        }

        public override string Version
        {
            get { return "0.1.0-alpha"; }
        }

        public override int Type
        {
            get { return (int)( PluginType.System | PluginType.Service ); }
        }

        #endregion
    }
}
