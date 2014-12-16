using UnityEngine;
using System.Collections;

//UIController is our little text changer script for the Score text.
public class UIController : MonoBehaviour {
	//our hacky singleton thing.
	public static UIController main;


	//here we get a reference to the TextMesh component
	//of a 3D text, which we will use to display the score.
	//we MUST reference this in the inspector, since we aren't assigning it in the script.
	//so drag it into the script, once you attach this component to an object!
	public TextMesh scoreTextMesh;

	//here we put the score as an integer
	//the reasoning behind that is so we can read the score later
	public int score;


	//we must assign that static reference!
	void Awake(){
		main = this;
	}

	// Use this for initialization
	void Start () {
		//let's start out with a score of 0
		score = 0;
	}

	//when another script calls this function
	//by using "UIController.main.SetScore(score)"
	//we will save the score
	//and then update the text!
	public void SetScore(int score){
		//save the score.
		//we have to use this.score because our parameter is also called score!
		this.score = score;
		//update the score text, using string concatenation (adding strings together)
		scoreTextMesh.text = "Score: " + score;
	}


}
