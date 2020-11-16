using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    [SerializeField] Text roundsText;
    [SerializeField] int levelToUnlock = 2;

    private void OnEnable()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.7f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.07f);
        }
    }
}
