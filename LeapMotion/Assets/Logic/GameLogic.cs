using System;
using Assets.Interfaces;
using UniRx;

namespace Assets.Logic
{
    public class GameLogic
    {
        private readonly IPlayer _playerOne;
        private readonly IPlayer _playerTwo;
        private readonly IGestureComparator _gestureComparator;
        private readonly Subject<GameState> _gameStateSubject = new Subject<GameState>();
        private IDisposable _subscription;

        private GameState _currentGameState = new GameState();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerOne">The human player</param>
        /// <param name="playerTwo">The ai player</param>
        /// <param name="gestureComparator"></param>
        public GameLogic(IPlayer playerOne, IPlayer playerTwo, IGestureComparator gestureComparator)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _gestureComparator = gestureComparator;
            SetUpSubscriptions();
        }

        private void SetUpSubscriptions()
        {
           _subscription = _playerOne.GetPlayerState()
                .Zip(_playerTwo.GetPlayerState(), new Func<PlayerState,PlayerState,GameState>(HandlePlayerStates))
                .Where((gameState) => gameState != null)
                .Subscribe(gamestate => _gameStateSubject.OnNext(gamestate));
        }

        public IObservable<GameState> GetGameState()
        {
            return _gameStateSubject;
        }

        private GameState HandlePlayerStates(PlayerState playerOneState, PlayerState playerTwoState)
        {
            if (playerOneState.HasChosenGesture && playerTwoState.HasChosenGesture)
            {
                var compareResult = _gestureComparator.CompareGestures(playerOneState.CurrentGesture,
                    playerTwoState.CurrentGesture);


            }
            return null;
        }
    }
}
