using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;

namespace DziennikElektroniczny.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SendDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? SeenDate { get; set; }

        public int? MessageContentId { get; set; }
        public MessageContent MessageContent { get; set; }

        public int? FromPersonId { get; set; }

        public int? ToPersonId { get; set; }

        public virtual Person FromPerson { get; set; }
        public virtual Person ToPerson { get; set; }
    }
}
