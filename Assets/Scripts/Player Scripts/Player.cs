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
    public void disablePlayerControls() {
        instance.GetComponent<Interact>().enabled = false;
        instance.GetComponent<CharacterController>().enabled = false;
        Camera.main.GetComponent<MouseLook>().enabled = false;
    }
    
    public void enablePlayerControls() 
    {
        instance.GetComponent<Interact>().enabled = true;
        instance.GetComponent<CharacterController>().enabled = true;
        Camera.main.GetComponent<MouseLook>().enabled = true;
    }
}
