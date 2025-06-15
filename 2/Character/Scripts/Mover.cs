using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private float walkSpeed = 1.5f;
    private float runSpeed = 5.6f;
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    [SerializeField] float turnSpeed;

    private NavMeshAgent agent;
    private Animator animator;
    private float currentSpeed = 0f;
    private float targetSpeed = 0f;

    // 🦶 Ses değişkenleri
    private AudioSource footstepAudio;
    [SerializeField] private AudioClip footstepClip; // Unity'den atayabilirsin

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // 🎵 AudioSource bileşeni bul
        footstepAudio = GetComponent<AudioSource>();
        if (footstepAudio == null)
        {
            footstepAudio = gameObject.AddComponent<AudioSource>(); // AudioSource yoksa ekle
        }
        footstepAudio.clip = footstepClip;
        footstepAudio.loop = false;
        footstepAudio.playOnAwake = false;
    }

    void Update()
    {
        HandleMovement();
        UpdateAnimator();

        // 🦶 Ses çalma kontrolü (Hareket varsa çalsın)
        if (currentSpeed > 0.1f && !footstepAudio.isPlaying)
        {
            footstepAudio.Play();
        }
        else if (currentSpeed <= 0.1f && footstepAudio.isPlaying)
        {
            footstepAudio.Stop();
        }
    }

    private void HandleMovement()
    {
        float moveZ = Input.GetAxisRaw("Vertical");
        // moveZ = moveZ == -1 ? 0 : moveZ; // Geri engelini kaldırıyoruz

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (moveZ != 0)
        {
            if (moveZ < 0)
            {
                targetSpeed = walkSpeed * 0.5f; // Geri yürüyüş yavaş
            }
            else
            {
                targetSpeed = isRunning ? runSpeed : walkSpeed;
            }
        }
        else
        {
            targetSpeed = 0f;
        }

        if (!isRunning || moveZ < 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, deceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        }

        agent.speed = currentSpeed;
        agent.velocity = transform.forward * currentSpeed * Mathf.Sign(moveZ);

        float rotateY = Input.GetAxisRaw("Horizontal");
        if (rotateY != 0)
        {
            float targetAngle = rotateY * turnSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * targetAngle);
        }
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("forwardSpeed", Mathf.Abs(currentSpeed));
    }
}
