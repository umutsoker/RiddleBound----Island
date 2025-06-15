using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;
    public Transform player;
    [Tooltip("Varsayýlan spawn pozisyonu (örneðin kapýnýn dýþý)")]
    [SerializeField] private GameObject toBeContinuedUI;
    public Vector3 defaultSpawnPosition = new Vector3(0, 2, 0); // Ayarla
    public Quaternion defaultSpawnRotation = Quaternion.identity;

    private void Awake()
    {
        // UI objesini baþlangýçta gizle
        if (toBeContinuedUI != null)
            toBeContinuedUI.SetActive(false);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Varsayýlan pozisyona ayarla
            spawnPosition = defaultSpawnPosition;
            spawnRotation = defaultSpawnRotation;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded1(Scene scene, LoadSceneMode mode)
    {
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
            foundPlayer.transform.position = spawnPosition;
            foundPlayer.transform.rotation = spawnRotation;
        }
        else
        {
            Debug.LogWarning("SpawnManager: Player bulunamadý!");
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = spawnPosition;
            player.transform.rotation = spawnRotation;
        }
        else
        {
            Debug.LogWarning("SpawnManager: Player bulunamadý!");
        }
    }




    public void SetSpawnPosition(Vector3 position, Quaternion rotation)
    {
        spawnPosition = position;
        spawnRotation = rotation;
    }
}
