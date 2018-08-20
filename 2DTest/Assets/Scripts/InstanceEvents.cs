namespace DynamicLight2D
{
	using UnityEngine;
	using System.Collections;
	using UnityEngine.UI;
	using UnityEngine.SceneManagement;

	public class InstanceEvents : MonoBehaviour 
	{
		public GameObject GUI;

		public GameObject LightRoot;

		private Vector3 CameraStartPostion;

		private string GameOverStr="GameOver";

		private string Scene1Name="Demo";
		private string Scene2Name="Demo2";

		private GUIText TextComponent;

		public GUIText GetTextComponent()
		{
			return TextComponent;
		}

		void Start()
		{
			DynamicLight2D.DynamicLight[] Lights= LightRoot.GetComponentsInChildren<DynamicLight2D.DynamicLight> ();

			CameraStartPostion = transform.parent.position;

			foreach(DynamicLight2D.DynamicLight light in Lights)
			{
				// Add listeners
				light.OnEnterFieldOfView += onEnter;
				light.OnExitFieldOfView += onExit; 
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
			//print ("onEnter :"+g.name);

			//|| transform.parent.gameObject.GetInstanceID() == g.GetInstanceID ()
			if (gameObject.GetInstanceID () == g.GetInstanceID () ) 
			{
				
				//GetComponent<SpriteRenderer>().color = Color.red;
				/*
				if (!IsShootPlayer(light)) 
				{
					return;
				}*/

				TextComponent.text = GameOverStr;

				Debug.Log("OnEnter");

				string sceneName= SceneManager.GetActiveScene ().name;
				if (Scene1Name == sceneName) 
				{
					
				}
				else if(Scene2Name == sceneName)
				{
					
				}

				ReStart ();
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
			SceneManager.LoadScene(Scene2Name);
		}

		void ReZero()
		{
			TextComponent.text = "";

			transform.parent.position= CameraStartPostion;
		}
	}

}


