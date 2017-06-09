using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public Transform endOrbitTarget;
    public Transform startOrbitTarget;

    public float speed = 0.1f;

    private Vector3 target;



    void Start()
    {
        transform.position = startOrbitTarget.position;
    }


    void Update()
    {
        
        SatMovement();


    }

    void SatMovement()
    {
        try
        {
            //rotate the object toward the mouse
            Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 directionLook = (mouseScreenPosition - (Vector2)transform.position).normalized;
            transform.up = directionLook;

            //move to target
            transform.position = Vector3.MoveTowards(transform.position, endOrbitTarget.position, speed * Time.deltaTime);
        }
        catch 
        {
            Debug.Log("Game Object Physics error (Player movement ) ");
        }
        
    }
}
