#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Data
{
    public class ContentDbContextInitializer : IDatabaseInitializer<ContentDbContext>
    {
        public Task SeedAsync( ContentDbContext context, IServiceProvider serviceProvider, IEnumerable<String> newlyAppliedMigrations )
        {
            // Seed data in development environment
            IHostingEnvironment hostingEnvironment = serviceProvider.GetRequiredService<IHostingEnvironment>();

            if ( hostingEnvironment.IsDevelopment() )
            {
                // TODO: Seed here...
            }

            return Task.CompletedTask;
        }
    }
}
