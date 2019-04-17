using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour {
	Animator anim;
	public int lane=2;
	public int AnimationLocked;
	public float horizvel=0;
	public float verticalvel = 0;
	public static int coin=0;
	public Text txt;
	public Text txt1;
	public Image img;
	public MeshRenderer mesh;
	float length=150.0f;
	public GameObject platform;
	public Transform firstobject;
	Vector3 lastposition;	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
 		lastposition = firstobject.transform.position;
		InvokeRepeating("spawning",0f,0.3f);
		Debug.Log (mesh.bounds.size);
	}
	
// 
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (-50, verticalvel, horizvel);
		txt.text = "COIN : " + coin;

		if (Input.GetKeyDown ("w")) {
			Debug.Log ("w pressed");
			anim.SetInteger ("jumptrigger", 0);
			verticalvel = 80;
			StartCoroutine (WaitTime ());
		}
		if (Input.GetKeyDown ("a") && (AnimationLocked == 0) && (lane > 1)) {
			Debug.Log ("a pressed");
			anim.SetInteger ("fliptrigger", 0);
			horizvel = -50;
			StartCoroutine (WaitTime ());
			AnimationLocked = 1;
			lane--;
		}
		if (Input.GetKeyDown ("d") && (AnimationLocked == 0) && (lane < 3)) {
			Debug.Log ("d pressed");
			anim.SetInteger ("fliptrigger", 0);
			horizvel = 50;
			StartCoroutine (WaitTime ());
			AnimationLocked = 1;
			lane++;
		}
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "abcd") {
			Time.timeScale = 0;
			Destroy (gameObject);
			txt1.text = "SCORE : " + coin;
			img.gameObject.SetActive (true);
		}
		if (other.gameObject.tag == "goldcoin") {
		Destroy (other.gameObject);
			coin++;
		}
	}
	private void spawning()
	{

		GameObject object1=Instantiate(platform) as GameObject;
		object1.transform.position = lastposition+new Vector3(-length,0f,0f);
		lastposition = object1.transform.position;
	} 
	IEnumerator WaitTime()
	{
		yield return new WaitForSeconds (0.5f);
		horizvel = 0;
		AnimationLocked = 0;
		anim.SetInteger("fliptrigger",1);
		anim.SetInteger("jumptrigger",1);
		if (verticalvel == 80) {
			verticalvel = -80;
			StartCoroutine (ExtraWait ());
		}

	}
	IEnumerator ExtraWait()
	{
		AnimationLocked = 0;
		yield return new WaitForSeconds (0.5f);
		verticalvel = 0;
	}

}
