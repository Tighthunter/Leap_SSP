using System.Collections;
using System.Collections.Generic;
using Assets.Interfaces;
using UnityEngine;

public class ConfigObject : MonoBehaviour
{

    private int bestOfRounds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetBestOfRounds(int bestOfRounds)
    {
        this.bestOfRounds = bestOfRounds;
    }

    public GameConfig GetGameConfig()
    {
        return new GameConfig() {BestOfRounds = bestOfRounds};
    }
}
