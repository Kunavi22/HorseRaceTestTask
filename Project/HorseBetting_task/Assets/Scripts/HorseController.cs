using UnityEngine;

public class HorseController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;

    float timer;
    bool isRunning = false;


    float minSpeedMult = 1.4f;
    float maxSpeedMult = 1.7f;


    float minSpeedChangeInterval = 0.3f;
    float maxSpeedChangeInterval = 2f;


    void Awake()
    {
        animator = GetComponent<Animator>();

        isRunningHash = Animator.StringToHash("IsRunning");
    }

    private void Update()
    {
        if (!isRunning) return;

        timer -= Time.deltaTime;

        // random speed change
        if (timer <= 0)
        {
            timer = Random.Range(minSpeedChangeInterval, maxSpeedChangeInterval);

            animator.speed = Random.Range(minSpeedMult, maxSpeedMult);
        }

    }


    public void StartRunning()
    {
        timer = 0;
        isRunning = true;
        animator.SetBool(isRunningHash, true);
    }



    public void StopRunning()
    {
        animator.SetBool(isRunningHash, false);
        isRunning = false;
        animator.speed = 1;
    }

}
