using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    //change the text that is given to the user as instructions
    public TextMeshPro text;
    public GameObject playerCommunicator;
    //public LayerMask layer;
    public string layerName;
    [TextArea]
    public string newtext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(layerName))
        {
          text = playerCommunicator.GetComponent<TextMeshPro>();
          text.text=newtext;
          playerCommunicator.SetActive(true);
          StartCoroutine(DisableAfterDelay(5f));
        }
    }

    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerCommunicator.SetActive(false);
    }

}
