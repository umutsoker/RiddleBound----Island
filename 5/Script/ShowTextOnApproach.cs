using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextOnApproach : MonoBehaviour
{
    public GameObject pressFText;  // UI yazýsý
    private bool nearBookshelf = false;

    void Start()
    {
        pressFText.SetActive(false);  // Sahne baþýnda yazý kapalý
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bookshelf"))
        {
            pressFText.SetActive(true);   // Yaklaþtýðýnda yazýyý göster
            nearBookshelf = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bookshelf"))
        {
            pressFText.SetActive(false);  // Uzaklaþýnca yazýyý gizle
            nearBookshelf = false;
        }
    }
}

