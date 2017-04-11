using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollide : MonoBehaviour {

	public Rigidbody2D stat;


	// Use this for initialization
	void Start () {
		stat = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
//		if(stat.IsTouching()){
//			Debug.Log("touching");
//		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{//highlight and stay highlighted
		Debug.Log("collision enter");
	}

	void OnCollisionExit2D(Collision2D coll)
	{//unhighlight

		Debug.Log("collision exit");
	}

	IEnumerator OnCollisionStay2D(Collision2D coll)
    {//handle additional arrows on this object
    	Debug.Log("TestCollide coll stay - "+this.gameObject.name);
        if (Input.GetMouseButton(0) && coll.gameObject.name == "3wayscrewdriver(Clone)")
        {//if mouse down and collide w/, that means use holding there
        	//to spawn arrows and extra hitbox on said obj.
        	Debug.Log("True");
        	//need to edit for highlights
            ClientGameManager gc = gameObject.GetComponent(typeof(ClientGameManager)) as ClientGameManager;
            ClientBoardManager bm = gameObject.GetComponent(typeof(ClientBoardManager)) as ClientBoardManager;
            gc.score += 1;
            Destroy(coll.gameObject);//destroy the current gameobject
            bm.SpawnNew(coll.gameObject.transform.position);// write in game controller to get a new gameobject
        }
        else if(coll.gameObject.name == "3wayscrewdriver(Clone)") //replace with legit obj name
        {//just collide w/, that means user has let up mouse
        	Debug.Log("collide let up");
        }
        else 
        {//released on the wrong thing
        	Debug.Log("False");
            //coll.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(5);//edit what to happen here
            ((Tool)(coll.gameObject).GetComponent(typeof(Tool))).resetPosition();
            //coll.gameObject.SetActive(true);
        }
    }
}
