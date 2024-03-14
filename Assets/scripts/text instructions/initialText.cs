using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class initialText : MonoBehaviour
{
    //create initial text instructions for user
    //public TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableAfterDelay(7f));
    }
    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        enabled=false;
    }

}
