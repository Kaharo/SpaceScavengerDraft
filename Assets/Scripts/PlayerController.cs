using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [Header("Transforms")]
    [SerializeField]
    private int orbitIndex;
    public Orbits orbits;
    private Orbit currentOrbit;

    //Speed of player toward the end point
    public float speed = 0.1f;

    public ScoreManager scoreManager;
    public UIManager uiManager;
    
    
    void Start()
    {
        orbitIndex = 0;
        currentOrbit = orbits.orbits[0];
        transform.position = currentOrbit.startTarget.position;
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
           
            transform.position = Vector3.MoveTowards(transform.position, currentOrbit.endTarget.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentOrbit.endTarget.position) <= 0)
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
            if (orbitIndex > orbits.orbits.Count)
            {
                // Game Over
                orbitIndex = 0;
            }
            
            currentOrbit = orbits.orbits[orbitIndex];
            transform.position = currentOrbit.startTarget.position;
        }
        catch
        {
            Debug.Log("Player Controller Move (by orbit) error ");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
                scoreManager.AddScore();
                if (scoreManager.score == 3)
                {
                    uiManager.SetActive(true);
                }
            }
        }
        catch
        {
            Debug.Log("On collision Enter error");
        }
    }

}
