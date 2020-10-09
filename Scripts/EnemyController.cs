using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(0, 10f)] [SerializeField] private float speed;
    [Range(0, 10f)] [SerializeField] private float distance;

    private Transform groundDetection;
    private Animator animator;

    private bool movingRight = true;
    private bool iswalking = false;
    private bool isrunning = false;
    private void Awake()
    {
        groundDetection = this.transform.Find("GroundDetection");
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        
        Patroling();
        Animations();
    }
    private void Patroling()
    {
        //iswalking = true;
        isrunning = true;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    private void Animations()
    {
        animator.SetBool("isWalking", iswalking);
        animator.SetBool("isRunning", isrunning);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerHealth playerhealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerhealth.TakeDamage();
        }
    }
}
