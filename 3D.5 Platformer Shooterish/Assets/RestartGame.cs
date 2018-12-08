using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour {

    public float restartTime;
    bool resetNow = false;
    float resetTime;

	void Start () {
		
	}
	
	void Update () {
        if(resetNow && resetTime <= Time.time)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
		
	}

    public void restartTheGame()
    {
        resetNow = true;
        resetTime = restartTime + Time.time;
    }
}
