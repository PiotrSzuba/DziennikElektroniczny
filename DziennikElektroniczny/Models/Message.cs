using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;

namespace DziennikElektroniczny.Models
{
    public class Message
    {
        [Key]
        [Range(1, 1000000000)]
        public int MessageId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SendDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? SeenDate { get; set; }

        public int? MessageContentId { get; set; }
        public MessageContent MessageContent { get; set; }

        [Range(1, 1000000000)]
        public int? FromPersonId { get; set; }

        [Range(1, 1000000000)]
        public int? ToPersonId { get; set; }

        public virtual Person FromPerson { get; set; }
        public virtual Person ToPerson { get; set; }
    }
}
