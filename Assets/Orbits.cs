using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbits : MonoBehaviour {
    
    
    public List<GameObject> orbits = new List<GameObject>();

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
                orbits.Add(transform.GetChild(i).gameObject);
            }
        }
        catch
        {
            Debug.Log("Orbits asiignment error");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
