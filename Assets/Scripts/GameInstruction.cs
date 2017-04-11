using System;
using Random = UnityEngine.Random;

public class GameInstruction {
	int id;
	private int tool;
	private int target;
	private int targetValue;
	string displayText;

	public string[,] toolNames = {
		{"3-Way Screwdriver", "Mecedes Turnscrew", "Tri-point Rivet"},
		{"5-Way Screwdriver", "Star Turnscrew", "Five-point Rivet"},
		{"Flat Head Screwdriver", "Pokeball Turnscrew", "Straight Rivet"},
		{"Phillips Screwdriver", "Plus Turnscrew", "Cross Rivet"},
		{"Square Screwdriver", "Cubic Turnscrew", "Four-sided Rivet"},
		{"Hexagonal Wrench", "Benzene Kernel", "Honeycomb Cranium"},
		{"Pentagonal Wrench", "Penta Kernel", "Pentangular Cranium"},
		{"Square Wrench", "Cubic Kernel", "Four-sided Cranium"},
		{"Star Wrench", "Paragon Kernel", "Twinkle Little Cranium"},
		{"Triangle Wrench", "Trilateral Kernel", "Trigon Cranium"},
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
	};

	public string[,] targetNames = {
		{"3-Way Bolt", "Mecedes Pin", "Tri-point Rivet"},
		{"5-Way Bolt", "Star Pin", "Five-point Rivet"},
		{"Flat Head Bolt", "Pokeball Pin", "Straight Rivet"},
		{"Phillips Bolt", "Plus Pin", "Cross Rivet"},
		{"Square Bolt", "Cubic Pin", "Four-sided Rivet"},
		{"Hexagonal Nut", "Benzene Kernel", "Honeycomb Cranium"},
		{"Pentagonal Nut", "Penta Kernel", "Pentangular Cranium"},
		{"Square Nut", "Cubic Kernel", "Four-sided Cranium"},
		{"Star Nut", "Paragon Kernel", "Twinkle Little Cranium"},
		{"Triangle Nut", "Trilateral Kernel", "Trigon Cranium"},
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

