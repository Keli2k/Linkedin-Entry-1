using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    public Animator animator;
    public CharacterController2D controller;
    private Rigidbody2D rb;
    private int direction;
    public float runSpeed = 40f;
    bool jump = false;
    float horizontalMove = 0f;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

    }
    public void OnLanding()
    {
        
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }
    
}
