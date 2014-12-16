using UnityEngine;
using System.Collections;


//a "singleton" type class.
//it must be attached to an object in the scene!
public class Director : MonoBehaviour {
	public static Director main;

	//assign the static reference to myself
	//so you can access me from anywhere
	//by using "Director.main"
	void Awake(){
		main = this;
	}


	//you can call this from ANY SCRIPT in the project!
	//that's convenient!
	//just use Director.main.EndGame();
	public void EndGame(){
		//end the game here
		Debug.Log("invoking");
		//the invoke function calls a function ON THIS CLASS
		//that function cannot have any arguments.
		//and you can specify a delay!
		Invoke("RestartScene", 8f);
	}


	//this one is PRIVATE
	//(there is no "public" before the "void")
	//so it cannot be called from any script outside of this one
	void RestartScene(){
		Debug.Log("restarting");
		//load the starting scene
		Application.LoadLevel(0);
	}

}
