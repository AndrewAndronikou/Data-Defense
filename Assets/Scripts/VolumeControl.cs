using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
