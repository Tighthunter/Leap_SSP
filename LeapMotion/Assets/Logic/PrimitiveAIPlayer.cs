using Assets.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Logic
{
    public class PrimitiveAiPlayer : MonoBehaviour, IAiPlayer
    {
        private Animation _animation;
        private bool _hasStarted;
        private int _currentAnimsPlayedCount;
        private readonly Subject<int> _animFinishedSubject = new Subject<int>();

        public IGestureCalculator GestureCalculator { get; set; }

        public MappedHand[] MappedHands;
        public int AnimTimesToPlay = 3;

        private IObservable<PlayerState> myState;

        public void Awake()
        {
            _animation = GetComponent<Animation>();
        }

        public void StartAi()
        {
            if (!_hasStarted)
            {
                _animation.Play();
            }
        }

        public void ResetAi()
        {
            _hasStarted = false;
            _currentAnimsPlayedCount = 0;
        }

        public void OnAnimationFinished()
        {
            Debug.Log("Animation finished");
            _animFinishedSubject.OnNext(++_currentAnimsPlayedCount);
            if (_currentAnimsPlayedCount >= AnimTimesToPlay) return;

            _animation.Rewind();
            _animation.Play();
        }

        public IObservable<PlayerState> GetPlayerState()
        {
            //TODO multiple subscriber only 1 emit
            return myState ?? (myState = _animFinishedSubject.Select<int, PlayerState>(CalcAiState).Share());
        }

        private PlayerState CalcAiState(int animCount)
        {
            var current = new PlayerState { TimesTried = animCount };
            if (animCount >= AnimTimesToPlay)
            {
                current.HasChosenGesture = true;
                current.CurrentGesture = GestureCalculator.CalculateNextGesture();
            }
            Debug.Log("Current AI State is: " + current);
            return current;
        }
    }
}
