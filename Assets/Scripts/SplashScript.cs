using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {


	// Update is called once per frame
	void Update () {

		//here we check every frame if the player has pressed the spacebar yet.
		if (Input.GetKeyDown(KeyCode.Space)){
			//once the player has pressed the space bar
			//load our other scene!
			Application.LoadLevel("Scene1");
		}
	}


}
