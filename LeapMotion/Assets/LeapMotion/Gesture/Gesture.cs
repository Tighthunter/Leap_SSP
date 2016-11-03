using UnityEngine;
using System.Collections;
using Leap.Unity;

class Gesture : MonoBehaviour {
    string gestureName;
    int id;
    public int[] beats;

    PointingState[] pointingStates;

    public Gesture(string gestureName, int id, int[] beats, PointingState[] states)
    {
        this.gestureName = gestureName;
        this.id = id;
        this.beats = beats;
        this.pointingStates = states;
    }
}
