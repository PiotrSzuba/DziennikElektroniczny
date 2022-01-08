using DziennikElektroniczny.Models;
using System;

namespace DziennikElektroniczny.ViewModels
{
    public class MessageContentView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public MessageContentView(MessageContent messageContent)
        {
            Id = messageContent.MessageContentId;
            Title = messageContent.Title;
            Content = messageContent.Content;
        }
    }
}
