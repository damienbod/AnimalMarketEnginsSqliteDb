using System.Collections.Generic;
using AnimalMarketCommon.Attributes;
using AnimalMarketEngine.Engine;
using AnimalMarketEngine.Resources;

namespace AnimalMarketEngine.DataAccess
{
    [LifecycleSingleton]
    public class EventListData : IEventListData
    {
        public EventListData()
        {
            AddPigData();
            AddCalfData();
            AddLambData();
        }

        private readonly List<EventData> _pigEventData = new List<EventData>();
        private readonly List<EventData> _calfEventData = new List<EventData>();
        private readonly List<EventData> _lambEventData = new List<EventData>();

        private void AddPigData()
        {
            _pigEventData.Add(new EventData { Factor = 30, StringTestId = TextsResource.PressureOnThePigMarket , FixChange = 10.0});
            _pigEventData.Add(new EventData { Factor = 50, StringTestId = TextsResource.Speculation, FixChange = 10.0 });
            _pigEventData.Add(new EventData { Factor = 70, StringTestId = TextsResource.AdvertisingPush, FixChange = 10.0 });
            _pigEventData.Add(new EventData { Factor = 30, StringTestId = TextsResource.PressureOnThePigMarket, FixChange = 10.0 });
            _pigEventData.Add(new EventData { Factor = 50, StringTestId = TextsResource.FestivalSeason, FixChange = 20.0 });
            _pigEventData.Add(new EventData { Factor = 70, StringTestId = TextsResource.PressureOnThePigMarket, FixChange = 20.0 });
            _pigEventData.Add(new EventData { Factor = 40, StringTestId = TextsResource.PressureOnThePigMarket, FixChange = 10.0 });

            _pigEventData.Add(new EventData { Factor = -60, StringTestId = TextsResource.MulberryHeartDiseasevitaminEdeficiency, FixChange = -10.0 });
            _pigEventData.Add(new EventData { Factor = -80, StringTestId = TextsResource.FootAndMouthDisease, FixChange = -10.0 });
            _pigEventData.Add(new EventData { Factor = -40, StringTestId = TextsResource.Hypoglycaemia, FixChange = -20.0 });
            _pigEventData.Add(new EventData { Factor = -60, StringTestId = TextsResource.Sunburn, FixChange = -20.0 });
            _pigEventData.Add(new EventData { Factor = -80, StringTestId = TextsResource.BushFootFootRot, FixChange = -10.0 });
            _pigEventData.Add(new EventData { Factor = -40, StringTestId = TextsResource.BiotinDeficiency, FixChange = -20.0 });
        }

        private void AddCalfData()
        {
            _calfEventData.Add(new EventData { Factor = 10, StringTestId = TextsResource.PressureOnTheBeefMarket, FixChange = 20.0 });
            _calfEventData.Add(new EventData { Factor = 10, StringTestId = TextsResource.ShortageOfBeef, FixChange = 10.0 });
            _calfEventData.Add(new EventData { Factor = 40, StringTestId = TextsResource.BanksSpeculationBeef, FixChange = 40.0 });

            _calfEventData.Add(new EventData { Factor = -40, StringTestId = TextsResource.MarketCrash, FixChange = -50.0 });
            _calfEventData.Add(new EventData { Factor = -40, StringTestId = TextsResource.CalfScour, FixChange = -20.0 });
            _calfEventData.Add(new EventData { Factor = -40, StringTestId = TextsResource.MadCowDisease, FixChange = -20.0 });
        }

        private void AddLambData()
        {
            _lambEventData.Add(new EventData { Factor = 10, StringTestId = TextsResource.PressureOnTheSheepMarket, FixChange = 30.0 });
            _lambEventData.Add(new EventData { Factor = 50, StringTestId = TextsResource.FestivalSeasonSheep, FixChange = 20.0 });
            _lambEventData.Add(new EventData { Factor = 40, StringTestId = TextsResource.AdvertisingPushLamb, FixChange = 10.0 });
            _lambEventData.Add(new EventData { Factor = 30, StringTestId = TextsResource.PressureOnTheSheepMarket, FixChange = 15.0 });

            _lambEventData.Add(new EventData { Factor = -40, StringTestId = TextsResource.CacheValleyVirus, FixChange = -10.0 });
            _lambEventData.Add(new EventData { Factor = -30, StringTestId = TextsResource.SheepFootandmouthdisease, FixChange = -15.0 });
            _lambEventData.Add(new EventData { Factor = -50, StringTestId = TextsResource.Footrot, FixChange = -20.0 });
            _lambEventData.Add(new EventData { Factor = -10, StringTestId = TextsResource.Whitemuscledisease, FixChange = -30.0 });
        }

        public EventData GetPigEvent()
        {
            return _pigEventData[ThreadLocalRandom.Next(1, _pigEventData.Count) - 1];
        }

        public EventData GetLambEvent()
        {
            return _lambEventData[ThreadLocalRandom.Next(1, _lambEventData.Count) - 1];
        }

        public EventData GetCalfEvent()
        {
            return _calfEventData[ThreadLocalRandom.Next(1, _calfEventData.Count) - 1];
        }
    }
}