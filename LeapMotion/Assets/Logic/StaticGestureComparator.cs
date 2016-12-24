using Assets.Interfaces;

namespace Assets.Logic
{
    internal class StaticGestureComparator : IGestureComparator
    {
        public GestureCompareResult CompareGestures(Gesture gestureOne, Gesture gestureTwo)
        {
            if (Equals(gestureOne, Gesture.GestureStone))
            {
                if(Equals(gestureTwo, Gesture.GesturePaper))
                { return GestureCompareResult.GestureTwoWon;}
                if(Equals(gestureTwo, Gesture.GestureScissors))
                { return GestureCompareResult.GestureOneWon;}
                if(Equals(gestureTwo, Gesture.GestureStone))
                { return GestureCompareResult.Draw;}
            }
            else if (Equals(gestureOne, Gesture.GesturePaper))
            {
                if (Equals(gestureTwo, Gesture.GesturePaper))
                { return GestureCompareResult.Draw; }
                if (Equals(gestureTwo, Gesture.GestureScissors))
                { return GestureCompareResult.GestureTwoWon; }
                if (Equals(gestureTwo, Gesture.GestureStone))
                { return GestureCompareResult.GestureOneWon; }
            }
            else if (Equals(gestureOne, Gesture.GestureScissors))
            {
                if (Equals(gestureTwo, Gesture.GesturePaper))
                { return GestureCompareResult.GestureOneWon; }
                if (Equals(gestureTwo, Gesture.GestureScissors))
                { return GestureCompareResult.Draw; }
                if (Equals(gestureTwo, Gesture.GestureStone))
                { return GestureCompareResult.GestureTwoWon; }
            }

            return GestureCompareResult.Draw;
        }
    }
}
