using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour {

    public float damage;
    public float knockBack;
    public float knockBackRadius;
    public float meleeRate;

    float nextMelee;

    int shootableMask;

    Animator myAnim;
    PlayerController myPC;


	void Start () {
        shootableMask = LayerMask.GetMask("Shootable");
        myAnim = transform.root.GetComponent<Animator>();
        myPC = transform.root.GetComponent<PlayerController>();
        nextMelee = 0f;
	}
	
	void FixedUpdate () {
        float melee = Input.GetAxis("Fire2");

        if(melee > 0 && nextMelee < Time.time)
        {
            myAnim.SetTrigger("MeeleeBasic");
            nextMelee = Time.time + meleeRate;

            //do damage
            Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);
        }
		
	}
}
