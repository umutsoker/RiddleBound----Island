using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;

    [Header("End Game Settings")]
    [SerializeField] private float endGameDistance = 2f;

    private bool gameEnded = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameEnded) return;

        if (target != null)
        {
            agent.SetDestination(target.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);

            // Mesafe kontrolü
            if (Vector3.Distance(transform.position, target.position) <= endGameDistance)
            {
                EndGame();
            }
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        SceneManager.LoadScene("ToBeContinuedScene");
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Alternatif: Collider ile çarpışma kontrolü
    void OnCollisionEnter(Collision collision)
    {
        if (gameEnded) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            EndGame();
        }
    }
}