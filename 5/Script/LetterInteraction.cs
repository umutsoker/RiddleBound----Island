using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;          // TextMeshPro kullanýyorsan
using UnityEngine.UI; // Sadece Text kullanýyorsan bu satýrý kullan
using UnityEngine.SceneManagement;

public class LetterInteraction : MonoBehaviour
{
    public GameObject pressEText;       // “E basarak mektubu oku” UI Text objesi
    public GameObject letterPanel;      // Mektup içeriði için panel (UI)
    public TMP_Text letterText;         // Mektup içeriðinin gösterileceði TMP_Text
    public string letterContent = "Sevgili dostum, seni çok özledim..."; // Mektup metni

    private bool isNearLetter = false;
    private bool isReading = false;

    void Start()
    {
        pressEText.SetActive(false);
        letterPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LetterTrigger"))
        {
            pressEText.SetActive(true);
            isNearLetter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LetterTrigger"))
        {
            pressEText.SetActive(false);
            isNearLetter = false;
            if (isReading)
            {
                CloseLetter();
            }
        }
    }

    void Update()
    {
        if (isNearLetter && Input.GetKeyDown(KeyCode.E))
        {
            if (!isReading)
            {
                OpenLetter();
            }
            else
            {
                CloseLetter();
            }
        }
    }

    void OpenLetter()
    {
        isReading = true;
        pressEText.SetActive(false);
        letterPanel.SetActive(true);
        letterText.text = letterContent;
        // Burada karakter hareketini durdurabilirsin (opsiyonel)
    }

    void CloseLetter()
    {
        isReading = false;
        letterPanel.SetActive(false);
        pressEText.SetActive(true);
        // Karakter hareketini açabilirsin (opsiyonel)
    }
}
