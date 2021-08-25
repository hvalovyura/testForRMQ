using ItSymphony.Integration.DeltaM.Contracts.Models;

namespace ItSymphony.Integration.DeltaM.Contracts
{
    public class NewMessageEvent : BaseIntegrationEvent
    {
        public NewMessageModel Model { get; set; }

        public NewMessageEvent(NewMessageModel model) : base("NewMessage")
        {
            Model = model;
        }
    }
}