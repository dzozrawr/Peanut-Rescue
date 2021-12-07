using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript3 : MonoBehaviour
{
    public Rigidbody rb;
    public float speed=5f;

    public static Transform target;

    Vector3 _followOffset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // Cache the initial offset at time of load/spawn:
        //   _followOffset = transform.position - leader.position;
        _followOffset = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        // Apply that offset to get a target position.
        Vector3 targetPosition = target.position + _followOffset;

        // Keep our y position unchanged.
        targetPosition.y = transform.position.y;

        // Smooth follow.    
        Vector3 step = (targetPosition - transform.position).normalized * speed;
        Debug.DrawLine(transform.position, transform.position + step, Color.red);
        transform.GetChild(0).LookAt(targetPosition);
        rb.AddForce(step);
    }

    public static void goToVan()
    {
    //    Debug.Log("goToVan()");
        target = GameObject.FindGameObjectWithTag("BackSeat").transform;
    }
}
