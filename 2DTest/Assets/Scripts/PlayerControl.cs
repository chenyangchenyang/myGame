using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

	public float EndX = 250;
    public bool move = false;
    public Vector2 dir;
    public Vector2 lastPosition;
	private Text TextComponent;
    [SerializeField]
    private float speed = 1;

    void Start () 
	{
        lastPosition = gameObject.GetComponent<Rigidbody2D>().position;
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
        var rb = GetComponent<Rigidbody2D>();
        if (move)
        {
            rb.sharedMaterial.friction = 1;
            rb.position = rb.position + speed * dir * Time.deltaTime;
        }   
        else
        {
            rb.sharedMaterial.friction = 1;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    void ChangeScene()
	{
		SceneManager.LoadScene("Success");
	}
}
