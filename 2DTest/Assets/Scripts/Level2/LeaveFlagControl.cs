using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFlagControl : MonoBehaviour {

    private GameObject player;
    private GameObject parent;
    private bool left = false;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("S2Oldman");
        parent = GameObject.Find("Girl");
	}
	
	// Update is called once per frame
	void Update () {
		if (!left && Vector3.Distance(player.transform.position, transform.position) < 0.5)
        {
            parent.GetComponent<Animation>().Play("parentLeaving");
        }
	}
}
