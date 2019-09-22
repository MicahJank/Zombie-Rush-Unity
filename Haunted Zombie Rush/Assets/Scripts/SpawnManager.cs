using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpawnManager : MonoBehaviour {

    [SerializeField] GameObject coin;

    public static SpawnManager instance;

    void Awake() {
        Assert.IsNotNull(coin, "coin is null, check that a game object has been set on the SpawnManager script.");
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
    //    StartCoroutine(SpawningObjects());
        InvokeRepeating("SpawnObjects", 0.1f, 2f);
    }

    // Update is called once per frame
    void Update() {

    }

    public void spawnObject(Vector3 locationToSpawn, GameObject objToSpawn) {
        objToSpawn = Instantiate(objToSpawn); 
        objToSpawn.transform.position = locationToSpawn; 
    }

    private void SpawnObjects() {
        if(GameManager.instance.PlayerActive) {
            spawnObject(new Vector3(12.94f, Random.Range(0.0f, 10.0f), 8.94f), coin);
        }
    }
}
