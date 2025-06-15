using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount = 3;
    public Transform[] spawnPoints;
    public Transform player;

    private bool hasSpawned = false;

    private string adaSceneName = "AdaScene"; // Ada sahnesinin adı

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Player referansını güncelle
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
        else
            Debug.LogWarning("EnemySpawner: Player bulunamadı!");

        // Spawn durumunu resetle
        hasSpawned = false;

        // Eğer şu an yüklenen sahne ada sahnesiyse düşmanları spawn et
        if (scene.name == adaSceneName)
        {
            Debug.Log("Ada sahnesi yüklendi, düşmanlar spawn ediliyor...");
            SpawnEnemies();
        }
        else
        {
            Debug.Log(scene.name + " yüklendi, spawn yapılmayacak.");
        }
    }

    public void SpawnEnemies()
    {
        if (hasSpawned) return;
        hasSpawned = true;

        if (enemyPrefab == null || spawnPoints == null || spawnPoints.Length == 0 || player == null)
        {
            Debug.LogError("EnemySpawner: Prefab, spawn points veya player eksik!");
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            if (spawnPoint == null)
            {
                Debug.LogWarning("Spawn point null, atlanıyor.");
                continue;
            }

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            EnemyAI ai = enemy.GetComponent<EnemyAI>();
            if (ai != null)
                ai.SetTarget(player);
        }

        Debug.Log("EnemySpawner: Düşmanlar spawn edildi.");
    }
}
