using System;
using System.Collections.Generic;
using System.Text;

namespace Achilles.Acme.Content.Entities
{
    public interface ISoftDeleteEntity
    {
        bool? IsDeleted { get; set; }
    }
}
