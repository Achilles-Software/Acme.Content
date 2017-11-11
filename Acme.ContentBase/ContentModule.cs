#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Configuration;
using Achilles.Acme.Content.Data;
using Achilles.Acme.Data;
using Achilles.Acme.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private IServiceCollection _services;
        private IConfiguration _configuration;

        #endregion

        #region Module Registration / Initialization

        public override async void Configure( IHostingEnvironment env )
        {
            // Ensure that the CMS content entities are created and updated to the latest migration
            var serviceProvider = _services.BuildServiceProvider();
            var contentDbContext = serviceProvider.GetRequiredService<ContentDbContext>();

            await contentDbContext.MigrateDatabaseToLatestVersionAsync( serviceProvider );
        }

        public override void ConfigureServices( IServiceCollection services, IConfiguration configuration )
        {
            _services = services;
            _configuration = configuration;

            // Add module services..
            services.AddSingleton<ContentModule>( this );

            // Add embedded views...
            services.Configure<RazorViewEngineOptions>( options =>
            {
                options.FileProviders.Add( new EmbeddedFileProvider(
                    this.GetType().GetTypeInfo().Assembly,
                    baseNamespace: "Achilles.Acme.Content.EmbeddedViews" ) );
            } );

            // Add DbContext...
            string connectionString = ConfigurationHelper.GetConfiguration( services ).GetConnectionString( "DefaultConnection" );

            services.AddDbContext<ContentDbContext>( options =>
                     options.UseSqlServer( connectionString ) );
        }

        #endregion

        #region IPlugin Members

        public override Guid UId
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
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public override int Type
        {
            get { return (int)( PluginType.System | PluginType.Service ); }
        }

        #endregion
    }
}
