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

        //http://answers.unity3d.com/questions/37411/how-can-i-wait-for-an-animation-to-complete.html

        void Awake()
        {
            animation = GetComponent<Animation>();
        }

        void Update()
        {
            //return null;
            //yield return StartCoroutine(WaitForAnimation(animation));
        }

        public IObservable<PlayerState> GetPlayerState()
        {
            throw new NotImplementedException();
        }

        private IEnumerator WaitForAnimation(Animation animation)
        {
            do
            {
                yield return null;
            } while (animation.isPlaying);
        }

    }
}
