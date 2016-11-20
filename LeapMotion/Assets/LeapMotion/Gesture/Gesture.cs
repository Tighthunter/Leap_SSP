using UnityEngine;
using System.Collections;
using Leap.Unity;

public class Gesture
{
    public string gestureName;
    int id;
    public int[] beats;

    public PointingState[] pointingStates;

    public Gesture(string gestureName, int id, int[] beats, PointingState[] states)
    {
        this.gestureName = gestureName;
        this.id = id;
        this.beats = beats;
        this.pointingStates = states;
    }

    public override bool Equals(object o)
    {
        if (o != this || o.GetType() != typeof(Gesture))
        {
            return false;
        }
        else
        {
            var other = (Gesture) o;
            if (other.gestureName == this.gestureName)
                return true;
        }
        return false;
    }

    public static readonly Gesture GestureStone = new Gesture("Stone", 1, new int[] { 3 }, new PointingState[] { PointingState.NotExtended, PointingState.NotExtended, PointingState.NotExtended, PointingState.NotExtended, PointingState.NotExtended });
    public static readonly Gesture GesturePaper = new Gesture("Paper", 2, new int[] { 1 }, new PointingState[] { PointingState.Extended, PointingState.Extended, PointingState.Extended, PointingState.Extended, PointingState.Extended });
    public static readonly Gesture GestureScissors = new Gesture("Scissors", 3, new int[] { 2 }, new PointingState[] { PointingState.Either, PointingState.Extended, PointingState.Extended, PointingState.NotExtended, PointingState.NotExtended });
}
