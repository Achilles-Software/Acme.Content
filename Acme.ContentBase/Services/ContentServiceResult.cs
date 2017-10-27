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
using System.Collections.ObjectModel;

#endregion

namespace Achilles.Acme.Content.Services
{
    public class ContentServiceResult
    {
        #region Fields

        private static readonly ContentServiceResult _success = new ContentServiceResult( true );

        #endregion

        #region Constructors

        private ContentServiceResult( bool success )
        {
            Succeeded = success;
        }

        public ContentServiceResult( ContentServiceErrorType errorType, ContentServiceError error )
        {
            Succeeded = false;
            ErrorType = errorType;
            Errors = new ContentServiceErrors();

            Errors.AddError( error );
        }

        public ContentServiceResult( ContentServiceErrorType errorType, ContentServiceErrors errors )
        {
            Succeeded = false;
            ErrorType = errorType;
            Errors = errors;
        }

        #endregion

        #region Properties

        public ContentServiceErrors Errors { get; private set; }

        public ContentServiceErrorType ErrorType { get; private set; }

        public bool Succeeded { get; private set; }

        public static ContentServiceResult Success
        {
            get
            {
                return _success;
            }
        }

        public static ContentServiceResult Failed( ContentServiceErrorType errorType, Exception e = null )
        {
            return new ContentServiceResult( errorType, new ContentServiceError( string.Empty, e ) );
        }

        public static ContentServiceResult Failed( ContentServiceErrorType errorType, ContentServiceError error = null )
        {
            return new ContentServiceResult( errorType, error );
        }

        public static ContentServiceResult Failed( ContentServiceErrorType errorType, ContentServiceErrors errors = null )
        {
            return new ContentServiceResult( errorType, errors );
        }

        #endregion
    }
}
