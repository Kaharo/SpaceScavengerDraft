using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BordersTrigger : MonoBehaviour {

    public GameObject borderNorth;
    public GameObject borderSouth;
    public GameObject borderEast;
    public GameObject borderWest;

    public Dir direction;

    public enum Dir {
     West,
     East,
     South,
     North,
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(direction);
       
        switch (direction)
        {
            case Dir.South:
                other.transform.position = new Vector3(0, borderNorth.transform.position.y - 1, other.transform.position.z);
                break;
            case Dir.North:
                other.transform.position = new Vector3(0, borderSouth.transform.position.y + 1, other.transform.position.z);
                break;
            case Dir.East:
                other.transform.position = new Vector3(borderWest.transform.position.x + 1, 0, other.transform.position.z);
                break;
            case Dir.West:
                other.transform.position = new Vector3(borderEast.transform.position.x - 1, 0, other.transform.position.z);
                break;
        }

    }
}
