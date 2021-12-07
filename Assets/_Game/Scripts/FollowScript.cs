using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    private Transform momPeanutTransform;
    private Transform leader;
    public float speed = 0.1f;
    private CharacterController cc;

    Vector3 _followOffset;

    void Start()
    {
        momPeanutTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // Cache the initial offset at time of load/spawn:
        //   _followOffset = transform.position - leader.position;
        _followOffset = new Vector3(0, 0, 0);
        leader = momPeanutTransform;
        cc= gameObject.GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        // Apply that offset to get a target position.
        Vector3 targetPosition = leader.position + _followOffset;

        // Keep our y position unchanged.
        targetPosition.y = transform.position.y;

        // Smooth follow.    
        Vector3 step= (targetPosition - transform.position).normalized * speed*Time.deltaTime;
        cc.Move(step);
      //  transform.position += (targetPosition - transform.position) * speed;
    }
}
