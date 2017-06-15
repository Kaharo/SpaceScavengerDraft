using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    //Player's start and end point
    [Header("Transsdorms")]
    public Transform endOrbitTarget;
    public Transform startOrbitTarget;

    [SerializeField]
    private int orbitIndex;
    public Orbits orbit;

    //Speed of player toward the end point
    public float speed = 0.1f;
    
    void Start()
    {
        transform.position = startOrbitTarget.position;
        orbitIndex = 0;
        startOrbitTarget = orbit.orbits[0].transform.Find("start").transform;
        endOrbitTarget = orbit.orbits[0].transform.Find("end").transform;
    }


    void Update()
    {
        LookAt();
        Move();
    }

    /*** rotate the object toward the mouse ***/
    void LookAt()
    {
        try
        {   
            Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 directionLook = (mouseScreenPosition - (Vector2)transform.position).normalized;
            transform.up = directionLook;
        }
        catch 
        {
            Debug.Log("Player Controller look at mouse error ");
        }
        
    }

    /*** move to target ***/
    void Move()
    {
        try
        {
           
            transform.position = Vector3.MoveTowards(transform.position, endOrbitTarget.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endOrbitTarget.position) <= 0)
            {
                changeOrbit();
            }
        }
        catch
        {
            Debug.Log("Player Controller Move (by orbit) error ");
        }

    }

    /*** changeOrbit ***/
    void changeOrbit()
    {
        try
        {
            orbitIndex++;
            if (orbitIndex > orbit.orbits.Count)
            {
                // Game Over
                orbitIndex = 0;
            }

            startOrbitTarget = orbit.orbits[orbitIndex].transform.Find("start").transform;
            endOrbitTarget = orbit.orbits[orbitIndex].transform.Find("end").transform;
            transform.position = startOrbitTarget.position;
        }
        catch
        {
            Debug.Log("Player Controller Move (by orbit) error ");
        }

    }

}
