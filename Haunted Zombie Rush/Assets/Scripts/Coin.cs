using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Object {

    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.PlayerActive) {
            MoveObject();
        }

        Rotate(transform, rotationSpeed);
    }
}
