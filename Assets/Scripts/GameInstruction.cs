using System;
using Random = UnityEngine.Random;

public class GameInstruction {
	int id;
	private int tool;
	private int target;
	private int targetValue;
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
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
		{"Loosen the ", "Mash the ", "Tighten the ", "Screw the "},
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

	public GameInstruction(int tool, int target, int targetValue) {
		this.tool = tool;
		this.target = target;
		this.targetValue = targetValue;
		this.displayText = GenerateInstructionText(target);
	}

	private string GenerateInstructionText(int target) {
		return action[target, Random.Range(0, 3)] + targetNames[target, Random.Range(0, 3)] + "!";
	}

	// returns a different error code depending on which parameter is correct
	// returns 0 if correct, another number otherwise
	public int CheckInstruction(int tool, int target, int targetValue) {
		if (this.tool == tool) {
			if (this.target == target) {
				if (this.targetValue == targetValue) {
					return 0;
				}
				return 1;
			}
			return 2;
		}
		return 3;
	}

	// returns the displayText
	public string getDisplayText() {
		return this.displayText;
	}
}

