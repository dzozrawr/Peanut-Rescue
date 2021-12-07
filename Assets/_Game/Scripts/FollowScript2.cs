using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript2 : MonoBehaviour
{
    public Rigidbody rb;
    public float speed=5f;

    private Transform momPeanutTransform;
    private Transform leader;

    Vector3 _followOffset;
    // Start is called before the first frame update
    void Start()
    {
        momPeanutTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // Cache the initial offset at time of load/spawn:
        //   _followOffset = transform.position - leader.position;
        _followOffset = new Vector3(0, 0, 0);
        leader = momPeanutTransform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Apply that offset to get a target position.
        Vector3 targetPosition = leader.position + _followOffset;

        // Keep our y position unchanged.
        targetPosition.y = transform.position.y;

        // Smooth follow.    
        Vector3 step = (targetPosition - transform.position).normalized * speed * Time.deltaTime;
        rb.MovePosition(step);
    }
}
