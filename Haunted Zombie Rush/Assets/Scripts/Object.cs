using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {

    [SerializeField] private float objectSpeed = 4;
    private float resetPosition = -12;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

        if(transform.localPosition.x <= resetPosition) {
            Vector3 newPos = new Vector3(84, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
