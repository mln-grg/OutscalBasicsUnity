using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float groundcheckradius = 10f;
    public BoxCollider2D crouch_resize_collider;
    public LayerMask whatisGround;
    public Transform groundcheck;
    public float speed;
    public float jumpforce;

    
    
    
    private Rigidbody2D rb2d;
    private Animator anim;
    private float move;
    private bool iscrouching = false;
    private bool isfacingright = true;
    private Vector2 backupsize;
    private bool isGrounded;
    
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        backupsize = crouch_resize_collider.offset;
        
    }

    
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            Jump();
            
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            iscrouching = true;
            Vector2 resize = crouch_resize_collider.offset;
            resize.y = 2.457285f;
            crouch_resize_collider.offset = resize;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            iscrouching = false;
            crouch_resize_collider.offset = backupsize;
        }
        
        Movement(move*speed*Time.deltaTime);
        Animations();
        CheckSurroundings();
    }

    private void CheckSurroundings() 
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius , whatisGround);
    }
    
    private void Movement(float speed)
    {
        Vector2 movementspeed = new Vector2(speed * 10f, rb2d.velocity.y);
        if (!iscrouching)
            rb2d.velocity = movementspeed
        ;
        if (move > 0 && !isfacingright)
            Flip();
        else if (move < 0 && isfacingright)
            Flip();
    }
    private void Jump()
    {
        //if (isGrounded)
        
            rb2d.velocity = new Vector2(rb2d.position.x, jumpforce);
           
        
    }
    private void Flip()
    {
        isfacingright = !isfacingright;
        Vector3 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale;
    }
    private void OnDrawGizmos()
    {
       Gizmos.DrawWireSphere(groundcheck.position, groundcheckradius);
    }
    private void Animations()
    {
        anim.SetBool("canJump", !isGrounded);
        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetBool("isCrouching", iscrouching);
    }
}
