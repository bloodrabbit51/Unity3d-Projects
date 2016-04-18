using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {
	public float speed = 0.1F;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.touches != null) //if any finger are on the screen 
//		{
//			Touch touch = Input.touches[0];
//		    Rect rect = new Rect(0, 0, Screen.width/2, Screen.height); //rect of your Arrow for the next level
//		if (rect.Contains(Input.GetTouch(0).position))
//			{
//				Debug.Log("touch recieved");
//			}
//		if (!rect.Contains(Input.GetTouch(1).position))
//		{
//			Debug.Log(" other touch recieved");
//		}
		//}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			// Move object across XY plane
			transform.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
		}
	}
	
}
