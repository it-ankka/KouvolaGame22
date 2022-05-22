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
    public float transitionTime = 1f;
    Animator transition;
    string curPlayerSpawnId { get; set; }
    bool isInitialScene = true;
    // Start is called before the first frame update
    void onSceneLoaded(Scene scene, LoadSceneMode mode) {
        Scene oldScene = SceneManager.GetActiveScene();
        SceneManager.SetActiveScene(scene);
        SceneManager.UnloadSceneAsync(oldScene);

        initializePlayerInScene();
        if(transition) transition.SetTrigger("Loaded");
        Player.instance.GetComponent<CharacterController>().enabled = true;
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
    
    public void changeScene(SceneName sceneName, string playerSpawnId = null) 
    {
        isInitialScene = false;
        instance.curPlayerSpawnId = playerSpawnId;
        StartCoroutine(LoadScene(sceneName));
    }
    
    IEnumerator LoadScene(SceneName sceneName) 
    {
        Player.instance.GetComponent<CharacterController>().enabled = false;
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName.ToString(), LoadSceneMode.Additive);
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
        transition = GameObject.Find("CrossFade").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
