using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Interfaces
{
    public interface IGestureComparator
    {
        /// <summary>
        /// True if gesture one wins, false otherwise
        /// </summary>
        /// <param name="gestureOne"></param>
        /// <param name="gestureTwo"></param>
        /// <returns></returns>
        GestureCompareResult CompareGestures(Gesture gestureOne, Gesture gestureTwo);
    }
}
