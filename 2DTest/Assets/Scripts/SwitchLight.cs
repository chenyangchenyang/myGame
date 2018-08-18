using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour {

	public GameObject Light2D;

	private Vector3 Position;

	private float UpDistance = 100.0f;

	private string switchTag="switch";

	// Use this for initialization
	void Start () 
	{
		Position = Light2D.transform.position;

		GameObject gameObject= transform.parent.Find("2DLight").gameObject;

		Light2D= gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!Input.GetMouseButtonDown (0)) 
		{
			return;
		}

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); 

		if(hit.collider != null)
		{
			if(hit.collider.gameObject== this.gameObject)
			{
				if (Light2D.transform.position.y < 10) 
				{
					Position = Light2D.transform.position;

					Vector3 newPos = Position;
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
}
