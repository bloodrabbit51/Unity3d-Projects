using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float Damage = 100f;
	
	public float getDamage(){
		return Damage;
	}
	
	public void Hit(){
		Destroy(gameObject);
	}
}
