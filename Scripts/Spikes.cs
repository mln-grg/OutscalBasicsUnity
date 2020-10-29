using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField][Range(0,3)] private int damage;
    [SerializeField][Range(0,20)] private float knockbackforce_x;
    [SerializeField][Range(0,20)] private float knockbackforce_y;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerHealth playerhealth = collision.gameObject.GetComponent<PlayerHealth>();
            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
            Vector2 knockbackforce = new Vector2(knockbackforce_x, knockbackforce_y);
            playercontroller.Knockback(knockbackforce);
            playerhealth.TakeDamage(damage);
        }
    }
}
