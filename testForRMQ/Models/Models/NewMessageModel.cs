using System;

namespace ItSymphony.Integration.DeltaM.Contracts.Models
{
    public class NewMessageModel
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public string Text { get; set; }
        public string ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string FileId { get; set; }
        public string FileUrl { get; set; }
        public LocationModel LocationModel { get; set; }
        public DateTime TimeSent { get; set; }
        public MessageType MessageType { get; set; }
    }

    public enum MessageType
    {
        ClientMessage = 2,
        SystemMessage = 3
    }
}
