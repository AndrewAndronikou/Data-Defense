using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    // Update is called once per frame
    void Update()
    {
        //FOR MOBILE CONSIDER USING COROUTINE
        livesText.text = PlayerStats.Lives + " LIVES";
    }
}
