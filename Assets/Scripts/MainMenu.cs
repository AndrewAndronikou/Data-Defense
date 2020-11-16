using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelToLoad = "MainLevel";
    [SerializeField] SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exitting...");
        Application.Quit();
    }
}
