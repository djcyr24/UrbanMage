using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    public float healthAmount;
    public AudioClip HealthPickUpSound;


	void Start () {
		
	}
	
	void Update () {
		
	}

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().addHealth(healthAmount);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(HealthPickUpSound, transform.position, 0.3f);
        }
    }
}
