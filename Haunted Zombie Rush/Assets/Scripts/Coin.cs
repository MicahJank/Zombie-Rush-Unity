using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Coin : Object {

    [SerializeField] private float rotationSpeed;

    private AudioSource audioSource;
    private MeshRenderer coinRenderer;

    [SerializeField] private AudioClip sfxCoin;

    void Awake() {
        Assert.IsNotNull(sfxCoin, "sfxCoin is null, check that the sound effect for the coin has been added in the unity inspector");
    }

    // Start is called before the first frame update
    void Start() {
       audioSource = GetComponent<AudioSource>();
       coinRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.PlayerActive) {
            MoveObject();
        }

        Rotate(transform, rotationSpeed);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            audioSource.PlayOneShot(sfxCoin);
            coinRenderer.enabled = false;
            DestroyObject(gameObject, 1f);
        }
    }
}
