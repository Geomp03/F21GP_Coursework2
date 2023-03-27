using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

 
    void Update()
    {
        PlayerKeyDown();
    }

    private void PlayerKeyDown()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0)
        {
            animator.SetTrigger("Right");
            Debug.Log(horizontalInput);
        }
        if (horizontalInput < 0)
        {
            animator.SetTrigger("Left");
            Debug.Log(horizontalInput);
        }

        if (horizontalInput == 0 && verticalInput == 0)
        {
            animator.SetTrigger("Down");
        }

        if (verticalInput > 0)
        {
            animator.SetTrigger("Up");
        }
        if (verticalInput < 0)
        {
            animator.SetTrigger("Down");
        }
    }
}
