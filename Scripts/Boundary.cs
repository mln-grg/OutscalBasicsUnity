using UnityEngine;

public class Boundary : MonoBehaviour
{
    public PlayerHealth ph;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            ph.TakeDamage(3);
        }
    }
}
