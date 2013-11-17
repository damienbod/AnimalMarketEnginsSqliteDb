using System.Web.Http;
using AnimalMarketCommon.Attributes;
using AnimalMarketEngine.Managers;
using AnimalMarketEngine.Model;

namespace AnimalMarketEngine.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameManager _gameManager;

        public GameController(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        // Test method
        public Iteration Get()
        {
            return _gameManager.GetNextIteration();
        }
    }
}