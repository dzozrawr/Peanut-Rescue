using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeanutController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 enemyPosition;
    [SerializeField] private float transitionSpeed;
    private Transform currentView, oldTransform;
    // Start is called before the first frame update
    void Start()
    {
        currentView = transform;
    }

    private void Update()
    {
        Vector3 direction = currentView.position - transform.position;

        // Quaternion toRotation = Quaternion.LookRotation(transform.forward, direction);

        Quaternion toRotation = Quaternion.LookRotation(direction); //this shouldnt be called every update, optimize code
        toRotation.eulerAngles = new Vector3(0, toRotation.eulerAngles.y, 0);//rotate only around y
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, transitionSpeed * Time.deltaTime);


        /*        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
            );
                transform.eulerAngles = currentAngle;
        */
    }

    // Update is called once per frame


    public bool transitionFinished()
    {
        //Debug.Log();

        Vector3 direction = currentView.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction); //this shouldnt be called every update, optimize code
        toRotation.eulerAngles = new Vector3(0, toRotation.eulerAngles.y, 0);//rotate only around y
        return Mathf.Abs(transform.rotation.eulerAngles.y - toRotation.eulerAngles.y) < 1f;
    }

    public void transitionPeanutToTurn(Transform enemyPosition)
    {
        oldTransform = currentView;
        currentView = enemyPosition;
    }

    public void turnHeadToDefault()
    {
        currentView = oldTransform;
    }
}
