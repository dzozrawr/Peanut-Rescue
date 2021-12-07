using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    int HP = 100;
    private GameObject encounterManager=null;    
    public GameObject peanutToDrop;
    public ParticleSystem heartParticles;

    public Mover mover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doKissDmg()
    {
        HP -= 25;
       
        if (HP <= 0)
        {
            encounterManager.GetComponent<EncounterScript>().decEnemyCount();
            
            peanutToDrop.GetComponent<Rigidbody>().isKinematic = false;
         
            gameObject.GetComponent<Animator>().SetTrigger("Hit");
            gameObject.GetComponent<BoxCollider>().enabled = false;
            mover.Pause();
            //drop the peanut and tehn instantiate another peanut
            /*            Instantiate(lilPeanut,gameObject.transform.position + Vector3.up, Quaternion.identity);
                        Instantiate(lilPeanut, gameObject.transform.position+Vector3.right*2f + Vector3.up, Quaternion.identity);
                        Instantiate(lilPeanut, gameObject.transform.position + Vector3.left*2f + Vector3.up, Quaternion.identity);*/
            // Destroy(gameObject);
        }
    }

    public void setEncounterManager(GameObject eM)
    {
        encounterManager = eM;
    }

    public void playHeartParticles()
    {
        heartParticles.Play();
    }
}
