using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Tool : MonoBehaviour {
    public int toolID;
    public Vector3 position;
    public int currentTargetID;
    public int selectedDirection;

    public float posX;
    public float posY;
    public Vector2 mousePos;
    public bool moving;
    public Transform ToolButton;
    public Rigidbody2D stat;

    public GameObject[] arrows;

    public GameObject leftArrow;
    public GameObject rightArrow;

    public Vector3 inflated;
    public Vector3 normal;

    public GameObject target;
    public int rotate;
    public int count;
    public int toCut;
    public int cut;

    void Start() {
        target = new GameObject("Placeholder");
        moving = false;
        currentTargetID = -1;
        selectedDirection = 0; //-1 is left, 1 is right
        rotate = 0;
        count = 0;
        cut = 0;
        toCut = 0;
        /*
        inflated = new Vector3(1.2f, 1.2f, 1.0f);
        normal = new Vector3(1, 1, 1);
        */
    }

    void Update(){
        if (rotate != 0){
            if (count < 40){
                target.transform.Rotate( new Vector3( 0, 0, -rotate * 9 ) );
                count++;
            }
            else{
                target.transform.localRotation = (new Quaternion( 0, 0, 0, 0) );
                rotate = 0;
                count = 0;
            }
            if (cut != 0){
                toCut = 0;
                target.GetComponent<SpriteRenderer>().sprite = ((Target)(target).GetComponent(typeof(Target))).cut;
                ((Target)(target).GetComponent(typeof(Target))).isCut = true;
            }
        }
    }

    // after a tool has been used, we can call this method to bring it back to its original position
    public void resetPosition() {
        this.ToolButton.position = this.position;
    }

    void setPolygonCollider(GameObject target){
        //(target.GetComponent<PolygonCollider2D> ()).enabled = true;
        //(target.GetComponent<CircleCollider2D> ()).enabled = false;
    }

    void setCircleCollider(GameObject target){
        //(target.GetComponent<CircleCollider2D> ()).enabled = true;
        //(target.GetComponent<PolygonCollider2D> ()).enabled = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {//highlight and stay highlighted
        if (currentTargetID == -1 && (coll.gameObject.tag == "targetArrow" || coll.gameObject.tag == "targetNormal" || coll.gameObject.tag == "targetWire")) {
            target = coll.gameObject;
            currentTargetID = ((Target)(target).GetComponent(typeof(Target))).targetID;
            selectedDirection = 0;
            toCut = 0;
            if (!((Target)(target).GetComponent(typeof(Target))).isCut) target.GetComponent<SpriteRenderer>().sprite = ((Target)(target).GetComponent(typeof(Target))).highlighted;
            if(target.tag == "targetArrow"){
                //setPolygonCollider(target);
                Destroy(leftArrow);
                leftArrow = Instantiate(arrows[0], coll.transform.position, Quaternion.identity) as GameObject;
                leftArrow.layer = LayerMask.NameToLayer("TargetArrow");
                Destroy(rightArrow);
                rightArrow = Instantiate(arrows[1], coll.transform.position, Quaternion.identity) as GameObject;
                rightArrow.layer = LayerMask.NameToLayer("TargetArrow");
            }
            if(target.tag == "targetWire"){
                toCut = 1;
            }
        }
        if (target.tag == "arrow"){
            if (selectedDirection == 0){
                selectedDirection = ((Arrow)(coll.gameObject).GetComponent(typeof(Arrow))).direction;
                coll.gameObject.GetComponent<SpriteRenderer>().sprite = ((Arrow)(coll.gameObject).GetComponent(typeof(Arrow))).highlighted;
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {//unhighlight
        if (coll.gameObject.tag == "targetArrow" && currentTargetID == ((Target)(coll.gameObject).GetComponent(typeof(Target))).targetID){
            Destroy(leftArrow);
            Destroy(rightArrow);
            coll.gameObject.GetComponent<SpriteRenderer>().sprite = ((Target)(coll.gameObject).GetComponent(typeof(Target))).normal;
            //setCircleCollider(target);
            selectedDirection = 0;
            currentTargetID = -1;
        }
        else if(coll.gameObject.tag == "targetNormal" && currentTargetID == ((Target)(coll.gameObject).GetComponent(typeof(Target))).targetID){
            coll.gameObject.GetComponent<SpriteRenderer>().sprite = ((Target)(coll.gameObject).GetComponent(typeof(Target))).normal;
            currentTargetID = -1;
        }
        else if(coll.gameObject.tag == "targetWire" && currentTargetID == ((Target)(coll.gameObject).GetComponent(typeof(Target))).targetID){
            if (cut == 0) coll.gameObject.GetComponent<SpriteRenderer>().sprite = ((Target)(coll.gameObject).GetComponent(typeof(Target))).normal;
            cut = 0;
            toCut = 0;
            currentTargetID = -1;
        }
        if (coll.gameObject.tag == "arrow"){
            coll.gameObject.GetComponent<SpriteRenderer>().sprite = ((Arrow)(coll.gameObject).GetComponent(typeof(Arrow))).normal;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (currentTargetID == -1 && (coll.gameObject.tag == "targetArrow" || coll.gameObject.tag == "targetNormal" || coll.gameObject.tag == "targetWire")) {
            target = coll.gameObject;
            currentTargetID = ((Target)(target).GetComponent(typeof(Target))).targetID;
            selectedDirection = 0;
            toCut = 0;
            if (!((Target)(target).GetComponent(typeof(Target))).isCut) target.GetComponent<SpriteRenderer>().sprite = ((Target)(target).GetComponent(typeof(Target))).highlighted;
            if(target.tag == "targetArrow"){
                //setPolygonCollider(target);
                Destroy(leftArrow);
                leftArrow = Instantiate(arrows[0], coll.transform.position, Quaternion.identity) as GameObject;
                leftArrow.layer = LayerMask.NameToLayer("TargetArrow");
                Destroy(rightArrow);
                rightArrow = Instantiate(arrows[1], coll.transform.position, Quaternion.identity) as GameObject;
                rightArrow.layer = LayerMask.NameToLayer("TargetArrow");
            }
            if(target.tag == "targetWire"){
                toCut = 1;
            }
        }
        if (coll.gameObject.tag == "arrow"){
            if (selectedDirection == 0){
                selectedDirection = ((Arrow)(coll.gameObject).GetComponent(typeof(Arrow))).direction;
                coll.gameObject.GetComponent<SpriteRenderer>().sprite = ((Arrow)(coll.gameObject).GetComponent(typeof(Arrow))).highlighted;
            }
        }
    //handle additional arrows on this object
        //Debug.Log("TestCollide coll stay - "+this.gameObject.name);
        //if mouse down and collide w/, that means use holding there
        //to spawn arrows and extra hitbox on said obj.
        //Debug.Log("True");
        //need to edit for highlights
        //ClientGameManager gc = gameObject.GetComponent(typeof(ClientGameManager)) as ClientGameManager;
        //ClientBoardManager bm = gameObject.GetComponent(typeof(ClientBoardManager)) as ClientBoardManager;
        //gc.score += 1;
        //Destroy(coll.gameObject);//destroy the current gameobject
        //bm.SpawnNew(coll.gameObject.transform.position);// write in game controller to get a new gameobject
        
        /*
        else if(coll.gameObject.name == "3wayscrewdriver(Clone)") //replace with legit obj name
        {//just collide w/, that means user has let up mouse
            Debug.Log("collide let up");
        }
        else 
        {//released on the wrong thing
            Debug.Log("False");
            //coll.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(5);//edit what to happen here
            //((Tool)(this.gameObject).GetComponent(typeof(Tool))).resetPosition();
            //coll.gameObject.SetActive(true);
        }
        */
    }

    /*
    
    //public GameObject Tool;
    
    public override void OnStartClient() {
        //if (score == 100) // not sure what this does
        //    return;
        
        // add this object into the singleton
        //if (!BombGame.singleton.tools.Contains(this.gameObject)) {
        //    BombGame.singleton.tools.Add(this.gameObject);
        }
    }
    
    // this method probably won't be called?
    //public override void OnNetworkDestroy() {
        //InvadersGame.singleton.aliens.Remove(this.gameObject);
    //}
    
    // indicate which tool it is, and where its position is
    //public void Setup(int toolID, Vector3 position) {
    //    this.toolID = toolID;
    //    this.position = position;
    //}
    
    // called at fixed time intervals, rather than every frame
    // probably won't need to be called
    void FixedUpdate() {
        if (NetworkServer.active && canShoot) {
            if (Random.Range(0,1.0f) > 0.996f)
            {
                GameObject myBullet = (GameObject)GameObject.Instantiate(bulletPrefab, transform.position - Vector3.up, Quaternion.identity);
                NetworkServer.Spawn(myBullet);
            }
        }
    }
    
    // A Custom Attribute that can be added to member functions of NetworkBehaviour scripts, to make them only run on servers, but not generate warnings.
    [ServerCallback]
    void OnTriggerEnter2D(Collider2D collider)
    {
        Shield hitShield = collider.gameObject.GetComponent<Shield>();
        if (hitShield != null)
        {
            NetworkServer.Destroy(hitShield.gameObject);
        }
    }*/
}
