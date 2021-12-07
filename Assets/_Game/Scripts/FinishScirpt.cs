using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScirpt : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator peanutAnimator;
    public Animator carAnimator;
    void Start()
    {
        peanutAnimator=GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //  SceneManager.LoadScene("Nut Em",LoadSceneMode.Single);
        FollowScript3.goToVan();

        peanutAnimator.SetTrigger("Car");
        carAnimator.SetTrigger("FrontOpen");
    }
}
