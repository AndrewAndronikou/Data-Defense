using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageLog : MonoBehaviour
{
    public static MessageLog instance;

    private void Awake()
    {
        instance = this;
    }

    public Text messageText;

    [SerializeField] int waitTime;
    [SerializeField] float fadeTime;

    private void Start()
    {
        messageText.CrossFadeAlpha(0, 0, false);
    }

    public void ShowMessage(string message)
    {
        messageText.CrossFadeAlpha(1, 0, false);

        messageText.text = message;

        StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
    {
        yield return new WaitForSeconds(waitTime);

        messageText.CrossFadeAlpha(0, fadeTime, false);
    }


}
