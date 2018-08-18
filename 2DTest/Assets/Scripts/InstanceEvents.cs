namespace DynamicLight2D
{
	using UnityEngine;
	using System.Collections;
	
	public class InstanceEvents : MonoBehaviour {
		
		DynamicLight2D.DynamicLight light2d;

		Vector3 CameraStartPostion;

		public GameObject[] Lights;
		//IEnumerator Start () 
		void Start1()
		{
			// Find and set 2DLight Object //
			light2d = GameObject.Find("Light/2DLight").GetComponent<DynamicLight2D.DynamicLight>();

			CameraStartPostion = transform.parent.position;
			// Add listeners
			
			light2d.OnEnterFieldOfView += onEnter;
			light2d.OnExitFieldOfView += onExit; 

			//yield return new WaitForEndOfFrame();
			//StartCoroutine(loop());
			
		}
		

		void Start()
		{
			CameraStartPostion = transform.parent.position;

			foreach(GameObject oneLight in Lights)
			{
				light2d = oneLight.GetComponent<DynamicLight2D.DynamicLight>();


				// Add listeners
				light2d.OnEnterFieldOfView += onEnter;
				light2d.OnExitFieldOfView += onExit; 
			}
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
				Debug.Log("OnEnter");
				//GetComponent<SpriteRenderer>().color = Color.red;

				transform.parent.position = CameraStartPostion;
			}
			
		}
		
	}

}


