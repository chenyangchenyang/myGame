using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float EndX = 250;

	private Vector3 CameraStartPosition;

	void Start () 
	{
		CameraStartPosition= transform.parent.position;
	}
	

	void Update () 
	{
		if (transform.position.x >= EndX) 
		{
			transform.parent.position = CameraStartPosition;
		}
	}
}
