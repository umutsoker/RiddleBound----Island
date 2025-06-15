using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilePickup : MonoBehaviour
{
    public GameObject pressFText;      // "Dosyalarý almak için F tuþuna bas" yazýsý
    public GameObject filesTakenText;  // "Dosyalar alýndý" yazýsý

    private bool nearFiles = false;    // Karakter dosyalarýn yanýnda mý?

    void Start()
    {
        pressFText.SetActive(false);    // Baþlangýçta gizle
        filesTakenText.SetActive(false);// Baþlangýçta gizle
    }

    // Karakter dosyalarýn alanýna girince tetiklenir
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bookshelf")) // Buraya dosyalarýn olduðu objenin tag'ini yaz
        {
            pressFText.SetActive(true);    // "F'ye basýn" yazýsýný göster
            nearFiles = true;               // Yakýnda olduðumuzu kaydet
        }
    }

    // Karakter alan dýþýna çýkýnca tetiklenir
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bookshelf"))
        {
            pressFText.SetActive(false);   // Yazýyý kapat
            filesTakenText.SetActive(false);// "Dosyalar alýndý" yazýsýný da kapat
            nearFiles = false;              // Yakýnda deðiliz artýk
        }
    }

    void Update()
    {
        if (nearFiles && Input.GetKeyDown(KeyCode.F))
        {
            pressFText.SetActive(false);   // "F'ye basýn" yazýsýný kapat
            filesTakenText.SetActive(true);// "Dosyalar alýndý" yazýsýný aç

            // Burada dosya alma kodlarýný da yazabilirsin
            // Örneðin inventory sistemine ekleme vs.
        }
    }
}
