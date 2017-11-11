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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Models
{
    /// <summary>
    /// The published status of ACME CMS content items.
    /// </summary>
    public enum Status : int
    {
        Published = 0,

        Draft = 1,
        Inactive = 2,

        Unpublished = Draft, 
    }
}
