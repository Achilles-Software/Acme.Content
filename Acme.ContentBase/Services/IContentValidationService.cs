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

#endregion

namespace Achilles.Acme.Content.Services
{
    public interface IContentValidationService
    {
        void AddError( string key, string errorMessage );

        ContentServiceErrors GetErrors();

        bool IsValid { get; }
    }
}
