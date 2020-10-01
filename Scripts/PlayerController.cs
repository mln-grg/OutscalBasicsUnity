using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerinput;
    public LayerMask whatisGround;
    

    [Range(0,1f)] [SerializeField] private float groundcheckradius = 0.2f;
    [Range(0,1000f)] [SerializeField] private float speed = 0f;
    [Range(0,1000f)] [SerializeField]private float jumpforce = 0f;


    private BoxCollider2D crouch_resize_collider;
    private Transform groundcheck;
    private Rigidbody2D rb2d;
    private Animator anim;
    private float move;
    private bool iscrouching = false;
    private bool isfacingright = true;
    private Vector2 backupsize;
    private bool isGrounded;
    private float score=0;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        crouch_resize_collider = GetComponent<BoxCollider2D>();
        playerinput = GetComponent<PlayerInput>();
        groundcheck = this.transform.Find("groundcheck");
    }

    private void Start()
    {
        backupsize = crouch_resize_collider.offset;
    }

    void Update()
    {
        move = playerinput.returnHorizontalInput();
        if (playerinput.returnVerticalInput() && isGrounded)
        {

            Jump();

        }
        if (playerinput.returnCrouchInput())
        {
            iscrouching = true;
            Crouch();
        }
        else if (playerinput.returnCrouchInput() == false)
        {
            iscrouching = false;
            Crouch();
            
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
        rb2d.velocity = iscrouching == false ? movementspeed : Vector2.zero;
        
        if (move > 0 && !isfacingright)
            Flip();
        else if (move < 0 && isfacingright)
            Flip();
    }
    private void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.position.x, jumpforce);                 
    }
    private void Crouch()
    {
        if (iscrouching)
        {
            Vector2 resize = crouch_resize_collider.offset;
            resize.y = 2.457285f;
            crouch_resize_collider.offset = resize;
        }
        else
        {
            crouch_resize_collider.offset = backupsize;
        }
    }
    private void Flip()
    {
        isfacingright = !isfacingright;
        Vector3 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale;
    }

    public void PickUpKey()
    {
        
    }
    private void Animations()
    {
        anim.SetBool("canJump", !isGrounded);
        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetBool("isCrouching", iscrouching);
    }
}
