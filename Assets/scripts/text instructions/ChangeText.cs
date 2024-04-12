using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class ChangeText : MonoBehaviour
{
    //change the text that is given to the user as instructions
    public TextMeshPro text;
    public AudioClip alarmSound;
    public GameObject playerCommunicator;
    //public LayerMask layer;
    public string layerName;
    [TextArea]
    public string newtext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(layerName))
        {
          playerCommunicator.GetComponent<initialText>().enabled = true;
          text = playerCommunicator.GetComponent<TextMeshPro>();
          text.text=newtext;
          playerCommunicator.SetActive(true);
          StartCoroutine(DisableAfterDelay(5f));
          GameObject audioObject = new GameObject("AudioSource");
          audioObject.transform.position = playerCommunicator.transform.position;

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
    }

    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerCommunicator.SetActive(false);
    }

}
