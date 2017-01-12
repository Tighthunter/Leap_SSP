using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
