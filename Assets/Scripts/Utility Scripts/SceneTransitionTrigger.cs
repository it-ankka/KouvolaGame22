using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionTrigger : MonoBehaviour
{
    public GameManager.SceneName nextScene;
    public string playerSpawnId;
    // public int spawnPointId;
    
    void Awake() {
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            Debug.Log("NEXT SCENE: " + nextScene);
            GameManager.instance.changeScene(nextScene, playerSpawnId);
        }
    }
}
