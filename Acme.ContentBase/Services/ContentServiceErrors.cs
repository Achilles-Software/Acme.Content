#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

#endregion

namespace Achilles.Acme.Content.Services
{
    public class ContentServiceErrors : IEnumerable<ContentServiceError>
    {
        List<ContentServiceError> _errors = new List<ContentServiceError>();

        public IReadOnlyCollection<ContentServiceError> Errors => new ReadOnlyCollection<ContentServiceError>( _errors );

        public void AddError( ContentServiceError error )
        {
            _errors.Add( error );
        }

        public void AddError( string key, Exception exception )
        {
            if ( key == null )
            {
                throw new ArgumentNullException( nameof( key ) );
            }

            if ( exception == null )
            {
                throw new ArgumentNullException( nameof( exception ) );
            }

            _errors.Add( new ContentServiceError( key, exception ) );
        }

        public void AddError( string key, Exception exception, string errorMessage )
        {
            if ( key == null )
            {
                throw new ArgumentNullException( nameof( key ) );
            }

            if ( exception == null )
            {
                throw new ArgumentNullException( nameof( exception ) );
            }

            if ( errorMessage == null )
            {
                throw new ArgumentNullException( nameof( errorMessage ) );
            }

            _errors.Add( new ContentServiceError( key, exception ) );
        }

        public void AddError( string key, string errorMessage )
        {
            if ( key == null )
            {
                throw new ArgumentNullException( nameof( key ) );
            }

            if ( errorMessage == null )
            {
                throw new ArgumentNullException( nameof( errorMessage ) );
            }

            _errors.Add( new ContentServiceError( key, errorMessage ) );
        }

        public IEnumerator<ContentServiceError> GetEnumerator()
        {
            return Errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Errors.GetEnumerator();
        }
    }
}
