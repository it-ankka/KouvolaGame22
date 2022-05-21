using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionInteraction : MonoBehaviour, Interactable
{
    public GameManager.SceneName nextScene;
    public string playerSpawnId;
    
    // Start is called before the first frame update
    public void interact() {
        Debug.Log("NEXT SCENE: " + nextScene);
        GameManager.instance.changeScene(nextScene, playerSpawnId);
    }
}
