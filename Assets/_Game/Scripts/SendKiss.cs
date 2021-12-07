using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendKiss : MonoBehaviour
{

    private bool isKissSending=false;
    public float speed = 3f;
    private Vector3 defaultPos,destination;
    private Transform defaultTransform;

    public GameObject lipsPos;
  
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKissSending)
        {
          //  Debug.Log(transform.position);
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * speed);
            if (kissReachedDestination())
            {
                gameObject.SetActive(false);
                isKissSending = false;
            }
        }

    }

    public bool kissReachedDestination()
    {
        return Vector3.Distance(transform.position, destination) < 2f;
    }

    public void sendKissTo(Vector3 pos)
    {
        //the animation restarts automatically, whenever the gameobject is enabled again
        transform.localPosition = defaultPos + new Vector3(0,8,0);    //always start at the beginning whenever sending a kiss
       // transform.position += new Vector3(0, 16, 0);
        destination = pos;        
        isKissSending = true;
    }
}
