using UnityEngine;
using System;

public class CameraStuff : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(player.GetComponent<PlayerData>().score<48)
		    gameObject.transform.position = player.transform.position;
        else
            gameObject.transform.position = player.transform.position;
    }
}