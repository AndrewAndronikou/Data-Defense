using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{ 
    [SerializeField] GameObject ui;
    [SerializeField] SceneFader sceneFader;
    [SerializeField] string menuSceneName = "MainMenu";
    [SerializeField] GameObject shopCanvas;
    [SerializeField] GameObject gameSpeedButton;



    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            shopCanvas.SetActive(false);
            gameSpeedButton.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            shopCanvas.SetActive(true);
            gameSpeedButton.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
