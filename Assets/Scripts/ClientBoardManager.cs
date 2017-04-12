using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ClientBoardManager : MonoBehaviour {
    private int timeLeft; // indicate time left to explosion. Higher is better
	private int playerID; // indicates which player this is1
	public Text displayInstruction; // stores the instruction that the player sees
	private GameObject[] playerDisplay; // list of common UI elements at the top of the controls

	public GameObject[] allGameTargets; // list of all targetable objects in the game
	public Vector3[] allGameTargetPositions; // list of all available positions a game target can be

	private int[] targets; // the list of target objects in the current level
	private int[] targetPosition; // the respective positions of those targets

	public GameObject[] allGameTools; // list of tools in the game
	public Vector3[] allGameToolSizes; // list of sizes a game tool can take on in the game
	public Vector3[] allGameToolPositions; // list of all available positions a game tool can be

	private int[] tools; // list of game tools available to player in current level
	private int[] toolSizes; // same size as gameTools, indicates how large each corresponding tool is
	private int[] toolPosition; // indicates where on the board to place the corresponding tool
	
	private Transform toolHolder; // group elements together for neatness
	private Transform targetHolder; // group targets together
	private List<Vector3> gridPositions; // set of board positions to use

	public GameObject[] arrows;


	// setup the tools
	void ToolSetup() {
		toolHolder = new GameObject("ToolHolder").transform;
		for (int i = 0; i < tools.Length; i++) {
			GameObject tool = allGameTools[tools[i]];
			Vector3 toolSize = allGameToolSizes[toolSizes[i]];
			Vector3 position = allGameToolPositions[toolPosition[i]];
			
			//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
			GameObject instance = Instantiate(tool, position, Quaternion.identity) as GameObject;

			Tool toolScript = (Tool) instance.GetComponent(typeof(Tool));
			toolScript.toolID = tools[i];
			toolScript.position = allGameToolPositions[i];

			// resize the game object as intended
			instance.gameObject.transform.localScale = toolSize;
			
			//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
			instance.transform.SetParent(toolHolder);
		}
	}
	
	// TODO: setup the common view everyone sees
	// for example, just set up 3 colliders to drag the tools to. 
	void SetupPlayerDisplay() {
		targetHolder = new GameObject("TargetHolder").transform;
		for (int i = 0; i < targets.Length; i++) {
			GameObject target = allGameTargets[targets[i]];
			Vector3 position = allGameTargetPositions[targetPosition[i]];

			//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
			GameObject instance = Instantiate(target, position, Quaternion.identity) as GameObject;

			Target targetScript = (Target) instance.GetComponent(typeof(Target));
			targetScript.targetID = tools[i];

			// resize the game object as intended
			//instance.gameObject.transform.localScale = toolSize;

			//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
			instance.transform.SetParent(targetHolder);
		}
	}
	
	// TODO: text should be able to be modified
	// actually, I think this method is redundant
	void SetupDisplayInstruction() {}
	
	public void SetupScene(int[] tools, int[] toolSizes, int[] toolPosition, int[] targets, int[] targetPosition) {
		// get all the tools and whatnot
		this.tools = tools;
		this.toolSizes = toolSizes;
		this.toolPosition = toolPosition;

		// likewise for the targets
		this.targets = targets;
		this.targetPosition = targetPosition;

		// create all the tools in their respective positions and size
		ToolSetup();

		// setup the display instruction
		SetupDisplayInstruction();

		// setup the targets
		SetupPlayerDisplay();
		// TODO: maybe do other stuff that the scene requires?
	}

	// update the instruction that the player sees
	public void UpdateInstruction(string newInstruction) {
		this.displayInstruction.text = newInstruction;
		//Debug.Log("instruction updated");
	}
}