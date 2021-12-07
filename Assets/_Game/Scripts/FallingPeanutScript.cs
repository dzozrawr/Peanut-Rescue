using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPeanutScript : MonoBehaviour
{
    public GameObject lilPeanut;
    public GameObject lilLipstick;

    public EncounterScript encounterScript;

    private bool collidedOnce = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity* 3 * rb.mass);
        // rigidbody.AddForce(Physics.gravity * rigidbody.mass);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Floor"))
        {
            if (!collidedOnce)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Break");

                encounterScript.decPeanutShellsToBreak();
                float chance = Random.Range(0f, 1f);
                if (chance < 0.5f)
                {
                    Instantiate(lilPeanut, gameObject.transform.position + Vector3.right * 2f + Vector3.up, Quaternion.identity);
                    Instantiate(lilPeanut, gameObject.transform.position + Vector3.left * 2f + Vector3.up, Quaternion.identity);
                }
                else
                { 
                    Instantiate(lilLipstick, gameObject.transform.position, Quaternion.identity);
                }
                
                //   Instantiate(lilPeanut, gameObject.transform.position + Vector3.up, Quaternion.identity);


                collidedOnce = true;
                GetComponent<MeshCollider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
            }
            // Debug.Log("Instantiate 2 peanuts");
        }
    }
}
