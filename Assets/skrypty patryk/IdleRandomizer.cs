using UnityEngine;

public class IdleRandomizer: MonoBehaviour
{
    private Animator animator;
    private float randomizeInterval = 3f; // Time interval to randomize animation
    private float timer;

    void Start()
    {
        animator = GetComponent<Animator>();
        RandomizeIdleAnimation();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= randomizeInterval)
        {
            RandomizeIdleAnimation();
            timer = 0f;
        }
    }

    void RandomizeIdleAnimation()
    {
        int idleCount = 4; // Number of idle animations
        int randomIndex = Random.Range(0, idleCount);
        animator.SetInteger("IdleIndex", randomIndex);
    }
}
