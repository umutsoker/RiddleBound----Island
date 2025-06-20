using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    private bool playerInRange = false;

    public EnemySpawner enemySpawner; // Inspector'dan EnemySpawner referansını ata

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (enemySpawner != null)
            {
                enemySpawner.SpawnEnemies();
            }
            else
            {
                Debug.LogWarning("FireTrigger: EnemySpawner referansı atanmadı!");
            }
        }
    }
    void Start()
    {
        if (enemySpawner == null)
            enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
