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
        public string Title { get; set; }
        public string Content { get; set; }
        public int? FromPersonId { get; set; }
        public string FromPersonName { get; set; }
        public int? ToPersonId { get; set; }
        public string ToPersonName { get; set; }


        public MessageView(Message message, MessageContent messageContent,PersonalInfo fromPersonInfo,PersonalInfo toPersonInfo)
        {
            Id = message.MessageId;
            SendDate = message.SendDate;
            SeenDate = message.SeenDate;
            MessageContentId = message.MessageContentId;
            Title = messageContent.Title;
            Content = messageContent.Content;
            FromPersonId = message.FromPersonId;
            FromPersonName = fromPersonInfo.Name + " " + fromPersonInfo.Surname;
            ToPersonId = message.ToPersonId;
            ToPersonName = toPersonInfo.Name +  " " + toPersonInfo.Surname;
        }
    }
}
