using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStart = false;
    private bool gameRestart = false;

    public bool PlayerActive {
        get { return playerActive; }
    }

    public bool GameOver {
        get { return gameOver; }
    }

    public bool GameStart {
        get { return gameStart; }
    }

    public bool GameRestart {
        get { return gameRestart; }
    }

public static GameManager instance = null;

    void Awake() {
        //Assertions
        Assert.IsNotNull(mainMenu, "mainMenu is null, check that it has been assigned a GameObject in the unity inspector.");
        Assert.IsNotNull(gameOverMenu, "gameOverMenu is null, check that it has been assigned a GameObject in the unity inspector.");

        if(instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCollided() {
        gameOver = true;
        gameOverMenu.SetActive(true);
        playerActive = false;
    }

    public void PlayerStartedGame() {
        playerActive = true;
        gameRestart = false;
    }

    public void EnterGame() {
        mainMenu.SetActive(false);
        gameStart = true;
    }

    public void RestartGame() {
       gameOver = false;
       gameRestart = true;
       gameOverMenu.SetActive(false);
    }
}
