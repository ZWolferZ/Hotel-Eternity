using UnityEngine;
using UnityEngine.Serialization;

public class MovingObstacle : MonoBehaviour
{

    [FormerlySerializedAs("m_startPoint")] [SerializeField]
    private Transform mStartPoint;
    [FormerlySerializedAs("m_endPoint")] [SerializeField]
    private Transform mEndPoint;
    [FormerlySerializedAs("m_moveSpeed")] [SerializeField]
    private int mMoveSpeed;

    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = mEndPoint;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, mMoveSpeed * Time.deltaTime);
        
    }

    private void ChangeTarget()
    {
        _target = _target == mStartPoint ? mEndPoint : mStartPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingObstacleWaypoint"))
        {
            ChangeTarget();
        }
    }
  

}
