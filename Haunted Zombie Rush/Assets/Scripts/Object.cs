using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour {

    [SerializeField] float objectSpeed = 4;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));
    }
}
