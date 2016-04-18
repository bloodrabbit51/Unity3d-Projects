   using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("Level Load requested for: "+name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequested(){
		Debug.Log("Quitting the game");
		Application.Quit();
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
