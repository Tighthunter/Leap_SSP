using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;
using UniRx;

namespace Assets.Logic
{
    public class PrimitiveAIPlayer : IPlayer
    {


        public IObservable<PlayerState> GetPlayerState()
        {
            throw new NotImplementedException();
        }
    }
}
