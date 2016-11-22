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
    public class PrimitiveAIPlayer : MonoBehaviour , IPlayer
    {
        private Animation animation;
        private bool hasStarted = false;
        private int currentAnimsPlayedCount = 0;

        public int AnimTimesToPlay = 3;

        //TODO: observable from event

        void Awake()
        {
            animation = GetComponent<Animation>();
            StartAi();
        }

        public void StartAi()
        {
            if (!hasStarted)
            {
                animation.Play();
            }
        }

        public void OnAnimationHalfFinished()
        {
            
            Debug.Log("Animation Half finished");
        }

        public void OnAnimationFinished()
        {
            Debug.Log("Animation finished");
        }

        public IObservable<PlayerState> GetPlayerState()
        {
            throw new NotImplementedException();
        }

    }
}
