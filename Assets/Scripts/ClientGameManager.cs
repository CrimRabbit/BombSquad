using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 

public struct instructionStruct {
	int tool;
	int target;
	int targetValue;
}

public class ClientGameManager : MonoBehaviour {
	public static ClientGameManager instance = null;
	private ClientBoardManager boardScript;

	public GameObject greenPart;

	private int playerID = 0;
	private int level = 1;
	public int score;

	private int numTools; // indicates a certain number of tools to be used for the particular level

	private int[] tools; // list of game tools available to player in current level
	private int[] toolSizes; // same size as gameTools, indicates how large each corresponding tool is
	private int[] toolPosition; // indicates where on the board to place the corresponding tool

	private int[] targets; // the list of target objects in the current level
	private int[] targetPosition; // the respective positions of those targets

//	[SyncListStruct<instructionStruct>]
//	public class PlayerStatsSyncClass : SyncListStruct<PlayerStats>{}

//	public PlayerStatsSyncClass playerStatsList = new PlayerStatsSyncClass();
	GameInstruction[] instructions = new GameInstruction[4]; // keeps track of the instructions generated. The 4 represents the total number of players, which is 4, 
	                                         // and each entry records the target object that the respective player is supposed to do an action on.
	                                         // for example, instructions[2] = 6; would mean that player 2 is supposed to perform an action on target 6
	
	// Awake is always called before any Start functions
	void Awake() {
		// using the singleton pattern
		if (instance == null) {
			instance = this;
		} else if (instance != this) { // if instance already exists and it's not this
			Destroy(gameObject); // then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
		}
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		//Get a component reference to the attached BoardManager script
		boardScript = GetComponent<ClientBoardManager>();
		
		//Call the InitGame function to initialize the first level 
		InitGame();
	}

	// creates a new instruction based on the current tools and instructions
	GameInstruction CreateNewInstruction() {
		// not sure how it should be done actually TODO
		int target = Random.Range(0, numTools);

		GameInstruction gameInstruction = new GameInstruction (target, target, 0);
		this.instructions[playerID] = gameInstruction;

		return gameInstruction;
	}

	// called by InitGame
	// initializes the tools, tool sizes, tool positions
	// initializes the targets, target positions
	void CreateLevel(int level) {
		// availableTools is used to prevent duplicate tools from getting fabricated
		List<int> availableTools = new List<int>();
		for (int i = 0; i < boardScript.allGameTargets.Length; i++) {
			availableTools.Add(i);
		}

		score = 0;
		numTools = 16;
		int j;
		tools = new int[numTools];
		for (int i = 0; i < numTools; i++) {
			j = Random.Range(0, availableTools.Count);
			tools[i] = availableTools[j];
			availableTools.RemoveAt(j);
		}
		toolSizes = new int[numTools];
		for (int i = 0; i < numTools; i++) {
			toolSizes[i] = 0;
		}
		toolPosition = new int[numTools];
		for (int i = 0; i < numTools; i++) {
			toolPosition[i] = i;
		}

		targets = new int[numTools];
		for (int i = 0; i < numTools; i++) {
			targets[i] = tools[i];
		}
		targetPosition = new int[numTools];
		for (int i = 0; i < numTools; i++) {
			targetPosition[i] = i;
		}
		RandomizeArray(targetPosition); // randomize their positions a bit
	}
	
	// initializes the game for each level.
	void InitGame() {
		CreateLevel(level);
		// call the SetupScene function of the ClientBoardManager script, pass it current level number.
		boardScript.SetupScene(tools, toolSizes, toolPosition, targets, targetPosition);
	}
	
	// Update is called every frame
	// Update will serve as the main game loop
	// Game loop is supposed to: 
	//     1) Update the bomb explosion timing periodically (score)
	//     2) Wait for players to send the action they did using OnTouchDrop()
	//     3) Keep track of the Instructions sent to the different players
	//     4) Use UpdatePlayerInstruction to send a new instruction to a player whose instruction has been completed
	//     5) Check whether the game is over (Win->diffusing bomb/Lose->bomb exploded)
	//     6) Update playerDisplay for all players (upon sucessful instruction completion || upon failure to complete instruction)
	//     
	//void Update() {
	//	// TODO: complete game loop
	//	score++;
	//	UpdateProgressBar();
	//}

	//void UpdateProgressBar() {
	//	// 19 is the max value
	//	float val = (float)(score * 19.0 / 1000);
	//	this.greenPart.gameObject.transform.localScale = new Vector3(val, 40, 1);
	//}

	// conveniece function for randomising an array, uses the Fisher Yates Shuffle
	static void RandomizeArray(int[] arr) {
		for (var i = arr.Length - 1; i > 0; i--) {
			var r = Random.Range(0,i);
			var tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}
	}
	
}