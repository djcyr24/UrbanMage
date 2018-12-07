using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUpController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponentInChildren<FireBullet>().Reload();
            Destroy(transform.root.gameObject);
        }
    }
}
