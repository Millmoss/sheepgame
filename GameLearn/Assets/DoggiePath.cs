using UnityEngine;
using System;

public class DoggiePath : MonoBehaviour
{
    public GameObject player;
	public GameObject bullet;
    public float speed = 1f;
    private Vector3 velocity;
    private Rigidbody2D dogBody;
    PlayerData quert;
	public bool chase = false;
	void Start ()
    {
        quert = player.GetComponent<PlayerData>();
        velocity = Vector3.zero;
        dogBody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        bool running = false;
        Vector3 toPlayer = player.transform.position - transform.position;
        velocity = toPlayer.normalized * speed;
        float angle = Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        if (Math.Abs(player.transform.position.x - transform.position.x) < 5)
            if (Math.Abs(player.transform.position.y - transform.position.y) < 5)
            {
                speed = 6f;
                running = true;
            }
        else
            speed = 1f;
        if (quert.speed == 3f && running==false)
        {
            speed = 2f;
        }
        else if(running==false)
            speed = 1f;
        if (quert.hiding == true)
            speed = .3f;

    }

    void FixedUpdate ()
    {
        dogBody.velocity = velocity;
    }
}