
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float speed = 5f;

    private Transform target;
    private int waypoint = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypoint >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
        }

        else
        {
            waypoint++;
            target = Waypoints.waypoints[waypoint];
        }
        
    }
}
