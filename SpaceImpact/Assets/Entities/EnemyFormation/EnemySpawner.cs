using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject enemyPrefab;
	public float width = 20f;
	public float height = 5f;
	private bool movingRight = true;
	public float speed = 5f;
	public float spawnDelay = 0.5f;
	public LevelManager levelmanager;
	
	private float xmax;
	private float xmin;
	
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceToCamera));
		
		xmin = leftBoundary.x;
		xmax = rightBoundary.x;
		
	
		SpawnUntilFull();
	}
	
	void SpawnEnemies(){
		foreach( Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab,child.transform.position,Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy = Instantiate(enemyPrefab,freePosition.position,Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition()){
			Invoke("SpawnUntilFull",spawnDelay);
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight){
			this.transform.position += new Vector3(speed*Time.deltaTime,0);
		}else{
			this.transform.position += new Vector3(-speed*Time.deltaTime,0);
		}
		
		float rightEdgeOfFormation=this.transform.position.x + (0.5f*width);
		float leftEdgeOfFormation=this.transform.position.x - (0.5f*width);
		if(leftEdgeOfFormation < xmin){
			movingRight = true;
		}else if(rightEdgeOfFormation>xmax){
			movingRight = false;
		}
		
		if(AllMembersDead()){
			
		}
	}
	
	Transform NextFreePosition(){
		foreach(Transform childpositionGameObject in transform){
			if(childpositionGameObject.childCount == 0){
				return childpositionGameObject;
			}
		}
		return null;
	}
	
	bool AllMembersDead(){
		foreach(Transform childpositionGameObject in transform){
			if(childpositionGameObject.childCount == 0){
				return false;
			}
		}
		return true;
	}
}
