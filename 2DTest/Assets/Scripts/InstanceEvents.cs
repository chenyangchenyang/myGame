namespace DynamicLight2D
{
	using UnityEngine;
	using System.Collections;
	using UnityEngine.UI;
	using UnityEngine.SceneManagement;

	public class InstanceEvents : MonoBehaviour 
	{
		private Vector3 CameraStartPostion;

		private string GameOverStr="GameOver";

		private GUIText TextComponent;

		public GameObject[] Lights;

		public bool IsFirst = true;

		public GameObject GUI;

		public GUIText GetTextComponent()
		{
			return TextComponent;
		}

		void Start()
		{
			CameraStartPostion = transform.parent.position;

			foreach(GameObject oneLight in Lights)
			{
				DynamicLight2D.DynamicLight light2d = oneLight.GetComponent<DynamicLight2D.DynamicLight>();


				// Add listeners
				light2d.OnEnterFieldOfView += onEnter;
				light2d.OnExitFieldOfView += onExit; 
			}

			TextComponent = GUI.GetComponentInChildren<GUIText> ();
			TextComponent.color = Color.red;
			TextComponent.text = "";
		}

		void onExit(GameObject g, DynamicLight2D.DynamicLight light)
		{
			print ("onExit :"+g.name);

			if (gameObject.GetInstanceID () == g.GetInstanceID ()) 
			{
				Debug.Log("OnExit");
				//GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
		
		void onEnter(GameObject g, DynamicLight2D.DynamicLight light)
		{
			print ("onEnter :"+g.name);

			if (gameObject.GetInstanceID () == g.GetInstanceID () || transform.parent.gameObject.GetInstanceID() == g.GetInstanceID ()) 
			{
				
				//GetComponent<SpriteRenderer>().color = Color.red;
				/*
				if (!IsShootPlayer(light)) 
				{
					return;
				}*/

				TextComponent.text = GameOverStr;

				Debug.Log("OnEnter");

				Invoke ("ReStart", 1);
			}
			
		}


		bool IsShootPlayer(DynamicLight light)
		{
			Vector3 origin = light.transform.position;
			Vector3 direction= gameObject.transform.position- light.transform.position;
			direction.Normalize ();

			Ray ray = new Ray(origin, direction);

			Debug.DrawRay(origin, direction);

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 10000))
			{
				if ((hit.collider.gameObject.tag == gameObject.tag)) 
				{
					return true;
				}
			}

			return false;
		}

		void ReStart()
		{
			SceneManager.LoadScene("Demo");
		}
	}

}


