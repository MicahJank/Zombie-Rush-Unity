using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class Player : MonoBehaviour {

    [SerializeField] private float jumpforce = 100f;

    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;

    private Animator anim;
    private Rigidbody rigidbody;
    private AudioSource audioSource;

    private bool jump = false;

    // Awake is called before Start
    void Awake() {
        // Assertions are helpful in that we can make sure all our fields like 'sfxJump' actually have a value before playing the game
        Assert.IsNotNull(sfxJump, "sfxJump is Null - make sure it has a value in the unity inspector");
        Assert.IsNotNull(sfxDeath, "sfxDeath is Null - make sure it has a value in the unity inspector");
    }

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if(!GameManager.instance.GameOver && GameManager.instance.GameStart) {
            CharacterMovement();
        }
    }

    void CharacterMovement() {
        // checks to see if the left mouse button has been clicked, if it has then we can play the animation. Also we let the game know that the player has jumped by setting
        // the jump bool to true and turning on the gravity.
        if(Input.GetMouseButtonDown(0)) {
            anim.Play("Jump");
            audioSource.PlayOneShot(sfxJump);
            rigidbody.useGravity = true;
            jump = true;
            if(!GameManager.instance.PlayerActive) {
                GameManager.instance.PlayerStartedGame();
            }
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

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "obstacle") {
            rigidbody.AddForce(new Vector2(-50, 20), ForceMode.Impulse); // Applies the push back when the player hits an obstacle
            rigidbody.detectCollisions = false; // turns off collisions after it has hit the obstacle, this way it wont collide anymore
           audioSource.PlayOneShot(sfxDeath); 
           GameManager.instance.PlayerCollided();
        }
    }
}
