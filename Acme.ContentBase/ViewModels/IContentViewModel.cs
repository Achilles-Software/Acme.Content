using Achilles.Acme.Content.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achilles.Acme.Content.ViewModels
{
    public interface IContentViewModel
    {
        Status Status { get; set; }
    }
}
