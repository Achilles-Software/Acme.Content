#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System;
using System.Collections.Generic;

#endregion

namespace Achilles.Acme.Content.Services
{
    public class ContentServiceError
    {
        #region Constructor(s)

        public ContentServiceError( string key, Exception exception )
            : this( key, exception, errorMessage: null )
        {
            if ( key == null )
            {
                throw new ArgumentNullException( nameof( key ) );
            }

            if ( exception == null )
            {
                throw new ArgumentNullException( nameof( exception ) );
            }
        }

        public ContentServiceError( string key, Exception exception, string errorMessage )
            : this( key, errorMessage )
        {
            Exception = exception ?? throw new ArgumentNullException( nameof( exception ) );
        }

        public ContentServiceError( string key, string errorMessage )
        {
            Key = key ?? throw new ArgumentNullException( nameof( key ) );

            ErrorMessage = errorMessage ?? string.Empty;
        }

        #endregion

        #region Properties

        public string Key { get; }

        public Exception Exception { get; }

        public string ErrorMessage { get; }

        #endregion
    }
}
