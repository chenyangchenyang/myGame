using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl : MonoBehaviour {

    public GameObject upTarget, downTarget;
    public bool caught = false;
    private Vector3 currPos, tarPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (caught)
        {
            Vector3 offset = tarPos - currPos;
            transform.position = transform.position + offset * Time.deltaTime;
            if (Vector3.Distance(transform.position, tarPos) < 0.5)
            {
                currPos = tarPos;
                tarPos = downTarget.transform.position;
                GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            if (Vector3.Distance(transform.position, downTarget.transform.position) < 0.5)
            {
                PuckGlobal.Hide(gameObject);
                GameObject.Find("FishGirl").GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("img/第二关场景4/cheerGirl");
                Invoke("HideFishing", 1.5f);
                Invoke("ShowLeaving", 2.5f);
            }
        }
	}

    void HideFishing()
    {
        GameObject.Find("FishOldMan").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
        GameObject.Find("FishGirl").GetComponent<Scene22AlphaControl>().ChangeVisible(false);
    }

    void ShowLeaving()
    {
        GameObject.Find("Leaving").GetComponent<Scene22AlphaControl>().ChangeVisible(true);
    }

    void OnMouseDown()
    {
        caught = true;
        currPos = transform.position;
        tarPos = upTarget.transform.position;
        Destroy(GetComponent<Animator>());
    }
}
