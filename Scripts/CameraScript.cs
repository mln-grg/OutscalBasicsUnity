using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform target;
    [SerializeField] [Range(0, 5)] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        target = GameObject.Find("Player 1").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }

}
 