using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {

    [SerializeField] private float objectSpeed = 4;
    [SerializeField] private float resetPosition = -12;
    [SerializeField] private float startPosition = 84;

    // initialPosition is used for when the game restarts all Objects can be reset to their starting positions again
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start() {
        initialPosition = transform.position;

    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.GameRestart) {
            Debug.Log("Reset is being called");
            ChangePosition(transform, initialPosition);
        } else {
        MoveObject();
        }
    }

    protected virtual void MoveObject() {

        // If the GameOver bool (found inside the GameManager class) is false ONLY THEN should the platform and objects move
        if(!GameManager.instance.GameOver) {
            transform.position += (Vector3.left * (objectSpeed * Time.deltaTime));

            if(transform.localPosition.x <= resetPosition) {
                Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }  
        
        
         
       
    }

    // Changes the position of the Object when called, requires a position to move to and the current objects transform to be passed in
    protected virtual void ChangePosition(Transform objTransform, Vector3 positionToMove) {
        objTransform.position = positionToMove;
       
    }
}
