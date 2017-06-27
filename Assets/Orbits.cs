using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbits : MonoBehaviour {
    
    
    public List<Orbit> orbits = new List<Orbit>();

    // Use this for initialization
    void Start () {
        initOrbits();
    }

    void initOrbits()
    {
        try
        {
            int numberofChilds = transform.childCount;
            for (int i = 0; i < numberofChilds; i++)
            {
                orbits.Add(transform.GetChild(i).GetComponent<Orbit>());
            }
        }
        catch
        {
            Debug.Log("Orbits asiignment error");
        }
    }
	

}
