﻿using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour {
    private Transform target;

    //Sorts all the variables in the Unity Inspector
    [Header("Attributes")]

    //turret range
    public float range = 15f;
    //1 bullet per sec
    public float fireRate = 1f;
    private float fireCountdown = 0;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform ModelToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //stores the shortest distance to an enemy
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

     void Update()
    {
        if(target == null)
        {
            return;
        }

        //Rotates turret dir/ target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(ModelToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        ModelToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown = fireCountdown - Time.deltaTime;

    }

    void Shoot()
    {
        //Grabs the bullet script so that we can pass target coords to it
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        //Makes sure its not null, so we can pass the coords to the bullet script
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    //Only displays the range of the turret if the turret is selected
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
