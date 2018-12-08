using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCollisionBoxController : MonoBehaviour {

    AudioSource safeDoorAudio;

    bool inSafe = false;
    //HUD
    public Text EndGameText;
    public RestartGame theGameController;

    void Start () {

        safeDoorAudio = GetComponent<AudioSource>();
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && inSafe == false){
            safeDoorAudio.Play();
            EndGameText.text = "Safe House";
            Animator endGameAnim = EndGameText.GetComponent<Animator>();
            endGameAnim.SetTrigger("EndGame");
            theGameController.restartTheGame();
            inSafe = true;
        }
    }
}
