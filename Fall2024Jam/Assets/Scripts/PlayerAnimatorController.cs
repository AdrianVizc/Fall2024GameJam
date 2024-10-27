using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey("w"))
        {
            animator.SetBool("GoingUp", true);
        }
        if (!Input.GetKey("w"))
        {
            animator.SetBool("GoingUp", false);
        }
        if (Input.GetKey("d"))
        {
            animator.SetBool("GoingRight", true);
        }
        if (!Input.GetKey("d"))
        {
            animator.SetBool("GoingRight", false);
        }
        if (Input.GetKey("a"))
        {
            animator.SetBool("GoingLeft", true);
        }
        if (!Input.GetKey("a"))
        {
            animator.SetBool("GoingLeft", false);
        }
        if (Input.GetKey("a") && (Input.GetKey("d")))
        {
            animator.SetBool("GoingLeft", false);
            animator.SetBool("GoingRight", false);
        }
        if (Input.GetKey("s"))
        {
            animator.SetBool("GoingDown", true);
        }
        if (!Input.GetKey("s"))
        {
            animator.SetBool("GoingDown", false);
        }
    }
}
