using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockAppear : MonoBehaviour
{
    //script to make a rock appear on the path with particles to cover its appearance

    private float startTime, currentTime, timeDif;
    private ParticleSystem particles;
    private Renderer objRenderer;
    // Start is called before the first frame update
    void Awake()
    {
      //define particles and start playing
      particles = GetComponent<ParticleSystem>();
      objRenderer = GetComponent<Renderer>();
      particles.Play();
      startTime = Time.time;
      currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
      //count time, after3 seconds make the rock appear, after 7 make the particles stop
      timeDif = currentTime - startTime;
      if (timeDif <= 7f)
      {
        currentTime=Time.time;
        if (timeDif >= 3f)
        {
          objRenderer.enabled = true;
        }
      }
      else
      {
        particles.Stop();
        enabled=false;
      }
    }
}
