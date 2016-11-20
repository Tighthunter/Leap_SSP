using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Logic
{
    public class HumanPlayer : MonoBehaviour, IPlayer
    {
        private readonly IPlayer _aiPlayer;

        public HumanPlayer(IPlayer aiPlayer)
        {
            _aiPlayer = aiPlayer;
        }

        public IObservable<PlayerState> GetPlayerState()
        {
            throw new NotImplementedException();
        }
    }
}
