using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicSelect : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    int trackSelector;
    int currentTrack;

    // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType<BackgroundMusicSelect>().Length > 1)
        {
            Debug.Log("Destroying other background music");
            Destroy(gameObject);
        }
        trackSelector = Random.Range(0, clips.Length);
        currentTrack = trackSelector;
        audioSource.PlayOneShot(clips[trackSelector], 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying)
            return;
        else
        {
            currentTrack = trackSelector;
            trackSelector = Random.Range(0, clips.Length);

            if (trackSelector == currentTrack)
            {
                Debug.Log("Same Track");
                trackSelector = Random.Range(0, clips.Length);
                audioSource.PlayOneShot(clips[trackSelector], 1f);
            }
            else
            {
                audioSource.PlayOneShot(clips[trackSelector], 1f);
                Debug.Log(clips[trackSelector].name);
            }
        }
    }
}
