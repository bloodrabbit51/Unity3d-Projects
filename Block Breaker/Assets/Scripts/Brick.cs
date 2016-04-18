using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private LevelManager levelmanager;
	private int timesHit;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelmanager=GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D col){
		timesHit++;
		//SimulateWin();
		maxHits--;
		if(maxHits==0)
		{
			Destroy(gameObject);
		}
		else
		{
			print("Damage");
		}
	}
	
	void SimulateWin(){
		levelmanager.LoadNextLevel();
	}
}
