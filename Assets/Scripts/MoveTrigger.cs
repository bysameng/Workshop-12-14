using UnityEngine;
using System.Collections;

public class MoveTrigger : MonoBehaviour {

	public AudioClip onTriggerSound;

	public bool triggered;
	private bool stageTwoRising;

	private Vector3 movementDirection;

	// Use this for super close to instantiation init
	void Awake() {
		//put code here
	}

	// Use this for initialization
	//this will be called pretty much as the script is first created
	//it will ALWAYS run before Update
	void Start () {
		Debug.Log("hello universe");
		triggered = false;
		stageTwoRising = false;
	}
	
	// Update is called once per frame
	//It is called EVERY frame. 
	void Update () {
		if (triggered == true){
			//we organized this into a function
			MoveForward();
		}
		if (stageTwoRising == true){
			MoveUp();
		}
	}

	//the code you guys before, had in the Update function.
	//I moved it here just for neatness in Update.
	//you should do things like that too.
	void MoveForward(){
		//we are storing the direction we want to go in
		//and then scaling it by 10.
		//That means we will go 10 units per second.
		//how do we know "per second?"
		//Because we are multiplying it by Time.deltaTime.
		Vector3 movement = movementDirection * 10f * Time.deltaTime;

		//below are all different ways of doing movement!

		//set the position manually
//			transform.position = transform.position + movement;

		//translate the position
		//sets LOCALLY, relative to LOCAL axes
//			transform.Translate(movement);

		//set the LOCAL position manually
		//is NOT relative to LOCAL axes
		//is relative to PARENT axes
		transform.localPosition = transform.localPosition + movement;
	}

	//this function will move the attached gameObject upward!
	//we know it's up because it's 10 in the y direction per sec
	//and we are moving its GLOBAL position.
	//not the local position, which would be relative to the parent.
	void MoveUp(){
		Vector3 movement = new Vector3(0f, 10f, 0f) * Time.deltaTime;
		transform.position += movement;
	}

	//IMPORTANT!!!
	// OnTriggerEnter is ONLY called when
	// 1) A collider is attached
	// 2) The collider has "isTrigger" ticked
	// 3) A rigidbody/character controller enters the collider
	//if these conditions are not fulfilled, your trigger will NEVER be called.
	void OnTriggerEnter(Collider other){

		//we have tagged the PLAYER object with the tag "Player"
		//so now we will check here, if it is a Player touching this trigger.
		if (other.gameObject.tag == "Player"){

			//play an audio clip at a location!
			AudioSource.PlayClipAtPoint(onTriggerSound, transform.position);

			//tell our UIController singleton to change itself
			UIController.main.SetScore(1000);

			//here we are storing the velocity of the player.
			//the velocity is going to be a property of the thing that makes a gameobject move
			//usually, that would be a rigidbody.
			//to access a gameobject's rigidbody, you would do the same thing as below
			//except instead of CharacterController, you write Rigidbody.
			//we are here, getting the charactercontroller since the player has a character controller
			//not a rigidbody.
			//keep in mind you can do this for ANY component!
			//For example, you could, in another script, call
			//GetComponent<MoveTrigger>()
			//MoveTrigger is THIS component! You'd be able to access THIS GUY'S variables.
			movementDirection = other.gameObject.GetComponent<CharacterController>().velocity;
			//normalize means to set the vector to length = 1
			movementDirection.Normalize();

			Debug.Log("Triggered!");
			triggered = true;
			//destroy takes an object, and OPTIONALLY, a delay.
			Destroy(this.gameObject, 5f);
			//invoke will call a function ON THIS SCRIPT
			//with a delay!
			Invoke("StartMoveUp", 2f);

			//here we tell our singleton to end the game.
			//notice how we are calling a function on another script on another object
			//without taking any reference
			//and without using "GetComponent<>()"
			Director.main.EndGame();
		}
	}

	//IMPORTANT!!!
	//OnCollisionEnter is only called when
	// 1) A collider is attached
	// 2) isTrigger is NOT ticked
	// 3) A rigidbody is attached
	// 4) A rigidbody touches the collider
//	void OnCollisionEnter(Collision other){
//		Debug.Log("Collision!");
//	}


	//OnDestroy runs right before the object is destroyed
	//do cleanup or other stuff here
	//essentially a destructor
	void OnDestroy(){
		Debug.Log("Destroying " + this.gameObject.name + "!");
	}


	//our little function that we will use Invoke on.
	void StartMoveUp(){
		stageTwoRising = true;
	}



}
