using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeRabbityApparence : MonoBehaviour {

    public Material[] rabbitMaterials;

	void Start () {
        SkinnedMeshRenderer myRenderer = GetComponent<SkinnedMeshRenderer>();
        myRenderer.material = rabbitMaterials[Random.Range(0, rabbitMaterials.Length)];
	}
	
	void Update () {
		
	}
}
