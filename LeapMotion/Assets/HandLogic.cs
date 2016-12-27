using System;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

namespace Assets
{
    public static class HandLogic
    {
        public static Gesture GetGesture()
        {
            try
            {
                Controller controller = new Controller();
                Frame frame = controller.Frame();

                List<Hand> HandList = frame.Hands;
                List<Finger> FingerList = HandList[0].Fingers;

                PointingState[] pointingstates = new PointingState[5];
                int i = 0;
                foreach (var finger in FingerList)
                {
                    if (finger.IsExtended)
                    {
                        pointingstates[i] = PointingState.Extended;
                    }
                    else
                    {
                        pointingstates[i] = PointingState.NotExtended;
                    }
                    i++;
                }
                return compareGesture(pointingstates);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static Gesture compareGesture(PointingState[] pointStates)
        {
            List<Gesture> GestureList = new List<Gesture>();
            GestureList.Add(Gesture.GesturePaper);
            GestureList.Add(Gesture.GestureScissors);
            GestureList.Add(Gesture.GestureStone);

            Gesture g = null;

            foreach (var gesture in GestureList)
            {
                int i = 0;
                bool found = true;
                foreach (var pointingState in gesture.pointingStates)
                {
                    if (pointingState != pointStates[i++])
                    {
                        found = false;
                        break;
                    }
                }
                if(found)
                    g = gesture;
            }
            return g;
        }
    }
}
