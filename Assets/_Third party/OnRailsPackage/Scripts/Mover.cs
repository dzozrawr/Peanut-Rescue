using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rail rail;
    public PlayMode mode;

    public float speed = 2.5f;
    public bool isReversed;
    public bool isLooping;
    public bool pingPong;
    public bool isPaused;

    private int currentSeg;
    private float transition;
    private bool isCompleted;

    private void Start()
    {
       // transform.rotation = rail.Orinentation(currentSeg, transition);
    }

    private void Update()
    {
       // Debug.Log("isPaused=" + isPaused);

        if (!rail)
            return;

        if (!isCompleted)
            Play(!isReversed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Encounter")
        {
          //  Debug.Log("other.gameObject.tag == Encounter");
            isPaused = true;
          //  gameObject.GetComponent<PeanutController>().transitionPeanutToTurn(other.gameObject.GetComponent<EncounterScript>().enemyPositionToLookAt.transform);
            //gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = false;
            gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Idle");
            //transform.LookAt(other.gameObject.transform.GetChild(0));
            // Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Exit")
        {
            isPaused = false;
            Destroy(other.gameObject);
        }
    }

    public void Pause()
    {
        isPaused = true;
    }
    public void unPause()
    {
        isPaused = false;
    }

    private void Play(bool forward = true)
    {
        float m = (rail.nodes[currentSeg + 1].position - rail.nodes[currentSeg].position).magnitude;
        float s = (Time.deltaTime * 1 / m) * speed;
        transition += (forward) ? s : -s;
        if (isPaused == false)
        {
            if (transition > 1)
            {
                transition = 0;
                currentSeg++;
                //transform.rotation = rail.Orinentation(currentSeg, transition);
                if (currentSeg == rail.nodes.Length - 1)
                {
                    if (isLooping)
                    {
                        if (pingPong)
                        {
                            transition = 1;
                            currentSeg = rail.nodes.Length - 2;
                            isReversed = !isReversed;
                        }
                        else
                        {
                            currentSeg = 0;
                        }
                    }
                    else
                    {
                        isCompleted = true;
                        return;
                    }
                }
            }
            else if (transition < 0)
            {
                transition = 1;
                currentSeg--;
                if (currentSeg == -1)
                {
                    if (isLooping)
                    {
                        if (pingPong)
                        {
                            transition = 0;
                            currentSeg = 0;
                            isReversed = !isReversed;

                            //my code
                            transform.Rotate(Vector3.up,180);
                          //  gameObject.transform.rotation.eulerAngles.y += 180;
                        }
                        else
                        {
                            currentSeg = rail.nodes.Length - 2;
                        }
                    }
                    else
                    {
                        isCompleted = true;
                        return;
                    }
                }
            }

            transform.position = rail.positionOnRail(currentSeg, transition, mode);
            transform.rotation = rail.Orinentation(currentSeg, transition);
        }
      //  transform.rotation = rail.Orinentation(currentSeg, transition);
    }
}
