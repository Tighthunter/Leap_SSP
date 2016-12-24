using System;
using Assets.Interfaces;
using UniRx;
using UnityEngine.UI;

namespace Assets.Logic
{
    internal class UiLogic
    {
        const int MaxTimesTried = 3;

        private readonly Text _enemyText;
        private readonly Text _mainPlayerText;
        private readonly Text _countdownText;
        private readonly IObservable<GameState> _gameStateObservable;
        private readonly IObservable<PlayerState> _aiPlayerState;

        private IDisposable _subscriptionGameState;
        private IDisposable _subscriptionPlayerState;

        public UiLogic(Text enemyText, Text mainPlayerText, Text countdownText, IObservable<GameState> gameStateObservable, IObservable<PlayerState> aiPlayerState)
        {
            _enemyText = enemyText;
            _mainPlayerText = mainPlayerText;
            _countdownText = countdownText;
            _gameStateObservable = gameStateObservable;
            _aiPlayerState = aiPlayerState;

            SubscribeForGameChanges();
        }

        private void SubscribeForGameChanges()
        {
            _subscriptionGameState = _gameStateObservable.Subscribe(HandleGameChanges);
            _subscriptionPlayerState = _aiPlayerState.Subscribe(HandleAiChanges);
        }

        //for player count
        private void HandleGameChanges(GameState gameState)
        {
            if (gameState != null)
            {
                if (gameState.GameIsFinished)
                {
                    _countdownText.enabled = true;
                    _countdownText.text = gameState.WinnerName + " won the game! Press Escape to return to the menu";
                }
                _enemyText.text = gameState.PlayerOneWinCount.ToString();
                _mainPlayerText.text = gameState.PlayerTwoWinCount.ToString();
            }
        }

        //for cd
        private void HandleAiChanges(PlayerState playerState)
        {
            var remaining = MaxTimesTried - playerState.TimesTried;
            if (remaining == 0)
            {
                _countdownText.enabled = false;
            }
        }
    }
}