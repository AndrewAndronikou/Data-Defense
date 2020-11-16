using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedChanger : MonoBehaviour
{
    [SerializeField] Text speedText;
    bool boolToggleButton;

    private void Start()
    {
        boolToggleButton = true;
    }

    public void Toggle()
    {
        if (boolToggleButton)
        {
            speedText.text = "1x";
            Time.timeScale = 2f;
            boolToggleButton = false;
        }
        else
        {
            speedText.text = "2x";
            Time.timeScale = 1f;
            boolToggleButton = true;
        }
    }
}
