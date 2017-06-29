using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    [SerializeField]
    private Transform direction;
    private Rigidbody rigidbody;
    public float speed;

	void Start () {
        //initial speed, can be changed in Inspector
        //speed = 25f;
        direction = transform.GetChild(0);
        rigidbody = GetComponent<Rigidbody>();

        Vector2 dir = new Vector2(direction.position.x, direction.position.y);
        //rigidbody.AddForce(dir.normalized * speed);
        Force(dir.normalized * speed);

    }

    public void Force(Vector3 dir)
    {
        rigidbody.AddForce(dir);
    }

    

}
