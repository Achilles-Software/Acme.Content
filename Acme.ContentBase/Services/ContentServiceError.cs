#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System.Collections.Generic;

#endregion

namespace Achilles.Acme.Content.Services
{
    public enum ContentServiceError : int
    {
        Unknown = 0x01,
        Validation = 0x02,

        SqlReferentialConstraint = 547,
    }

    public class DataServiceErrorString
    {
        public static readonly IDictionary<ContentServiceError, string> Names = new Dictionary<ContentServiceError, string>
        {
            { ContentServiceError.Unknown, "Unknown access failure" },
            { ContentServiceError.Validation, "Validation failure" },
            { ContentServiceError.SqlReferentialConstraint, "SQL Referential Constraint violation" },
        };
    }
}
