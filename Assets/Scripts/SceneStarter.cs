using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStarter : MonoBehaviour
{
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        foreach (var pf in prefabs)
        {
            if(GameObject.Find(pf.name) == null) {
               GameObject go =  Instantiate(pf);
               go.name = pf.name;
            }
        }
        Destroy(this.gameObject);
    }
}
