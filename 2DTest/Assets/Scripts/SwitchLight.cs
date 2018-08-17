using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour {

	public GameObject Light2D;

	private Vector3 Position;

	private float UpDistance = 100.0f;
	// Use this for initialization
	void Start () 
	{
		Position = Light2D.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); 

		if(hit.collider != null)
		{ 
			Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);


			if (Light2D.transform.position.y < 10) 
			{
				Position = Light2D.transform.position;

				Vector3 newPos= Position;
				newPos.y = UpDistance;
				Light2D.transform.position = newPos;
			} 
			else 
			{
				Light2D.transform.position = Position;
			}
		}
	}
}
