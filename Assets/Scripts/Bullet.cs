using UnityEngine;

public class Bullet : MonoBehaviour {

    //Gives target by passing target found from turret to bullet to chase
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update ()
    {
		//if the target leaves the level, destroy the bullet object
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Find the direction the bullet needs to point in order to look at target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //hit detection. magnitude is distance to target, distance to frame is coords.
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        //otherwise keep moving towards
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy (effectIns, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
