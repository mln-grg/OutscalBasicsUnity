using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public BoxCollider2D crouch_resize_collider;

    private Animator anim;
    private float move;
    private bool iscrouching = false;
    private bool isfacingright = true;
    private Vector2 backupsize;
    void Start()
    {
        anim = GetComponent<Animator>();
        backupsize = crouch_resize_collider.offset;
    }

    
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        
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

        Movement();
        Animations();
    }

    private void Movement()
    {
        if (move > 0 && !isfacingright)
            Flip();
        else if (move < 0 && isfacingright)
            Flip();
    }
    private void Flip()
    {
        isfacingright = !isfacingright;
        Vector3 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale;
    }
    private void Animations()
    {
        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetBool("isCrouching", iscrouching);
    }
}
