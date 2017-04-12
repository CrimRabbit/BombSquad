using System;
using Random = UnityEngine.Random;

public class GameInstruction {
	private int target;
	private int direction;
	private string name;
	string displayText;

	public string[,] toolNames = {
		{"Phillips Screwdriver", "Plus Turnscrew", "Cross Rivet"},
		{"Flat Head Screwdriver", "Pokeball Turnscrew", "Straight Rivet"},
		{"3-Way Screwdriver", "Mecedes Turnscrew", "Tri-point Rivet"},
		{"5-Way Screwdriver", "Star Turnscrew", "Five-point Rivet"},
		{"Square Screwdriver", "Cubic Turnscrew", "Four-sided Rivet"},
		{"Hexagonal Wrench", "Benzene Kernel", "Honeycomb Cranium"},
		{"Pentagonal Wrench", "Penta Kernel", "Pentangular Cranium"},
		{"Square Wrench", "Cubic Kernel", "Four-sided Cranium"},
		{"Triangle Wrench", "Trilateral Kernel", "Trigon Cranium"},
		{"Star Wrench", "Paragon Kernel", "Twinkle Little Cranium"},
		{"Red Wirecutter", "Blood Scissors", "Lipoplasmic Scalper"},
		{"Green Wirecutter", "Goop Severer", "Tree Blood Knife"},
		{"Navy Wirecutter", "Silence of the Ocean", "Endowharfic Stopper"},
		{"Cyan Wirecutter", "Sky Wirecutter", "Endicular Blocker"},
		{"Purple Wirecutter", "Magenta Wirecutter", "Smackadorfal Repeader"},
		{"Yellow Wirecutter", "Honey Wirecutter", "Lemon Tea Tightener"},
	};

	public string[,] action = {
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Loosen the ", "Free the ", "Tighten the ", "Secure the "},
		{"Cut the", "Sever the", "Disassemble the", "Cleave the"},
		{"Cut the", "Sever the", "Disassemble the", "Cleave the"},
		{"Cut the", "Sever the", "Disassemble the", "Cleave the"},
		{"Cut the", "Sever the", "Disassemble the", "Cleave the"},
		{"Cut the", "Sever the", "Disassemble the", "Cleave the"},
		{"Cut the", "Sever the", "Disassemble the", "Cleave the"},
	};

	public string[,] targetNames = {
		{"Phillips Bolt", "Plus Pin", "Cross Rivet"},
		{"Flat Head Bolt", "Pokeball Pin", "Straight Rivet"},
		{"3-Way Bolt", "Mecedes Pin", "Tri-point Rivet"},
		{"5-Way Bolt", "Star Pin", "Five-point Rivet"},
		{"Square Bolt", "Cubic Pin", "Four-sided Rivet"},
		{"Hexagonal Nut", "Benzene Kernel", "Honeycomb Cranium"},
		{"Pentagonal Nut", "Penta Kernel", "Pentangular Cranium"},
		{"Square Nut", "Cubic Kernel", "Four-sided Cranium"},
		{"Triangle Nut", "Trilateral Kernel", "Trigon Cranium"},
		{"Star Nut", "Paragon Kernel", "Twinkle Little Cranium"},
		{"Red Wire", "Red String of Fate", "Lipoplasmic Transferrer"},
		{"Green Wire", "Goop Transferrer", "Tree Blood Pipe"},
		{"Navy Wire", "Song of the Ocean", "Endowharfic Amplifier"},
		{"Cyan Wire", "Sky Wire", "Endicular Rectifier"},
		{"Purple Wire", "Magenta Wire", "Smackadorfal Lamber"},
		{"Yellow Wire", "Honey Wire", "Lemon Tea Squishy Pipe"},
	};

	public GameInstruction(int target, int direction, String name) {
		this.target = target;
		this.name = name;
		this.direction = direction;
		this.displayText = GenerateInstructionText(target);
	}

	private string GenerateInstructionText(int target) {
		if(target < 10){ //screw or nut
			if(direction > 0){ //clockwise, tightens
				return action[target, Random.Range(2,3)] + this.name + "!";
			}else{ // <= 0 anti-clock, loosen
				return action[target, Random.Range(0,1)] + this.name + "!";
			}
		}
		return action[target, Random.Range(0, 3)] + this.name + "!";
	}

	// returns a different error code depending on which parameter is correct
	// returns 0 if correct, another number otherwise
	public int CheckInstruction(int target, String name, int direction) {
		if (this.target == target) {
			if (String.Equals(this.name,name)) {
				if(this.direction == direction) {
					return 1; //correct comparision
				}
				return -1; //correct tool, name, wrong direction
			}
			return -1; // correct tool type, wrong name
		}
		return -1; // wrong tool type
	}

	// returns the displayText
	public string getDisplayText() {
		return this.displayText;
	}
}

