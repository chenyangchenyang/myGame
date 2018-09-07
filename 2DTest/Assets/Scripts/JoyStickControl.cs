using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickControl : MonoBehaviour {

    public bool ToRight = true;
    GameObject body;
	// Use this for initialization
	void Start () {
        body = GameObject.Find("Body");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMove(Vector2 dir)
    {
        if ((dir.x > 0) != ToRight)
        {
            var scale = body.transform.localScale;
            scale.x *= -1;
            body.transform.localScale = scale;
        }
        ToRight = (dir.x > 0);
        GetComponent<PlayerControl>().dir = dir;
        GetComponent<PlayerControl>().move = true;
        GetComponent<Animator>().SetBool("Walking", true);
    }

    public void OnMoveEnd()
    {
        GetComponent<PlayerControl>().dir = Vector2.zero;
        GetComponent<PlayerControl>().move = false;
        GetComponent<Animator>().SetBool("Walking", false);
    }
}
