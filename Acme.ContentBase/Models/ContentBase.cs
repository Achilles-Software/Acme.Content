#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Achilles.Acme.Content.Models
{
    public abstract partial class ContentBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContentBase()
        {
            Tags = new HashSet<Tag>();
        }

        [Key]
        public int ContentId { get; set; }

        public Guid ContentTypeId { get; set; }

        public Guid CreatedByUserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DatePublished { get; set; }

        // Deprecated - Use Status
        public bool IsPublished { get; set; }

        public int Status { get; set; }

        public bool IsSticky { get; set; }

        [Required]
        [StringLength( 128 )]
        public string Title { get; set; }

        [StringLength(128)]
        public string SeoFriendlyTitle { get; set; }

        [StringLength( 256 )]
        public string SeoDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
