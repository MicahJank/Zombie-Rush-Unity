using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {

    [SerializeField] private float objectSpeed = 4;
    [SerializeField] private float resetPosition = -12;
    [SerializeField] private float startPosition = 84;
    
    private bool reset = false;

    // initialPosition is used for when the game restarts all Objects can be reset to their starting positions again
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start() {
        initialPosition = transform.position;
        Debug.Log(initialPosition);

    }

    // Update is called once per frame
    void Update() {
        MoveObject();
    }

    protected virtual void MoveObject() {

        if(GameManager.instance.GameRestart) {
            ResetPosition();
        }


        // If the GameOver bool (found inside the GameManager class) is false ONLY THEN should the platform and objects move
        if(!GameManager.instance.GameOver) {
            transform.position += (Vector3.left * (objectSpeed * Time.deltaTime));

            if(transform.localPosition.x <= resetPosition) {
                Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }  
        
        
         
       
    }

    // reset the position of the Object if the GameManagers GameRestart bool is true
    void ResetPosition() {
        transform.position = initialPosition;
       
    }
}
