using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentControl : MonoBehaviour {

    public float speed;
    private bool leaving;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (leaving)
        {
            
        }
	}

    public void Leave()
    {
        GetComponent<Animation>().Play("parentLeaving");
        leaving = true;
    }
}
