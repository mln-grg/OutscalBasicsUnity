using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] [Range(1, 10f)] private float speed;
    private Transform pointA;
    private Transform pointB;
    private Transform Platform;
    private Transform nextPos;

    private void Awake()
    {
        pointA = this.transform.Find("PointA");
        pointB = this.transform.Find("PointB");
        Platform = this.transform.Find("Platform").GetComponent<Transform>();
        nextPos = pointB;
    }

    private void Update()
    {
        MovingPlatform();
    }
    private void MovingPlatform()
    {
        if(Platform.position == pointB.position)
        {
            nextPos = pointA;
        }
        if(Platform.position == pointA.position)
        {
            nextPos = pointB;
        }
        Platform.position = Vector3.MoveTowards(Platform.position, nextPos.position , speed * Time.deltaTime);
    }
}
