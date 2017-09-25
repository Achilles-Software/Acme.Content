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
