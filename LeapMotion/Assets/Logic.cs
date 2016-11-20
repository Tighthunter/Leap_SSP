using UnityEngine;
using System.Collections;
using Leap.Unity;
using System.Linq;
using Leap;

class Logic : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
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
