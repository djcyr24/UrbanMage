using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

    bool playerInRange = false;

    GameObject thePlayer;
    PlayerHealth thePlayerHealth;


	void Start () {
        nextDamage = Time.time;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        thePlayerHealth = thePlayer.GetComponent<PlayerHealth>();
	}
	
	void Update () {
        if (playerInRange) Attack();
	}

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = true;
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        if(nextDamage <= Time.time)
        {
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(thePlayer.transform);
        }
    }

    void pushBack(Transform pushObject)
    {
        Vector3 pushdirection = new Vector3(0, (pushObject.position.y - transform.position.y), 0).normalized;
        pushdirection *= pushBackForce;

        Rigidbody pushRB = pushObject.GetComponent<Rigidbody>();
        pushRB.velocity = Vector3.zero;
        pushRB.AddForce(pushdirection, ForceMode.Impulse);
    }
}
