using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] SceneFader sceneFader;
    [SerializeField] string menuSceneName = "MainMenu";
    [SerializeField] GameObject[] disableUI;

    private void Start()
    {
        for (int i = 0; i < disableUI.Length; i++)
        {
            disableUI[i].SetActive(false);
        }

        Enemy[] findEnemies = FindObjectsOfType<Enemy>();

        for (int i = 0; i < findEnemies.Length; i++)
        {
            findEnemies[i].Die();
           // Destroy(findEnemies[i].gameObject);
        }      
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       // waveSpawner.EnemiesAlive = 0;
        // sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
