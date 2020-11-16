using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] string menuSceneName = "MainMenu";

    [SerializeField] string nextLevel = "Level02";
    [SerializeField] int levelToUnlock = 2;

    [SerializeField] SceneFader sceneFader;


    [SerializeField] GameObject[] disableUI;

    private void Start()
    {
        for (int i = 0; i < disableUI.Length; i++)
        {
            disableUI[i].SetActive(false);
        }
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(menuSceneName);
    }
}
