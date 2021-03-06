﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour {

    public float fireRate = .25f;
    public float weaponRange = 50f;
    public Transform gunEnd;

    public float gunForce;

    private Camera fpsCam;
    private WaitForSeconds shotDuration =new WaitForSeconds(.07f);
    private LineRenderer laserLine;
    private float nextFire;

	void Start () {
        laserLine = GetComponent<LineRenderer> ();
        fpsCam = GetComponentInParent<Camera>();
    }
	
	void Update () {
        try
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                Vector3 rayOrigin = gunEnd.position;
                RaycastHit hit;

                laserLine.SetPosition(0, gunEnd.position);

                Debug.DrawRay(rayOrigin, gunEnd.up * 100, Color.red);
                if (Physics.Raycast(rayOrigin, gunEnd.up, out hit, weaponRange))
                {
                    //Debug.Log(hit.transform.gameObject.name);
                    laserLine.SetPosition(1, hit.point);
                    if (hit.transform.gameObject.tag.Equals("Obstacle"))
                    //if (hit.transform.gameObject.CompareTag.Equals("Obstacle"))
                    {
                        Obstacles obstacle = hit.transform.GetComponent<Obstacles>();
                        obstacle.Force((transform.position - obstacle.transform.position).normalized * gunForce);
                    }
                }
                else
                {
                    laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                }
            }
        }
        catch
        {
           // Debug.Log("Raycast Shooting Update error ");
        }
       
	}

    private IEnumerator ShotEffect ()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
