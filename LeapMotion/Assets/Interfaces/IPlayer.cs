using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;

namespace Assets.Interfaces
{
    public interface IPlayer
    {
        IObservable<PlayerState> GetPlayerState();
    }
}
