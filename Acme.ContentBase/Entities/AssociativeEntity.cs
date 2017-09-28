using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Achilles.Acme.Content.Entities
{
    public interface IAssociativeEntity<TLeftEntity, TRightEntity> where TLeftEntity: IContentEntity where TRightEntity: IContentEntity
    {
        TLeftEntity LeftNavigation { get; set; }
        TRightEntity RightNavigation { get; set; }
    }
}
