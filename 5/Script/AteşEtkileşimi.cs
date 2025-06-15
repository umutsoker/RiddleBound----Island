using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FireInteraction : MonoBehaviour
{
    public GameObject interactText;  // "Dosyaları yakmak için E'ye bas" yazısı
    public GameObject successText;   // "Dosyalar yakıldı!" yazısı
    private bool playerNearby = false;
    private bool hasBurnedFiles = false;

    void Start()
    {
        interactText.SetActive(false);
        if (successText != null) successText.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && !hasBurnedFiles && Input.GetKeyDown(KeyCode.E))
        {
            hasBurnedFiles = true;
            interactText.SetActive(false);
            StartCoroutine(BurnFilesAndShowSuccess());
        }
    }

    private IEnumerator BurnFilesAndShowSuccess()
    {
        Debug.Log("Dosyalar yanıyor...");
        yield return new WaitForSeconds(2f);

        if (successText != null)
        {
            successText.SetActive(true); // "Dosyalar yakıldı!" yazısı göster
            yield return new WaitForSeconds(4f); // 4 saniye bekle
            successText.SetActive(false); // Sonra yazıyı kapat
        }

        // (İstersen burada düşman spawn çağırabilirsin)
        // EnemySpawner.Instance.SpawnEnemies();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBurnedFiles)
        {
            playerNearby = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            interactText.SetActive(false);
        }
    }
}