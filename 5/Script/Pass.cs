using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // TextMeshPro 

public class EnterHouse : MonoBehaviour
{
    public GameObject pressEText;   //  TMP_Text nesne
    public string sceneToLoad = "Oda"; // Ge�ilecek sahnenin ad�
    private bool isNearHouse = false;

    private void Start()
    {
        pressEText.SetActive(false);  // Ba�lang��ta yaz� gizli
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnterTrigger"))
        {
            pressEText.SetActive(true);  // Eve yakla��ld���nda yaz�y� g�ster
            isNearHouse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnterTrigger"))
        {
            pressEText.SetActive(false);  // Evden uzakla��nca yaz�y� gizle
            isNearHouse = false;
        }
    }

    private void Update()
    {
        if (isNearHouse && Input.GetKeyDown(KeyCode.E))
        {
            // Sahne ge�i�i yap
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
