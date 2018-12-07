using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoorController : MonoBehaviour {

    public bool resetable;
    public GameObject door;
    public bool startOpen;

    bool firstTrigger = false;
    bool open = true;
    Animator DoorAnim;
    AudioSource doorAudio;

	void Start () {
        DoorAnim = door.GetComponent<Animator>();
        doorAudio = door.GetComponent<AudioSource>();

        if(!startOpen)
        {
            open = false;
            DoorAnim.SetTrigger("DoorTrigger");
            doorAudio.Play();
        }
	}


     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !firstTrigger)
        {
            if (!resetable) firstTrigger = true;
            DoorAnim.SetTrigger("DoorTrigger");
            open = !open;
            doorAudio.Play();
        }
    }
    
	void Update () {
		
	}
}
