using UnityEngine;
using System.Collections;

public class SheepiePath : MonoBehaviour {
    public GameObject player;
    public bool dead = false;
	public float speed = .0f;
	private Vector3 velocity;
	private Rigidbody2D sheepBody;
	private Vector3 randomVect;
    private float timePassed = .0f;
    private float startTime;
	private float timeSub;
	private Vector3 direct;
	private int stop;
	void Start ()
	{
		velocity = Vector3.zero;
		randomVect = Vector3.zero;
		sheepBody = GetComponent<Rigidbody2D>();
        startTime = Time.time;
		timeSub = 0f;
		stop = Random.Range(0,1);
	}
	
	void Update ()
	{
        timePassed = Time.time - startTime;
		if (timePassed-timeSub > 0f) {
			randomVect.x = Random.Range (-100f, 100f);
			randomVect.y = Random.Range (-100f, 100f);
			if(stop==0) {
				direct = randomVect - transform.position;
				stop=1;
			}
			else {
				direct=gameObject.transform.position;
				stop=0;
			}
			velocity = direct.normalized * speed;
            startTime += timeSub;
			timeSub = Random.Range (3f, 7f);
        }
		float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle - 90);
	}
	
	void FixedUpdate ()
	{
		sheepBody.velocity = velocity;
	}
}
