using Assets.Interfaces;

namespace Assets.Logic
{
    class StaticGestureComparator : IGestureComparator
    {
        public GestureCompareResult CompareGestures(Gesture gestureOne, Gesture gestureTwo)
        {
            if (Equals(gestureOne, Gesture.GestureStone))
            {
                if(gestureTwo == Gesture.GesturePaper)
                { return GestureCompareResult.GestureTwoWon;}
                else if(gestureTwo == Gesture.GestureScissors)
                { return GestureCompareResult.GestureOneWon;}
                else if(gestureTwo == Gesture.GestureStone)
                { return GestureCompareResult.Draw;}
            }
            //TODO: the 2 others
        }
    }
}
