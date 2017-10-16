using Achilles.Acme.Content.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Achilles.Acme.Content.Models
{
    [Table("cms_Comments")]
    [CoreContentEntity]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public ICollection<Comment> Responses { get; set; } = new List<Comment>();
    }
}
