using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject completeLevelUI;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        //if (Input.GetKeyDown("e"))
        //{
        //    WinLevel();
        //}

        //if (Input.GetKeyDown("q"))
        //{
        //    EndGame();
        //}

        //if (Input.GetKeyDown("l"))
        //{
        //    Debug.Log("Levels Reset");
        //    PlayerPrefs.SetInt("levelReached", 1);
        //}

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
