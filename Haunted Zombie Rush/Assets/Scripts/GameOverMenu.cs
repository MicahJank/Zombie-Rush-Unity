using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    private Canvas gameOverMenu;
    // Start is called before the first frame update
    void Start() {
        gameOverMenu = GetComponentInChildren<Canvas>();
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.GameOver) {
            gameOverMenu.enabled = true;
        } else {
            gameOverMenu.enabled = false;
        }
    }
}
