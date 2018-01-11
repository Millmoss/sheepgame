using UnityEngine;
using System;

public class PlayerData : MonoBehaviour {
    public GameObject player;
    public GameObject sheepie;
    public GameObject fake;
    public float speed = .0f;
    public bool attack = false;
	public int score = 0;
    public bool hiding = false;
    private Vector3 velocity;
    private Rigidbody2D playerBody;
    private float timePassed;
    private Vector3 move;
	private float angle;
	private float xAng = 0;
	private float yAng = 0;
    private bool hidable;

    // Use this for initialization
    void Start()
    {
        velocity = Vector3.zero;
        move = Vector3.zero;
        playerBody = GetComponent<Rigidbody2D>();
        hidable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePassed == 0f)
            Control();
		transform.rotation = Quaternion.Euler (0, 0, angle - 90);
        if (Input.GetKeyDown(KeyCode.RightShift) && hidable == true)
        {
            hiding = true;
            speed = .5f;
        }
        if (hiding == true && hidable == true)
        {
            fake.transform.position = gameObject.transform.position;
            fake.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
        if (Input.GetKeyUp(KeyCode.RightShift) || hidable == false)
        {
            hiding = false;
            speed = 1f;
            Vector3 temp;
            temp.x = 1000;
            temp.y = 1000;
            temp.z = 0;
            fake.transform.position = temp;
        }
        if(hiding==true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            hidable = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && timePassed == 0f && hiding == false)
        {
            timePassed = Time.time;
            velocity /= speed;
            velocity *= 7;
            attack = true;
        }
        if ((Time.time - timePassed) > 0.25f && timePassed != 0)
        {
            velocity /= 7;
            velocity *= speed;
            attack = false;
        }
        if ((Time.time - timePassed) > 0.5f)
            timePassed = 0f;
        if (score > 45)
        {
            Vector3 temp;
            temp.x = 92.13895f;
            temp.y = 0;
            temp.z = 0;
            transform.position = temp;
        }
    }

    void Control()
    {
        float xChange = .0f;
        float yChange = .0f;
        if (Input.GetKeyUp(KeyCode.LeftShift) && hiding == false)
        {
            hidable = true;
            speed = 1f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = 3f;
        Vector3 change = transform.position;
		xAng = 0;
		yAng = 0;
        if (Input.GetKey(KeyCode.A))
        {
            xChange -= speed;
            xAng -= 100;
        }
        if (Input.GetKey(KeyCode.W))
        {
            yChange += speed;
            yAng += 100;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yChange -= speed;
            yAng -= 100;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xChange += speed;
            xAng += 100;
        }
        if (xChange != 0 && yChange != 0)
        {
            xChange /= 1.5f;
            yChange /= 1.5f;
        }
        change.x += xChange;
        change.y += yChange;
        move = change - transform.position;
        velocity = move.normalized * speed;
		if (xAng != 0 || yAng != 0) {
			angle = Mathf.Atan2 (change.y + yAng, change.x + xAng) * Mathf.Rad2Deg;
		}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Sheep" && attack == true) {
			Destroy (coll.gameObject);
			score+=1;
		}
        if (coll.gameObject.tag == "Dog")
        {
            Destroy(gameObject);
            Application.LoadLevel(0);
        }
    }

    void FixedUpdate()
    {
        playerBody.velocity = velocity;
    }
}
