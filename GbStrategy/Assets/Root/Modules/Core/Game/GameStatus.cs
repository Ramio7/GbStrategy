using Abstractions;
using System;
using System.Threading;
using UniRx;
using UnityEngine;

public class GameStatus : MonoBehaviour, IGameResult
{
    public IObservable<int> Status => _status;

    private Subject<int> _status = new Subject<int>();

    private void CheckStatus(object state)
    {
        if (TeamSettings.TeamCount == 0)
        {
            _status.OnNext(0);
        }
        else if (TeamSettings.TeamCount == 1)
        {
            _status.OnNext(TeamSettings.GetWinner());
        }
    }

    private void Update()
    {
        ThreadPool.QueueUserWorkItem(CheckStatus);
    }
}
