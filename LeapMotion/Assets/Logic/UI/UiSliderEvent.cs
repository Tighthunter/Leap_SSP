using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSliderEvent : MonoBehaviour
{

    private Slider slider;
    private Text text;

	// Use this for initialization
	void Start ()
	{
	   slider = GetComponent<Slider>();
        text = transform.parent.GetChild(1).GetComponent<Text>();
        text.text = "Best of " + slider.value;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateText()
    {
        text.text = "Best of " + slider.value;
    }
}
