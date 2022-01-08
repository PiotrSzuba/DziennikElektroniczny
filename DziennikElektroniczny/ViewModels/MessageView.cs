using DziennikElektroniczny.Models;
using System;

namespace DziennikElektroniczny.ViewModels
{
    public class MessageView
    {
        public int Id { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? SeenDate { get; set; }
        public int? MessageContentId { get; set; }
        public int? FromPersonId { get; set; }
        public int? ToPersonId { get; set; }

        public MessageView(Message message)
        {
            Id = message.MessageId;
            SendDate = message.SendDate;
            SeenDate = message.SeenDate;
            MessageContentId = message.MessageContentId;
            FromPersonId = message.FromPersonId;
            ToPersonId = message.ToPersonId;
        }
    }
}
