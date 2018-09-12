﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDefs : MonoBehaviour {

    public float PuckTimeLength = 2;
    public float puckTime = 0;
	// Use this for initialization
	void Start () {
        PuckGlobal.Init();
	}
	
	// Update is called once per frame
	void Update () {
        puckTime += Time.deltaTime;
        if (PuckGlobal.puckState == 1 && puckTime >= 2)
        {
            GotoPuckBall();
        }
	}

    public void Puck()
    {
        if (PuckGlobal.puckState == 0)
        {   
            PuckGlobal.puckState = 1;
            PuckGlobal.ReleasePuckBall();
            puckTime = 0;
            // Update() 2秒后会自动调用 GotoPuckBall()
        }
        else
        {
            GotoPuckBall();
        }
    }

    public void GotoPuckBall()
    {
        if (PuckGlobal.puckState == 0) return;
        PuckGlobal.GotoPuckBall();
        PuckGlobal.puckState = 0;
    }
}

public class PuckGlobal
{
    public static GameObject puckBall;
    public static GameObject player;
    public static int puckState = 0;
    public static JoyStickControl joyStickControl;
    public static GameObject controlButton;
    public static void Init()
    {
        puckBall = GameObject.Find("PuckBall");
        player = GameObject.Find("Player");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("playerBody"), LayerMask.NameToLayer("puck"), true);
        joyStickControl = GameObject.Find("GlobalController").GetComponent<JoyStickControl>();
        controlButton = GameObject.Find("Button");
    }

    // 创建帕克法球，并使其自动向当前方向行走数秒
    public static void ReleasePuckBall()
    {
        Show(puckBall);
        puckBall.transform.position = player.transform.position;
        PlayerControl playerControl = player.GetComponent<PlayerControl>();
        puckBall.GetComponent<PlayerControl>().dir = playerControl.lastDir;
        puckBall.GetComponent<PlayerControl>().move = true;
        puckBall.transform.GetChild(0).localScale = player.transform.GetChild(0).localScale;
        //controlButton.SetActive(false);
    }

    // 将本体移动到帕克法球的位置，使帕克法球消失，交还控制消息
    public static void GotoPuckBall()
    {
        player.transform.position = puckBall.transform.position;
        puckBall.GetComponent<PlayerControl>().move = false;
        //controlButton.SetActive(true);
        Hide(puckBall);
    }

    public static void Hide(GameObject o)
    {
        o.transform.localScale = Vector3.zero;
    }

    public static void Show(GameObject o)
    {
        o.transform.localScale = Vector3.one;
    }
}
