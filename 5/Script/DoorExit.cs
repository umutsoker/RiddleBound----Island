using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour
{
    [Tooltip("Dýþ sahnedeki karakterin doðacaðý noktanýn koordinatlarý")]
    public Vector3 outsideSpawnPosition;

    [Tooltip("Dýþ sahnedeki karakterin baþlangýç rotasyonu")]
    public Vector3 outsideSpawnRotationEuler;

    // Kapýdan karakter geçerse
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // SpawnManager singleton'ýndan spawn pozisyonunu ayarla
            if (SpawnManager.Instance != null)
            {
                // Quaternion.Euler ile Euler açýlarýný rotasyona çeviriyoruz
                Quaternion spawnRot = Quaternion.Euler(outsideSpawnRotationEuler);
                SpawnManager.Instance.SetSpawnPosition(outsideSpawnPosition, spawnRot);
            }
            else
            {
                Debug.LogError("SpawnManager bulunamadý!");
            }

            // Yeni sahneye geçiþ (dýþ mekan sahnenizin adýný yazýn)
            SceneManager.LoadScene("DisMekanSahneAdi");
        }
    }
}

