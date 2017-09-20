using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

//public delegate void StateCaller();

public class TextController : MonoBehaviour {

	public Text text;

//	private enum States {start_0, start_1, cell, mirror, sheets, door_0, door_1, hall_0, hall_1};
//	private States myState;
	Action updateState= null;
	private bool have_key;
	private bool have_shovel;

//	StateCaller callState = new StateCaller();
//	StateCaller callState = state_start_0;

	// Use this for initialization
	void Start () {
//		myState = States.start_0;
		updateState = this.state_start_0;
		have_key = false;
		have_shovel = false;
	}
	
	// Update is called once per frame
	void Update () {
		updateState ();
//		print (myState);
//		if (myState == States.start_0)
//			state_start_0 ();
//		else if (myState == States.start_1)
//			state_start_1 ();
//		else if (myState == States.cell)
//			state_cell ();
//		else if (myState == States.sheets)
//			state_sheets ();
//		else if (myState == States.mirror)
//			state_mirror ();
//		else if (myState == States.door_0)
//			state_door_0 ();
//		else if (myState == States.door_1)
//			state_door_1 ();
	}

//	void stateCaller (current_state) {
//
//	}

	void state_start_0 () {
		text.text = "Welcome to your new prison" +
			"\n[Press space to continue]";
		if (Input.GetKeyDown("space")){
//			myState = States.start_1;
			updateState = this.state_start_1;

		}
	}

	void state_start_1 () {
		text.text = "You wake up in your dark damp cell. " +
			"The moisture on the walls has been " +
				"in this cell longer than you have. " +
				"You have to get out of here." +
				"\n[Press space to continue]";
		if (Input.GetKeyDown("space")){
//			myState = States.cell;
			updateState = this.state_cell;

		}
	}

	void state_cell () {
		text.text = "You see the door to your cell, " +
			"the dirty sheets on your bed, " +
			"and a mirror on the wall.\n" +
			"[S: look at sheets]\n" +
			"[D: look at door]\n" +
			"[M: look at mirror]";

		if (Input.GetKeyDown("s"))
//			myState = States.sheets;
			updateState = this.state_sheets;

		if (Input.GetKeyDown("d") && have_key)
//			myState = States.door_1;
			updateState = this.state_door_1;

		else if ( Input.GetKeyDown("d") )
//			myState = States.door_0;
			updateState = this.state_door_0;

		if (Input.GetKeyDown("m"))
//			myState = States.mirror;
			updateState = this.state_mirror;

		
	}

	void state_sheets () {
		text.text = "They look awful, they smell awful, they have a thread count of about five, " +
			"and that is as much as you care to know." +
			"\n[Press space to return]";
		if (Input.GetKeyDown ("space")) 
//			myState = States.cell;
			updateState = this.state_cell;
	}

	void state_mirror () {
		if (!have_key) {
			text.text = "Your reflection is just as gruesome as ever.\n" +
				"Wait a minute... you can use this. You wrench the mirror off of the wall." +
				"\n[Press space to return]";
		} else 
			text.text = "Your reflection is just as..." +
				"oh wait, you already ripped the mirror off the wall." +
				"\n[Press space to return]";

		if (Input.GetKeyDown ("space")) {
			have_key = true;
//			myState = States.cell;
			updateState = this.state_cell;
		}
	}

	void state_door_0 () {
		text.text = "It's locked... what a surprise.\n" +
				"\n[Press space to return]";
		if (Input.GetKeyDown("space"))
//			myState = States.cell;
			updateState = this.state_cell;
	}

	void state_door_1 () {
		text.text = "Holding the mirror with one hand " +
			"and fanangling a piece of wire with the other, " +
			"you awkwardly pick the the lock to your cell door " +
			"and somehow manage not to drop either." +
			"\n[Press space to continue]";
		if (Input.GetKeyDown("space"))
//			myState = States.hall_0;
			updateState = this.state_hall_0;
	}

	void state_hall_0 () {
		text.text = "The door swings open, and you breath that fresh dungeon corridor air. \n" +
			"Cool, what now?" +
			"\n[Press space to continue]";
		if (Input.GetKeyDown("space"))
//			myState = States.hall_1;
			updateState = this.state_hall_1;
	}

	void state_hall_1 () {
		text.text = "There is a guard at the end of the hallway with his back turned, [G]\n" +
			"a shovel propped against a maneure bucket not too far from you, [S]\n" +
			"and a fairy sitting on a toadstool a little bit in the other direction. [F]";
		if (Input.GetKeyDown("g"))
			updateState = this.state_guard;
		if (Input.GetKeyDown("s"))
			updateState = this.state_shovel;
		if (Input.GetKeyDown("f"))
			updateState = this.state_fairy_0;
	}

	void state_fairy_0 () {
		text.text = "The fairy looks at you with the gruff face " +
			"of one who has seen too much in the world.\n" + 
			"He offers you a gram of \"fairy dust\" on the house.\n" + 
			"[A: Accept \"fairydust\"]" +
			"[Space: Return]";

		if (Input.GetKeyDown("space"))
			//			myState = States.hall_1;
			updateState = this.state_hall_1;
		else if(Input.GetKeyDown("a"))
			updateState = this.state_fairy_1;
	}

	void state_fairy_1 () {
		text.text = "Being a person of high moral fortitude " +
			"who knows the intrinsic dangers of accepting strange " +
			"substances from strange folk, particularly those that sit on toadstools, " +
			"you decline the offer with the firm conviction that you are not " +
			"passing on a potentially life-changing opportunity.\n" +
			"[Press space to return]";
		
		if (Input.GetKeyDown ("space"))
			//			myState = States.hall_1;
			updateState = this.state_hall_1;

	}

	void state_shovel () {
			if (!have_shovel) {
				text.text = "It has layers upon layers of a nasty, brown, pungent mud. " +
					"Nonetheless you decide to pick it up.\n " +
					"Gingerly.\n" +
					"\n[Press space to return]";
				if (Input.GetKeyDown ("space")) {
					have_shovel = true;
					updateState = this.state_hall_1;
				}
			} else {
				text.text = "You search for the shovel long and hard - " +
					"you swear it was here just a moment ago.\n" +
					"You are looking for at least ten minutes " +
					"before you realize you were holding it the whole time." +
					"\n[Press space to continue]";
				
				if (Input.GetKeyDown ("space")) {
					updateState = this.state_hall_1;
				}
			}
		}
		

	void state_guard () {
		if (!have_shovel) {
			text.text = "You dash up to the guard and sock him in the back of the head! " +
				"Unfortunately that hurt you much more than it hurt him. " +
				"Because he is wearing a helmet.\n" +
				"Still, he still somehow didn't notice.\n" +
				"\n[Press space to return]";
			if (Input.GetKeyDown ("space")) {
				updateState = this.state_hall_1;
			}
		} else {
			text.text = "You thwack the guard hard with the shovel and put a dent in his helmet. " +
				"He falls to the -\n" +
				"whoa wait, this guard is a woman! Equal opportunity dungeons FTW!" +
				"\n[Press space to continue]";
		
			if (Input.GetKeyDown ("space")) {
				updateState = this.state_freedom;
			}
		}
	}

	void state_freedom () {
		text.text = "As you step over the body of the unconscious guard, " +
			"you feel a slight breeze as you walk up the steps.\n" +
			"Somehow, you know the mildew will be a little fresher up there.\n" +
			"[The End. Congrats! Press Enter to start again]";
		if (Input.GetKeyDown ("enter") || Input.GetKeyDown ("return")) {
			Start();
		}
	}

}
