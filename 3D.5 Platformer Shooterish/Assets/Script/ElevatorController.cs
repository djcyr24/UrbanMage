using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

    public float resetTime;

    Animator elevAnim;
  //  AudioSource eleAS;

    float downTime;
    bool eleIsUp = false;
	void Start () {
        elevAnim = GetComponent<Animator>();
       // eleAS = GetComponent<AudioSource>();
	}
	
	void Update () {
        if(downTime <= Time.time && eleIsUp)
        {
            elevAnim.SetTrigger("ElavatorActivate");
            eleIsUp = false;
            //elevAs.Play();

        }

    }

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            elevAnim.SetTrigger("ElavatorActivate");
            downTime = Time.deltaTime + resetTime;
            eleIsUp = true;
            //elevAs.Play();
        }
    }
}
