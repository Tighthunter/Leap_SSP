using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;
using Assets.Logic.Mock;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Logic
{
    public class GameInjector : MonoBehaviour
    {
        private GameInjector _instance;

        public PrimitiveAiPlayer AiPlayer;
        public Text EnemyWinCount;
        public Text PlayerWinCount;
        public Text Countdown;

        private UiLogic _uiLogic;

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }

            //Inject properties here
            if (AiPlayer != null)
            {
                AiPlayer.GestureCalculator = new RandomGestureCalculator(new[] {Gesture.GesturePaper, Gesture.GestureScissors, Gesture.GestureStone});
            }
        }

        public IConfigManager GetConfigManager()
        {
            //TODO: martin bitte hier die config laden und einen manager zurückgeben
            return new MockConfigManager();
        }
    }
}
