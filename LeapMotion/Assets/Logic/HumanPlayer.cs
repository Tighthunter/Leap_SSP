using System;
using Assets.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Logic
{
    public class HumanPlayer : MonoBehaviour, IPlayer
    {
        public IPlayer AiPlayer { get; set; }
        private Gesture _lastValidGesture;

        public void Awake()
        {
            Observable.EveryFixedUpdate().Subscribe(CheckCurrentGesture).AddTo(this);
        }

        public IObservable<PlayerState> GetPlayerState()
        {
            return CalcHumanState();
        }

        private IObservable<PlayerState> CalcHumanState()
        {
            return AiPlayer.GetPlayerState()
                .Delay(TimeSpan.FromMilliseconds(200))
                .Select<PlayerState, PlayerState>(GetMyState);
        }

        private PlayerState GetMyState(PlayerState aiState)
        {
            return aiState.HasChosenGesture ? new PlayerState() {HasChosenGesture = true, CurrentGesture = _lastValidGesture} : new PlayerState() {CurrentGesture = _lastValidGesture};
        }

        private void CheckCurrentGesture(long time)
        {
            var gesture = HandLogic.GetGesture();
            if (gesture != null)
            {
                _lastValidGesture = HandLogic.GetGesture();
            }
            
            //Debug.Log("Current human Gesture is: " + (_lastValidGesture == null ? null : _lastValidGesture.gestureName));
        }
    }
}
