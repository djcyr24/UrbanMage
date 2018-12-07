using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickUpController : MonoBehaviour {

    public int WhichWeapon;
    public AudioClip pickupClip;
    

	void Start () {
		
	}
	

	void Update () {
		
	}

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<InventoryManager>().ActivateWeapon(WhichWeapon);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
        }
    }
}
