using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public LevelManager levelmanager;
	public GameObject explode;

	// Use this for initialization
	private float speed = 0.08f;
	public float padding = 1f;
	public GameObject projectile;
	private float projectileSpeed = 5f;
	private float firingRate = 0.3f; 
	public float health = 250f;
	
	float xmin;
	float xmax;
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x+padding;
		xmax = rightmost.x-padding;
	}
	
	void Fire(){
		Vector3 offset = new Vector3(0,1,0);
		GameObject beam = Instantiate(projectile,this.transform.position+offset,Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,projectileSpeed,0);
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetKey(KeyCode.LeftArrow))
//		{
//			this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*speed,0);
//		}
//		else
//		if(Input.GetKey(KeyCode.RightArrow))
//		{
//			this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
//		}
//		else
//		{
//			this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
//		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			// Move object across XY plane
			transform.Translate(touchDeltaPosition.x * speed,0, 0);
		}
		
		float newX = Mathf.Clamp(this.transform.position.x,xmin,xmax);
		
		this.transform.position = new Vector3(newX, this.transform.position.y,this.transform.position.z);
		try{
		if (Input.GetTouch(1).phase == TouchPhase.Began){
			InvokeRepeating("Fire",0.000001f,firingRate);
		}
		else
		if(Input.GetTouch(1).phase == TouchPhase.Ended){
			CancelInvoke("Fire");
		}
		}
		catch{
			
		}

//		if(Input.GetKey(KeyCode.LeftArrow)){
//			// this.transform.position += new Vector3(-1*speed*Time.deltaTime,0,0);
//			
//			this.transform.position += Vector3.left * speed*Time.deltaTime;
//		}else 
//		if(Input.GetKey(KeyCode.RightArrow)){
//			// this.transform.position += new Vector3(speed*Time.deltaTime,0,0);
//			this.transform.position += Vector3.right * speed*Time.deltaTime;
//		}

		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		Instantiate(explode,missile.transform.position,Quaternion.identity);
		if(missile){
			health -= missile.getDamage();
			missile.Hit();
			if(health <=0){
				Destroy(gameObject);
				levelmanager.LoadLevel("Win Screen");
			}
		}
	}
}

