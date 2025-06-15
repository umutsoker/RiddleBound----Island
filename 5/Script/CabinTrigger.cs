using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CabinTrigger.cs
public class CabinTrigger : MonoBehaviour
{
    public GameObject noteUI;
    bool inRange;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            // “E basarak oku” UI’sýný göster
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            noteUI.SetActive(false);
        }
    }
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            noteUI.SetActive(true);
        }
    }
}

