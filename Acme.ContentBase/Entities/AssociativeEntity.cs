using Achilles.Acme.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Achilles.Acme.Content.Entities
{
    public interface IAssociativeEntity<TLeftEntity, TRightEntity> where TLeftEntity: IEntity where TRightEntity: IEntity
    {
        TLeftEntity LeftNavigation { get; set; }
        TRightEntity RightNavigation { get; set; }
    }
}
