using AnimalMarketCommon.Attributes;
using AnimalMarketDal.DomainModel;
using AnimalMarketEngine.DataAccess;
using AnimalMarketEngine.Engine;
using AnimalMarketEngine.Model;

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
                Calf = new IterationEventItemData { Cost = _eventListData.GetCowType().MeanCost, Name = _eventListData.GetCowType().Name },
                Pig = new IterationEventItemData { Cost = _eventListData.GetPigType().MeanCost, Name = _eventListData.GetPigType().Name },
                Lamb = new IterationEventItemData { Cost = _eventListData.GetLambType().MeanCost, Name = _eventListData.GetLambType().Name }
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
                MessageText = data.StringTestId,
                Name = animal.Name
            };
        }

        public void Dispose()
        {
            _eventListData.Dispose();
        }
    }
}