using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrag : MonoBehaviour {

    public Transform ToolButton;
    float posX;
    float posY;
    Vector2 mousePos;
    bool moving;
    RaycastHit2D hit;
    public Score score;
    

    // Use this for initialization
    void Start () {
        Input.multiTouchEnabled = false;
    }
    
    // Update is called once per frame
    void Update () {
        if(moving){
            if(hit && hit.transform.tag == "tool"){
                //Debug.Log(hit.collider.name);
                Vector2 mousePosit = new Vector2(Input.mousePosition.x + 50,Input.mousePosition.y + 50);
                hit.transform.position = mousePosit;
                //Debug.Log(gameObject.name);
            }

             

            
            if(!Input.GetMouseButton(0)){
                if (hit.transform.tag == "tool") {
                    if (((Tool)(hit.transform.gameObject).GetComponent (typeof(Tool))).currentTargetID != -1) {
                        performAction (((Tool)(hit.transform.gameObject).GetComponent (typeof(Tool))).toolID, ((Tool)(hit.transform.gameObject).GetComponent (typeof(Tool))).currentTargetID, ((Tool)(hit.transform.gameObject).GetComponent (typeof(Tool))).selectedDirection);
                        if(((Tool)(hit.transform.gameObject).GetComponent(typeof(Tool))).toolID == ((Tool)(hit.transform.gameObject).GetComponent(typeof(Tool))).currentTargetID){
                            ((Tool)(hit.transform.gameObject).GetComponent(typeof(Tool))).rotate = ((Tool)(hit.transform.gameObject).GetComponent(typeof(Tool))).selectedDirection;
                            ((Tool)(hit.transform.gameObject).GetComponent(typeof(Tool))).cut = ((Tool)(hit.transform.gameObject).GetComponent(typeof(Tool))).toCut;
                        }
                    }
                    ((Tool)(hit.transform.gameObject).GetComponent (typeof(Tool))).resetPosition ();
                }
                moving = false;
                hit = new RaycastHit2D();
            }
            
        }
        else if(Input.GetMouseButtonDown(0)){
            var mousePosition = Input.mousePosition; //gets current mouse position
             if (hit = Physics2D.Raycast(mousePosition, mousePosition, 0.5f)){ //fires a ray from camera to detect object
                moving = true; //set moving to true to allow movement
            }
            //Debug.Log(((Tool)(hit.transform.gameObject).GetComponent(typeof(Tool))).toolID);
        }
//        posX = transform.position.x;
//        posY = transform.position.y;
    }

    //void OnMouseDown()
    //{
//        Debug.Log("mosuedown");
//        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
//        offset = scanPos - Camera.main.ScreenToWorldPoint(
//         new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    //}
//

/*
    IEnumerator OnCollisionStay2D(Collision2D coll)
    {
        Debug.Log("TestCollide coll - "+coll.gameObject.name);
        if (coll.gameObject.name == "3wayscrewdriver(Clone)")
        {
            Debug.Log("True");
            ClientGameManager gc = gameObject.GetComponent(typeof(ClientGameManager)) as ClientGameManager;
            ClientBoardManager bm = gameObject.GetComponent(typeof(ClientBoardManager)) as ClientBoardManager;
            gc.score += 1;
            Destroy(coll.gameObject);//destroy the current gameobject
            bm.SpawnNew(coll.gameObject.transform.position);// write in game controller to get a new gameobject
        }
        else
        {
            Debug.Log("False");
            coll.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(5);//wait for 10 seconds
            coll.gameObject.SetActive(true);
        }
    }
    */

    void performAction(int toolID, int targetID, int direction){
        if (toolID == targetID){
            Debug.Log(Score.Singleton.currentScore);
            Score.Singleton.GainScore(1);
            Debug.Log("CORRECT ACTIONSNDNFF"); //still need to compare with instructions
        }
        else Debug.Log("WRONG ACTION");
    }

}
