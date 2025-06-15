using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBeContinued : MonoBehaviour
{
    void Start()
    {
        // Fareyi etkinleþtir
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 5 saniye sonra otomatik olarak ada sahnesine dön
        Invoke("ReturnToAdaScene", 5f);
    }

    void Update()
    {

        // Herhangi bir tuþa basýldýðýnda hemen ada sahnesine dön
        if (Input.anyKeyDown)
        {
            ReturnToAdaScene();
        }
    }

    private void ReturnToAdaScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}