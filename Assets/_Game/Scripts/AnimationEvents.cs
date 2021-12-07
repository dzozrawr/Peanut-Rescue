using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    public GameObject lilPeanutsInTheCar;
    private Animator carAnimator;
    private GameObject mamaPeanut;
    
    // Start is called before the first frame update
    void Start()
    {
        carAnimator=GameObject.FindGameObjectWithTag("CarModel").GetComponent<Animator>();
        mamaPeanut = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showSavedPeanuts()
    {
        lilPeanutsInTheCar.SetActive(true);
    }

    public void initiateDoorClosing()
    {
        carAnimator.SetTrigger("CloseDoors");
      //  carAnimator.speed = -1;
    }

    public void moveCar()
    {

        lilPeanutsInTheCar.SetActive(false);
        mamaPeanut.SetActive(false);
        carAnimator.SetTrigger("CarGo");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Nut Em", LoadSceneMode.Single);
    }
}
