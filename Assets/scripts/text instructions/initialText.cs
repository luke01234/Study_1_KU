using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class initialText : MonoBehaviour
{
    //create initial text instructions for user
    //public TextMesh text;
    // Start is called before the first frame update
    public TextMeshPro text;
    [TextArea]
    public string newtext;
    public AudioClip alarmSound;
    void Start()
    { 
        text = this.GetComponent<TextMeshPro>();
        text.text = newtext;
        StartCoroutine(DisableAfterDelay(7f));
        PlayAlarmSound();
    }
    public void PlayAlarmSound()
    {
        // Create a new GameObject to hold the AudioSource
        GameObject audioObject = new GameObject("AudioSource");
        audioObject.transform.position = this.transform.position;

        // Add an AudioSource component to the GameObject
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        // Set the AudioClip to play
        audioSource.volume = .2f;
        audioSource.clip = alarmSound;

        // Play the sound
        audioSource.Play();

        // Destroy the AudioSource after the sound has finished playing
        Destroy(audioObject, alarmSound.length);
    }
    public void SetText(string instruction)
    {
      text.text = instruction;
      PlayAlarmSound();
    }
    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        enabled=false;
    }

}
