#pragma strict
var moveUp : KeyCode;
var moveDown : KeyCode;
var Speed : float = 10;
function Update () {
	if(Input.GetKey(moveUp))
	{
		GetComponent.<Rigidbody2D>().velocity.y = Speed;
	}
	else if(Input.GetKey(moveDown))
	{
		GetComponent.<Rigidbody2D>().velocity.y = Speed * -1;
	}
	else
	{
		GetComponent.<Rigidbody2D>().velocity.y = 0;
	}
	GetComponent.<Rigidbody2D>().velocity.x = 0;
}