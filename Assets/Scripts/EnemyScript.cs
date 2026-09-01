using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject target;
    public float speed;
    public Boolean killed = false;
    private bool hasLineOfSight = false;
    public float sightDistance;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (hasLineOfSight && killed == false && distance < sightDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        distance = Vector3.Distance(target.transform.position, transform.position);
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, target.transform.position - transform.position);
        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("Player"))
            {
                hasLineOfSight = ray.collider.CompareTag("Player");
            }
            if (hasLineOfSight)
            {
                Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red);
            }
        }
    }
}
