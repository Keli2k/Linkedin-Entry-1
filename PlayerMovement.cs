using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    public Animator animator;
    public CharacterController2D controller;
    private float dashTime;
    public float dashSpeed;
    public float startDashTime;
    private Rigidbody2D rb;
    private int direction;
    public float runSpeed = 40f;
    bool jump = false;
    float horizontalMove = 0f;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
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
        if(direction == 0)
        {
            if(Input.GetKey(KeyCode.D))
            {
                direction = 1;
            }
            else if(Input.GetKey(KeyCode.A))
            {
                direction = 2;
            }
        }

        else
        {
            if(dashTime <= 0 )
            {
                direction = 0;
                rb.velocity = Vector2.zero;
                dashTime = startDashTime;
            }
            if(direction == 1 && Input.GetMouseButton(1) && dashTime <= 0)
            {
                rb.velocity = Vector2.right * dashSpeed;
                direction = 0;
                
            }
            if (direction == 2 && Input.GetMouseButton(1) && dashTime <= 0)
            { 
                rb.velocity = Vector2.left * dashSpeed;
                direction = 0;
                
            }
            dashTime -= Time.deltaTime;
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
