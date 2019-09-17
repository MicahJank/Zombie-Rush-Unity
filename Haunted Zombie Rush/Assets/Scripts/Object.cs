using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {

    [SerializeField] private float objectSpeed = 4;
    [SerializeField] private float resetPosition = -12;
    [SerializeField] private float startPosition = 84;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        MoveObject();
    }

    protected virtual void MoveObject() {
        transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

        if(transform.localPosition.x <= resetPosition) {
            Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
