using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {
	
	public void Pause(){
		Time.timeScale = 0f;

	}
	public void resume(){
		Time.timeScale = 1;
	
	}
	public void SceneMainMenu(){
		Destroy (GameObject.FindWithTag ("obj"));
		SceneManager.LoadScene ("UI SCENES");
	}
	public void playagain()
	{SceneManager.LoadScene ("game_play");
		Time.timeScale = 1f;
		PlayerController.coin = 0;
	}
}
