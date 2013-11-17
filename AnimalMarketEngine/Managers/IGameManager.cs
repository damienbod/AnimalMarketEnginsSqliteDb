using System;
using AnimalMarketEngine.Model;

namespace AnimalMarketEngine.Managers
{
    public interface IGameManager : IDisposable
    {
        Iteration GetNextIteration();
    }
}
