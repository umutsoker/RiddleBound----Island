using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // TextMeshPro 

public class EnterHouse : MonoBehaviour
{
    public GameObject pressEText;   //  TMP_Text nesne
    public string sceneToLoad = "Oda"; // Geçilecek sahnenin adý
    private bool isNearHouse = false;

    private void Start()
    {
        pressEText.SetActive(false);  // Baþlangýçta yazý gizli
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnterTrigger"))
        {
            pressEText.SetActive(true);  // Eve yaklaþýldýðýnda yazýyý göster
            isNearHouse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnterTrigger"))
        {
            pressEText.SetActive(false);  // Evden uzaklaþýnca yazýyý gizle
            isNearHouse = false;
        }
    }

    private void Update()
    {
        if (isNearHouse && Input.GetKeyDown(KeyCode.E))
        {
            // Sahne geçiþi yap
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
