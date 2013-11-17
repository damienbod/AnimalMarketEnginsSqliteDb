namespace AnimalMarketEngine.DataAccess
{
    public interface IEventListData
    {
        EventData GetPigEvent();

        EventData GetLambEvent();

        EventData GetCalfEvent();
    }
}
