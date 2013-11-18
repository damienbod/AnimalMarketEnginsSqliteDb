using System;
using AnimalMarketCommon.Attributes;
using AnimalMarketDal.DomainModel;
using AnimalMarketEngine.DataAccess;
using AnimalMarketEngine.Engine;
using AnimalMarketEngine.Model;
using AnimalMarketEngine.Resources;

namespace AnimalMarketEngine.Managers
{
    [LifecycleSingleton]
    public class GameManager : IGameManager
    {
        private readonly IEventListData _eventListData;
        private readonly IValueGenerator _valueGenerator;

        private Iteration _iterationLastValue;

        public GameManager(IEventListData eventListData, IValueGenerator valueGenerator)
        {
            _eventListData = eventListData;
            _valueGenerator = valueGenerator;
            InitGame();
        }

        private void InitGame()
        {
            _iterationLastValue = new Iteration
            {
                Calf = new IterationEventItemData { Cost = _eventListData.GetCowType().MeanCost, Name = TextsResource.GetResourceFromKey(_eventListData.GetCowType().Name) },
                Pig = new IterationEventItemData { Cost = _eventListData.GetPigType().MeanCost, Name = TextsResource.GetResourceFromKey(_eventListData.GetPigType().Name) },
                Lamb = new IterationEventItemData { Cost = _eventListData.GetLambType().MeanCost, Name = TextsResource.GetResourceFromKey(_eventListData.GetLambType().Name) }
            };
        }

        public Iteration GetNextIteration()
        {
            var iteration = new Iteration
            {
                Calf = SetNextIterationForType(_iterationLastValue.Calf, _eventListData.GetCalfEvent(), _eventListData.GetCowType().MeanCost),
                Pig = SetNextIterationForType(_iterationLastValue.Pig, _eventListData.GetPigEvent(), _eventListData.GetPigType().MeanCost),
                Lamb = SetNextIterationForType(_iterationLastValue.Lamb, _eventListData.GetLambEvent(), _eventListData.GetLambType().MeanCost)
            };
            _iterationLastValue = iteration;
            return iteration;
        }

        private IterationEventItemData SetNextIterationForType(IterationEventItemData animal, EventData data, double  meanValueTarget)
        {
            return new IterationEventItemData
            {
                Cost = _valueGenerator.GetNextValue(animal.Cost, data.Factor, data.FixChange, meanValueTarget),
                MessageText = TextsResource.GetResourceFromKey(data.StringTestId),
                Name = animal.Name
            };
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _eventListData.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}