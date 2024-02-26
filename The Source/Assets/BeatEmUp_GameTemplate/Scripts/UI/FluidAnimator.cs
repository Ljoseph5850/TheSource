using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidAnimator : MonoBehaviour
{
    private Animator animator;
    public static bool fluidEmpty = false;
    private float timer = 0f;
    private float timerDuration = 2f;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if fluidEmpty is true and play the animation
        if (fluidEmpty)
        {
            animator.SetBool("FluidEmpty", true);

            // Start the timer
            timer += Time.deltaTime;

            // Check if the timer has reached the specified duration
            if (timer >= timerDuration)
            {
                // Reset the fluidEmpty variable and timer
                fluidEmpty = false;
                timer = 0f;

                // Stop the animation
                animator.SetBool("FluidEmpty", false);
            }
        }
    }

    // You can call this method to trigger the animation
    public static void TriggerFluidEmptyAnimation()
    {
        fluidEmpty = true;
    }
}
