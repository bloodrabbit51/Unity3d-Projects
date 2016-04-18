using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public Paddle paddle;
	
	private Vector3 paddleToBallVector;
	private bool hasStrated = false;
	
	// Use this for initialization
	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;   
	}
	
	// Update is called once per frame
	void Update () {
	
			if(!hasStrated){
				this.transform.position = paddle.transform.position + paddleToBallVector;
				
			if(Input.GetMouseButton(0)){
				hasStrated = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,7f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2(Random.Range(0f,0.2f),Random.Range(0f,0.2f));
		if(hasStrated){
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
