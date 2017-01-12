using System.Collections;
using System.Collections.Generic;
using Leap.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

public class UiSliderEvent : MonoBehaviour
{
    private Slider slider;
    private Text text;
    private int sliderValueUneven;
    
    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        text = transform.parent.GetChild(1).GetComponent<Text>();
        sliderValueUneven =(int) (slider.value - (slider.value % 2 - 1));
        text.text = "Best of " + sliderValueUneven;
        GameObject.Find("ConfigObject").GetComponent<ConfigObject>().SetBestOfRounds(sliderValueUneven);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateText()
    {
        sliderValueUneven = (int)(slider.value - (slider.value%2 - 1));
        text.text = "Best of " + sliderValueUneven;
        GameObject.Find("ConfigObject").GetComponent<ConfigObject>().SetBestOfRounds(sliderValueUneven);
    }

    public int GetSliderValue()
    {
        return sliderValueUneven;
    }
}