using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float health = 150;
	private float projectileSpeed = 10f;
	public GameObject Projectile;
	public GameObject explode;
	public float shotsPerSeconds = 0.5f ;
	public int scoreValue = 150;
	
	
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update(){
		float probability = Time.deltaTime * shotsPerSeconds;
		if(Random.value < probability){
			Fire();
		}
		
	}
	
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3(0,-1,0);
		GameObject missile = Instantiate(Projectile,startPosition,Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-projectileSpeed);	
	}


	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		Instantiate(explode,missile.transform.position,Quaternion.identity);
		if(missile){
			health -= missile.getDamage();
			missile.Hit();
			if(health <=0){
				Destroy(gameObject);
				scoreKeeper.Score(scoreValue);
			}
		}
	}
}
