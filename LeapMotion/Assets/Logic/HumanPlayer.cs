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
        private IDisposable aiSubscription;

        public HumanPlayer(IPlayer aiPlayer)
        {
            _aiPlayer = aiPlayer;
            aiSubscription = aiPlayer.GetPlayerState().Subscribe(HandleAiState);
        }

        private void HandleAiState(PlayerState aiState)
        {
            
        }

        public IObservable<PlayerState> GetPlayerState()
        {
            throw new NotImplementedException();
        }

        public IObservable<Gesture> GetPlayerGesture()
        {
            throw new NotImplementedException();
        }
    }
}
