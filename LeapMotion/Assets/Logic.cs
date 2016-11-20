using UnityEngine;
using System.Collections;
using Leap.Unity;
using System.Linq;
using Leap;

class Logic : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Gesture stone = new Gesture("Stone", 1, new int[] { 3 }, new PointingState[] { PointingState.NotExtended, PointingState.NotExtended, PointingState.NotExtended, PointingState.NotExtended, PointingState.NotExtended });
        Gesture paper = new Gesture("Paper", 2, new int[] { 1 }, new PointingState[] { PointingState.Extended, PointingState.Extended, PointingState.Extended, PointingState.Extended, PointingState.Extended });
        Gesture scissors = new Gesture("Scissors", 3, new int[] { 2 }, new PointingState[] { PointingState.Either, PointingState.Extended, PointingState.Extended, PointingState.NotExtended, PointingState.NotExtended });
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void TEST ()
    {
        var g = HandLogic.getGesture();
    }

    public int compareGestures(Gesture player1, Gesture player2)
    {
        foreach(var beat in player1.beats)
        {
            player2.beats.Where(x => x == beat);
        }
        return 0;
    }
}
