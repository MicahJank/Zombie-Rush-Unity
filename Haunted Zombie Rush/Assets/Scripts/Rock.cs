using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Object {

    [SerializeField] Vector3 topPosition; //defined in unity editor
    [SerializeField] Vector3 bottomPosition; // defined in unity editor

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    private Vector3 initialRockPosition;

    // Start is called before the first frame update
    void Start() {
        initialRockPosition = transform.position;
        StartCoroutine(Move(bottomPosition));
    }

    void Update() {
        if(GameManager.instance.PlayerActive) {
            MoveObject();
        }

        if(GameManager.instance.GameRestart) {
            ChangePosition(transform, initialRockPosition);
        }

        Rotate();
    }

    IEnumerator Move(Vector3 target) {
        // the while loop will only run if the Rocks transform is > 0.20f - this works for both the up and down values because we are using the Mathf.Abs which will keep the 
        // values always positive.
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f) {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += (direction * speed) * Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(0.5F);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;
        StartCoroutine(Move(newTarget));
    }

    // Rotates the Rock around its y axis
    void Rotate() {
        transform.Rotate(0, (rotationSpeed * Time.deltaTime), 0);
    }
}
