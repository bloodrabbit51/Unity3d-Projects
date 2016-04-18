#pragma strict

function OnTriggerEnter2D (hitInfo : Collider2D) {
	if(hitInfo.name == "Ball")
	{
		var WallName = transform.name;
		GetComponent.<AudioSource>().pitch = Random.Range(0.9f,1.1f);
		GetComponent.<AudioSource>().Play();
		GameManager.Score(WallName);
		hitInfo.gameObject.SendMessage("ResetBall");
	}
}