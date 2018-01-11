using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject doggie;
    public GameObject player;
    private float timePassed;
    private Vector3 velocity;
    private Vector3 direct;
    private float speed = 50f;
    public Rigidbody2D bullet;
	// Use this for initialization
	void Start () {
        gameObject.transform.position = doggie.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        direct = player.transform.position;
        if (Time.time % .1f > .09f) {
            velocity = direct.normalized * speed;

        }
    }
    
    void FixedUpdate ()
    {
        bullet.velocity = velocity;
    }
}