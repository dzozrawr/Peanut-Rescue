using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabtale.TTPlugins;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;
    public PeanutController pC;

    private void Awake()
    {
        TTPCore.Setup();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pC.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Kiss");
            

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.CompareTag("Enemy"))
                {
                    
                    hitObject.GetComponent<HealthScript>().doKissDmg();

                    pC.transform.GetChild(2).gameObject.SetActive(false);   //disables it just in  case it was playing already
                    pC.transform.GetChild(2).gameObject.SetActive(true);
                    pC.transform.GetChild(2).gameObject.GetComponent<SendKiss>().sendKissTo(hit.point);

                }
               
            }
        }
    }
}
