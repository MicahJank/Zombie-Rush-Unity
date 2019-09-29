using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private Text scoreText;
    private int scoreNum = 0;

    public static ScoreManager instance = null;

    // Start is called before the first frame update
    void Start() {
        instance = this;
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = $"Score: {scoreNum}";
        if(GameManager.instance.GameRestart) {
            scoreNum = 0;
        }
    }

    public void updateScore() {
        scoreNum++;
    }
}
