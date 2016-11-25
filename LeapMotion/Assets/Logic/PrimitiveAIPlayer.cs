using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Logic
{
    public class PrimitiveAiPlayer : MonoBehaviour , IPlayer
    {
        private Animation animation;
        private bool hasStarted = false;
        private int currentAnimsPlayedCount = 0;
        private Subject<int> animFinishedSubject = new Subject<int>();
        public IGestureCalculator GestureCalculator { get; set; }

        public MappedHand[] MappedHands;
        public int AnimTimesToPlay = 3;

        //TODO: observable from event

        void Awake()
        {
            animation = GetComponent<Animation>();
        }

        public void StartAi()
        {
            if (!hasStarted)
            {
                animation.Play();
            }
        }

        public void OnAnimationFinished()
        {
            Debug.Log("Animation finished");
            animFinishedSubject.OnNext(++currentAnimsPlayedCount);
        }

        public IObservable<PlayerState> GetPlayerState()
        {
            throw new NotImplementedException();
        }

    }
}
