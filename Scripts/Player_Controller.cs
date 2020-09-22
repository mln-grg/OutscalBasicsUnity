using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    private Animator anim;
    private float move;
    private bool isfacingright = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        
        if (move > 0 && !isfacingright)
            Flip();
        else if (move < 0 && isfacingright)
            Flip();
        
        
        Animations();
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
    }
}
