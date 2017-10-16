using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Achilles.Acme.Content.Data
{
    public static class ModelBuilderExtensions
    {
        public static void IgnoreCoreContentEntityTypes( this ModelBuilder modelBuilder )
        {
            foreach ( var entityType in modelBuilder.Model.GetEntityTypes() )
            {
                if ( entityType.ClrType.CustomAttributes.Any( n => n.AttributeType == typeof( CoreContentEntity ) ) )
                {
                    modelBuilder.Ignore( entityType.ClrType );
                }
            }
        }
    }
}
