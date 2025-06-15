
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitRoom : MonoBehaviour
{
    public GameObject exitPromptText;  // "Dýþarý çýkmak için E tuþuna bas" yazýsý

    private bool nearExit = false;      // Kapýya yaklaþtý mý?
    private bool canShowPrompt = false; // Yazý gösterilebilir mi?
    private float enterRoomTime;        // Odaya giriþ zamaný

    void Start()
    {
        exitPromptText.SetActive(false);  // Baþlangýçta yazý kapalý
        enterRoomTime = Time.time;         // Sahne baþlama zamaný
        StartCoroutine(EnablePromptAfterDelay(5f));  // 5 saniye sonra yazý açýlabilir
    }

    IEnumerator EnablePromptAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShowPrompt = true;

        // Eðer kapýdaysa ve 5 sn geçtiyse yazýyý göster
        if (nearExit)
            exitPromptText.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExitDoor"))
        {
            nearExit = true;
            if (canShowPrompt)
            {
                exitPromptText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ExitDoor"))
        {
            nearExit = false;
            exitPromptText.SetActive(false);
        }
    }

    void Update()
    {
        if (nearExit && canShowPrompt && Input.GetKeyDown(KeyCode.E))
        {
            // Önceki sahneye geçiþ
            // Örneðin build settings'deki önceki sahne indexini kullanabilirsin
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int previousSceneIndex = Mathf.Max(currentSceneIndex - 1, 0);
            SceneManager.LoadScene(previousSceneIndex);
        }
    }
}
