using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void MainMenuPlay(){
		SceneManager.LoadScene ("game_play");
		}
	public void QuitButton()
	{
		Application.Quit ();
		Debug.Log ("Quiting");
	}
}
