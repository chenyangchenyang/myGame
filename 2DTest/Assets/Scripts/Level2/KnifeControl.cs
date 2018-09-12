using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour {

    private Vector3 offset;
    private Vector3 startPos;
    private GameObject wood;
    private float swipeDist;
    private float timePast;
    private int woodState = 1;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
        wood = GameObject.Find("WoodHand");
        timePast = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timePast += Time.deltaTime;
	}

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Vector3 tmp = offset + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (timePast >= 2 && (wood.transform.position.x - 7.6 <= transform.position.x &&
                transform.position.x <= wood.transform.position.x - 2.6))
        {
            // 播放木头声音
            swipeDist += Vector3.Distance(tmp, transform.position);
            if (swipeDist > 2)
            {
                timePast = 0;
                swipeDist = 0;
                woodState += 1;
                wood.GetComponent<SpriteRenderer>().sprite = 
                    Resources.Load("img/第二关场景3/mutou" + woodState, new Sprite().GetType()) as Sprite;
                if (woodState == 5)
                {
                    Invoke("", 2);
                }
            }
        }

        transform.position = tmp;
    }

    private void OnMouseUp()
    {
        transform.position = startPos;
    }
}
