namespace ItSymphony.Integration.DeltaM.Contracts
{
    public class BaseIntegrationEvent
    {
        public string Type { get; }

        public BaseIntegrationEvent(string type)
        {
            Type = type;
        }
    }
}
