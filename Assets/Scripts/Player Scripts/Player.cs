using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    // Start is called before the first frame update
    void Awake() {

        DontDestroyOnLoad(this);

        if (instance == null)
            instance = this;
        else
		{
            Destroy(gameObject);
            return;
		}
        
    }
}
