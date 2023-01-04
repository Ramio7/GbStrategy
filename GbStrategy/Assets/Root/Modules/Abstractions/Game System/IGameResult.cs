using System;

namespace Abstractions
{
    public interface IGameResult
    {
        IObservable<int> Status { get; }
    }
}
