using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilePickup : MonoBehaviour
{
    public GameObject pressFText;      // "Dosyalar� almak i�in F tu�una bas" yaz�s�
    public GameObject filesTakenText;  // "Dosyalar al�nd�" yaz�s�

    private bool nearFiles = false;    // Karakter dosyalar�n yan�nda m�?

    void Start()
    {
        pressFText.SetActive(false);    // Ba�lang��ta gizle
        filesTakenText.SetActive(false);// Ba�lang��ta gizle
    }

    // Karakter dosyalar�n alan�na girince tetiklenir
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bookshelf")) // Buraya dosyalar�n oldu�u objenin tag'ini yaz
        {
            pressFText.SetActive(true);    // "F'ye bas�n" yaz�s�n� g�ster
            nearFiles = true;               // Yak�nda oldu�umuzu kaydet
        }
    }

    // Karakter alan d���na ��k�nca tetiklenir
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bookshelf"))
        {
            pressFText.SetActive(false);   // Yaz�y� kapat
            filesTakenText.SetActive(false);// "Dosyalar al�nd�" yaz�s�n� da kapat
            nearFiles = false;              // Yak�nda de�iliz art�k
        }
    }

    void Update()
    {
        if (nearFiles && Input.GetKeyDown(KeyCode.F))
        {
            pressFText.SetActive(false);   // "F'ye bas�n" yaz�s�n� kapat
            filesTakenText.SetActive(true);// "Dosyalar al�nd�" yaz�s�n� a�

            // Burada dosya alma kodlar�n� da yazabilirsin
            // �rne�in inventory sistemine ekleme vs.
        }
    }
}
