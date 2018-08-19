using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

	public float EndX = 250;

	private Vector3 CameraStartPosition;

	private GUIText TextComponent;

	void Start () 
	{
		CameraStartPosition= transform.parent.position;
	}
	

	void Update () 
	{
		
		if (transform.position.x >= EndX) 
		{
			DynamicLight2D.InstanceEvents instanceEvents= GetComponent<DynamicLight2D.InstanceEvents> ();

			TextComponent = instanceEvents.GetTextComponent();

			TextComponent.text = "Success";

			Invoke ("ChangeScene", 1);

		}
	}

	void ChangeScene()
	{
		SceneManager.LoadScene("Success");
	}
}
