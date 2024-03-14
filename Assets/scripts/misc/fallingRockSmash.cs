using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingRockSmash : MonoBehaviour
{
    //small script responsible for the falling rocks to make particles and noises
    public AudioSource parentAudio;
    public ParticleSystem parentParticle;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("falling rock") && other.gameObject.layer != LayerMask.NameToLayer("agent") && other.gameObject.layer != LayerMask.NameToLayer("Subject"))
        {
          //if the trigger hit is not a player or a falling rock or the agent, play the sound and particles
          parentParticle = transform.parent.gameObject.GetComponent<ParticleSystem>();
          parentParticle.Play();
          //Debug.Log("workin");
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("path") )//if it is a path play the audio with random pitch
        {
          parentAudio = transform.parent.gameObject.GetComponent<AudioSource>();
          parentAudio.pitch = Random.Range(0.6f,1.3f);
          parentAudio.Play();
        }
    }
}
