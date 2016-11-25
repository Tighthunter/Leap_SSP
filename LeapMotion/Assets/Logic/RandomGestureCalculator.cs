using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;

namespace Assets.Logic
{
    public class RandomGestureCalculator : IGestureCalculator
    {
        private readonly Gesture[] _gestures;
        private Random random = new Random();

        public RandomGestureCalculator(Gesture[] gestures)
        {
            _gestures = gestures;
        }

        public Gesture CalculateNextGesture()
        {
            int index = random.Next(0, _gestures.Length);
            return _gestures[index];
        }
    }
}
