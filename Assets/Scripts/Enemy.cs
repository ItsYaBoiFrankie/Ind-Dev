using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    //Current waypoint pursuing
    private int wavepointIndex = 0;

    void Start()
    {
        //start with Waypoint 0
        target = Waypoints.wp[0];
    }

    void Update()
    {
        //Distance from current position to destination
        Vector3 dir = target.position - transform.position;
        //Keeps the obj speed constant.
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.wp.Length - 1)
        {
            Destroy(gameObject);
            //Return because computer can run rest of code before obj is completely destroyed
            return;
        }
        wavepointIndex++;
        target = Waypoints.wp[wavepointIndex];
    }
}
