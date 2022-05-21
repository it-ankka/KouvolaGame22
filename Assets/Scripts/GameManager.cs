using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum SceneName 
    {
        OverworldScene,
        BarScene,
        MainMenuScene,
        PauseMenuScene
    }

    public static GameManager instance;
    public GameObject PlayerPrefab;
    string curPlayerSpawnId { get; set; }
    bool isInitialScene = true;
    // Start is called before the first frame update
    void onSceneLoaded(Scene scene, LoadSceneMode mode) {
        Scene oldScene = SceneManager.GetActiveScene();
        SceneManager.SetActiveScene(scene);
        SceneManager.UnloadSceneAsync(oldScene);

        initializePlayerInScene();
            
    }
    
    void initializePlayerInScene() 
    {
        bool playerAlreadyExists = Player.instance != null;
        if(!playerAlreadyExists) {
            GameObject p = Instantiate(PlayerPrefab);
            p.name = PlayerPrefab.name;
        }

        // Don't place player in at spawnpoint if manually placed in the scene
        if(!playerAlreadyExists || !isInitialScene) {
            GameObject spawnPoint = GameObject.Find(curPlayerSpawnId);
            if(spawnPoint == null) {
                Debug.LogWarning("SPAWNPOINT WITH ID: " + curPlayerSpawnId + " NOT FOUND. USING DEFAULT SPAWN POINT.");
                spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
            }   

            Transform spawnLocation = spawnPoint.transform;
            CharacterController controller = Player.instance.GetComponent<CharacterController>();
            controller.enabled = false;
            Player.instance.transform.position = spawnLocation.position;
            Player.instance.transform.rotation = spawnLocation.rotation;
            controller.enabled = true;
        }
    }
    
    public void changeScene(SceneName sceneName, string playerSpawnId = null) {
        instance.curPlayerSpawnId = playerSpawnId;
        SceneManager.LoadScene(sceneName.ToString(), LoadSceneMode.Additive);
        isInitialScene = false;
    }
    
    void Awake() {
        curPlayerSpawnId = GameObject.FindGameObjectWithTag("Respawn").name;
        SceneManager.sceneLoaded += onSceneLoaded;

        if (instance == null)
            instance = this;
        else
		{
            Destroy(gameObject);
            return;
		}
        
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
