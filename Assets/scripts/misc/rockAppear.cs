using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockAppear : MonoBehaviour
{
    //script to make a rock appear on the path with particles to cover its appearance
    //script made redundant after rockslide change
    private float startTime, currentTime, timeDif;
    public float lifeTime = 3f;
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
        if (timeDif >= lifeTime)
        {
          //objRenderer.enabled = true;
        }
      }
      else
      {
        particles.Stop();
        enabled=false;
      }
    }
}
