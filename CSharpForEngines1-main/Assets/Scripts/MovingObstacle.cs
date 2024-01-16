using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    [SerializeField] Transform m_startPoint;
    [SerializeField] Transform m_endPoint;
    [SerializeField] int m_moveSpeed = 0;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = m_endPoint;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, m_moveSpeed * Time.deltaTime);
    }
 
  void ChangeTarget()
    {
        if (target == m_startPoint)
        {
            target = m_endPoint;
        }
        else 
        {
            target = m_startPoint;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingObstacleWaypoint"))
        {
            ChangeTarget();
        }
    }
  

}
