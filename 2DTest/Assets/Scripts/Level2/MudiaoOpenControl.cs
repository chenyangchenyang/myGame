using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudiaoOpenControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUpAsButton()
    {
        GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        transform.GetChild(0).gameObject.GetComponent<Scene22AlphaControl>().ChangeVisible(false);
    }
}
