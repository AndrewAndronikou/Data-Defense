using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesAnimation : MonoBehaviour
{
    Renderer rend;
    [SerializeField] Gradient gradient;
    [SerializeField] float duration;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.Lives <= 2)
        {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = gradient.Evaluate(lerp);
        //Color.Lerp(colorStart, colorEnd, lerp);
        }
    }
}

