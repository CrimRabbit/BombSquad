using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Target : MonoBehaviour {
	//private GameInstruction instruction;

	public int targetID;
	public Sprite normal;
	public Sprite highlighted;
	public Sprite cut;

	Target(int targetID, Vector3 position) {
		this.targetID = targetID;
	}
	
	// upon completion of an instruction (either this or another one), the old instruction will be updated with a null, and a target with a null instruction will be updated with a new GameInstruction object
	/*
	public void UpdateInstruction(GameInstruction newInstruction) {
		this.instruction = newInstruction;
	}
	*/
}