using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour {

    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    //public Transform shootOrigin;

    private Camera fpsCam;
    private WaitForSeconds shotDuration =new WaitForSeconds(.07f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;

    private PlayerController player;

	void Start () {
        laserLine = GetComponent<LineRenderer> ();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }
	
	void Update () {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            //StartCoroutine(ShotEffect());

            Vector3 rayOrigin = gunEnd.position; //fpsCam.ViewportToWorldPoint(player.transform.position);
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            Debug.DrawRay(rayOrigin, gunEnd.up * 100, Color.red);
            if (Physics.Raycast(rayOrigin, gunEnd.up, out hit, weaponRange))
            {
                Debug.Log(hit.transform.gameObject.name);
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }        
	}

    private IEnumerator ShotEffect ()
    {
        gunAudio.Play();

        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
