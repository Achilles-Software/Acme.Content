#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System;

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

        public ContentServiceResult( ContentServiceError error, Exception e )
        {
            Succeeded = false;
            Error = error;
            Exception = e;
        }
        
        #endregion

        #region Properties

        public Exception Exception { get; private set; }

        public ContentServiceError Error { get; private set; }

        public bool Succeeded { get; private set; }

        public static ContentServiceResult Success
        {
            get
            {
                return _success;
            }
        }

        public static ContentServiceResult Failed( ContentServiceError error, Exception e = null )
        {
            return new ContentServiceResult( error, e );
        }

        #endregion
    }
}
