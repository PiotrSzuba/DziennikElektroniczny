using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public class MessageContent
    {
        [Key]
        [Range(1, 1000000000)]
        public int MessageContentId { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Content { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
