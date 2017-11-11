#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.EntityFrameworkCore;
using System.Linq;

#endregion

namespace Achilles.Acme.Content.Data
{
    public static class ModelBuilderExtensions
    {
        public static void IgnoreCoreContentEntityTypes( this ModelBuilder modelBuilder )
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

            foreach ( var entityType in entityTypes )
            {
                if ( entityType.ClrType.CustomAttributes.Any( n => n.AttributeType == typeof( ContentBaseEntity ) ) )
                {
                    modelBuilder.Ignore( entityType.ClrType );
                }
            }
        }
    }
}
