using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private int counter;
    [SerializeField] private TMP_Text CounterText;
    void OnMouseDown()
    {

        if (CounterText != null)
            CounterText.text ="Score: "+ counter++;
        
    }

}
