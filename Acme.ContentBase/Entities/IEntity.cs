using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Achilles.Acme.Content.Entities
{
    public interface IContentEntity
    {
        int Id { get; set; }
    }
}
