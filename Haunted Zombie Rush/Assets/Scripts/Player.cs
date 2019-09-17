using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float jumpforce = 100f;

    private Animator anim;
    private Rigidbody rigidbody;

    private bool jump = false;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // checks to see if the left mouse button has been clicked, if it has then we can play the animation. Also we let the game know that the player has jumped by setting
        // the jump bool to true and turning on the gravity.
        if(Input.GetMouseButtonDown(0)) {
            anim.Play("Jump");
            rigidbody.useGravity = true;
            jump = true;
        }
    }

    // any time you are dealing with physics and force, you need to put that code into fixed update to fix issues with frame rates messing up the forces
    void FixedUpdate() {
        if(jump) {
           jump = false; 
           rigidbody.velocity = new Vector2(0, 0);
           rigidbody.AddForce(new Vector2(0, jumpforce), ForceMode.Impulse);
        }
    }
}
