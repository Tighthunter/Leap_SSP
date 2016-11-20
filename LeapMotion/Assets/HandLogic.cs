using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public static class HandLogic
{
    public static Gesture getGesture()
    {
        Controller controller = new Controller();
        Frame frame = controller.Frame();

        List<Hand> HandList = frame.Hands;
        List<Finger> FingerList = HandList[0].Fingers;

        PointingState[] pointingstates = new PointingState[5];
        int i = 0;
        foreach (var finger in FingerList)
        {
            if(finger.IsExtended)
            {
                pointingstates[i] = PointingState.Extended;
            } else
            {
                pointingstates[i] = PointingState.NotExtended;
            }
            Debug.Log(pointingstates[i]);
            i++;
        }
        return compareGesture(pointingstates);
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
            if(gesture.pointingStates == pointStates)
            {
                g = gesture;
                Debug.Log("Gesture Found!: " + g);
            }
        }
        return g;
    }
}
