namespace DynamicLight2D
{
	using UnityEngine;
	using System.Collections;
	
	public class InstanceEvents : MonoBehaviour {
		
		DynamicLight2D.DynamicLight light2d;

		Vector3 startPosition;

		public GameObject Lights;

		DynamicLight2D.DynamicLight []light2ds;


		IEnumerator Start () {
			// Find and set 2DLight Object //
			light2d = GameObject.Find("Light/2DLight").GetComponent<DynamicLight2D.DynamicLight>() as DynamicLight2D.DynamicLight;

			light2ds= Lights.GetComponentsInChildren<DynamicLight2D.DynamicLight> ();


			startPosition = transform.parent.position;
			// Add listeners
			
			light2d.OnEnterFieldOfView += onEnter;
			light2d.OnExitFieldOfView += onExit;

			/*
			foreach(DynamicLight2D.DynamicLight light in light2ds)
			{
				light.OnEnterFieldOfView += onEnter;
				light.OnExitFieldOfView += onExit;
			}
			*/
			yield return new WaitForEndOfFrame();
			//StartCoroutine(loop());
			
		}
		
		
		void onExit(GameObject g, DynamicLight2D.DynamicLight light)
		{
			Debug.Log("OnExit");
			GetComponent<SpriteRenderer>().color = Color.white;
		}
		
		void onEnter(GameObject g, DynamicLight2D.DynamicLight light)
		{
			
			if (gameObject.GetInstanceID () == g.GetInstanceID ()) 
			{
				Debug.Log("OnEnter");
				GetComponent<SpriteRenderer>().color = Color.red;

				transform.parent.position = startPosition;
			}
			
		}
		
	}

}


