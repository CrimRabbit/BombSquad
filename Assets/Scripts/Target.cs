using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Target : MonoBehaviour {
    //private GameInstruction instruction;

    public int targetID;
    public Sprite normal;
    public Sprite highlighted;
    public Sprite cut;
    public bool isCut = false;
    public int count = 0;

    Target(int targetID, Vector3 position) {
        this.targetID = targetID;
    }

    void Update(){
        if (isCut){
            count++;
            if (count >= 300){
                count = 0;
                isCut = false;
                this.GetComponent<SpriteRenderer>().sprite = this.normal;
            }
        }
    }

    // upon completion of an instruction (either this or another one), the old instruction will be updated with a null, and a target with a null instruction will be updated with a new GameInstruction object
    /*
    public void UpdateInstruction(GameInstruction newInstruction) {
        this.instruction = newInstruction;
    }
    */
}