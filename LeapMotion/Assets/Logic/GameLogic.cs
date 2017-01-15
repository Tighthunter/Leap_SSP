using System;
using Assets.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Logic
{
    public class GameLogic
    {
        private readonly IPlayer _humanPlayer;
        private readonly IAiPlayer _aiPlayer;
        private readonly IGestureComparator _gestureComparator;
        private readonly GameConfig _gameConfig;
        private readonly IObservable<long> _cancelKeyObservable;
        private readonly IObservable<long> _startKeyObservable;
        private readonly Subject<GameState> _gameStateSubject = new Subject<GameState>();
        private IDisposable _subscription;

        private readonly GameState _currentGameState = new GameState();

        public GameLogic(IPlayer humanPlayer, IAiPlayer aiPlayer, IGestureComparator gestureComparator, GameConfig gameConfig, IObservable<long> cancelKeyObservable, IObservable<long> startKeyObservable)
        {
            _humanPlayer = humanPlayer;
            _aiPlayer = aiPlayer;
            _gestureComparator = gestureComparator;
            _gameConfig = gameConfig;
            _cancelKeyObservable = cancelKeyObservable;
            _startKeyObservable = startKeyObservable;

            SetUpSubscriptions();
        }

        private void SetUpSubscriptions()
        {
            _subscription = _humanPlayer.GetPlayerState()
                 .Zip(_aiPlayer.GetPlayerState(), new Func<PlayerState, PlayerState, GameState>(HandlePlayerStates))
                 .Where((gameState) => gameState != null)
                 .Subscribe(gamestate => _gameStateSubject.OnNext(gamestate));

            _startKeyObservable.Subscribe(OnStartKey);
            _cancelKeyObservable.Subscribe(OnCancelKey);
        }

        public IObservable<GameState> GetGameState()
        {
            return _gameStateSubject;
        }

        private void OnStartKey(long diff)
        {
            if(!_currentGameState.GameIsFinished)
                _aiPlayer.StartAi();
        }

        private void OnCancelKey(long diff)
        {
            SceneManager.LoadScene("Start_Menu");
        }

        private GameState HandlePlayerStates(PlayerState humanPlayerState, PlayerState aiPlayerState)
        {
            Debug.Log("Player states have been changed");

            if (!humanPlayerState.HasChosenGesture || !aiPlayerState.HasChosenGesture) return null;

            var compareResult = _gestureComparator.CompareGestures(humanPlayerState.CurrentGesture,
                aiPlayerState.CurrentGesture);

            Debug.Log("Did human player win?: " + (compareResult == GestureCompareResult.GestureOneWon));

            switch (compareResult)
            {
                case GestureCompareResult.GestureOneWon:
                    ++_currentGameState.HumanPlayerWinCount;
                    break;
                case GestureCompareResult.GestureTwoWon:
                    ++_currentGameState.AiPlayerWinCount;
                    break;
            }

            CheckCurrentGameState();
            _aiPlayer.ResetAi();

            Debug.Log("Current GameState is: " + _currentGameState);

            return _currentGameState;
        }

        private void CheckCurrentGameState()
        {
            var neededWins = _gameConfig.BestOfRounds / 2 + 1;
            if (_currentGameState.HumanPlayerWinCount >= neededWins)
            {
                _currentGameState.GameIsFinished = true;
                _currentGameState.WinnerName = "Human Player";
            }
            else if (_currentGameState.AiPlayerWinCount >= neededWins)
            {
                _currentGameState.GameIsFinished = true;
                _currentGameState.WinnerName = "Ai Player";
            }
        }
    }
}
