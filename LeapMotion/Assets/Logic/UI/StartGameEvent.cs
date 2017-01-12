using System.Collections;
using System.Collections.Generic;
using Assets.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        DontDestroyOnLoad(GameObject.Find("ConfigObject"));
        SceneManager.LoadScene(1);
    }
}
