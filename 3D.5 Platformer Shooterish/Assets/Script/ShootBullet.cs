﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

    public float range = 10f;
    public float damage = 5f;

    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunLine;

	void Start () {
        shootableMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        gunLine.SetPosition(0, transform.position);

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            if(shootHit.collider.tag == "Enemy")
            {
                EnemyHealth theEnemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                if(theEnemyHealth != null)
                {
                    theEnemyHealth.addDamage(damage);
                    theEnemyHealth.damageFX(shootHit.point, -shootRay.direction);
                }
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
	}
	
	
	void Update () {
		
	}
}
