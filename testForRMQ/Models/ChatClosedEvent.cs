using ItSymphony.Integration.DeltaM.Contracts.Models;

namespace ItSymphony.Integration.DeltaM.Contracts
{
    public class ChatClosedEvent : BaseIntegrationEvent
    {
        public ClosedChatModel Model { get; set; }

        public ChatClosedEvent(ClosedChatModel model) : base("ChatClosed")
        {
            Model = model;
        }
    }
}
