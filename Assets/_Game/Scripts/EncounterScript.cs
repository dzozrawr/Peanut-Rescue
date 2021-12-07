using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterScript : MonoBehaviour
{
    public GameObject enemyPositionToLookAt;
    public GameObject[] enemyList;
    private int enemyCount;

    private PeanutController peanutC;

    private int peanutShellsToBreak;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = enemyList.Length;
        peanutShellsToBreak = enemyCount;

        for (int i = 0; i < enemyCount; i++)
        {
            enemyList[i].GetComponent<HealthScript>().setEncounterManager(gameObject);
        }

        peanutC = GameObject.FindGameObjectWithTag("Player").GetComponent<PeanutController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (peanutShellsToBreak == 0)
        {
           // Debug.Log("if (peanutShellsToBreak == 0)");
          //  if (peanutC.transitionFinished())
          //  {
                peanutC.GetComponent<Mover>().unPause();
                //peanutC.gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = true;
                peanutC.gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Running");
            Destroy(gameObject); //or maybe not destroy, but cause it to be innefective
         //   }
        }
    }

    public void decEnemyCount()
    {
        enemyCount--;
        if (enemyCount == 0)
        {
          //  peanutC.turnHeadToDefault(); //rotate head back
          //  peanutC.GetComponent<Mover>().unPause();     //start rail again


        }
    }

    public void decPeanutShellsToBreak()
    {
       
        peanutShellsToBreak--;
       // Debug.Log("decPeanutShellsToBreak()= " + peanutShellsToBreak);
    }
}
