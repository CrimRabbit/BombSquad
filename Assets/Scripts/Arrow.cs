using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	public int direction; //-1 is left, 1 is right
	public Sprite normal;
	public Sprite highlighted;

	Arrow (int direction) {
		this.direction = direction;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
