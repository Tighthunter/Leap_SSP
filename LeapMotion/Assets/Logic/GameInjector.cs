using Assets.Interfaces;
using Assets.Logic.Mock;
using UniRx;
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
        public HumanPlayer HumanPlayer;

        private IObservable<long> cancelKeyObservable;
        private IObservable<long> startKeyObservable;

        private UiLogic _uiLogic;
        private GameLogic _gameLogic;

        public void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
                return;
            }

            //Inject properties here
            cancelKeyObservable = Observable.EveryFixedUpdate().Where(_ => Input.GetKeyDown(KeyCode.Escape));
            startKeyObservable = Observable.EveryFixedUpdate().Where(_ => Input.GetKeyDown(KeyCode.Return));
            AiPlayer.GestureCalculator = new RandomGestureCalculator(new[] {Gesture.GesturePaper, Gesture.GestureScissors, Gesture.GestureStone});
            HumanPlayer.AiPlayer = AiPlayer;
            _gameLogic = new GameLogic(HumanPlayer, AiPlayer, new StaticGestureComparator(), GetConfigManager().GetGameConfiguration(), cancelKeyObservable, startKeyObservable);
            _uiLogic = new UiLogic(EnemyWinCount, PlayerWinCount, Countdown, _gameLogic.GetGameState(), AiPlayer.GetPlayerState());

            cancelKeyObservable.Subscribe().AddTo(this);
            startKeyObservable.Subscribe().AddTo(this);
        }

        public IConfigManager GetConfigManager()
        {
            return new ConfigManager();
        }
    }
}
