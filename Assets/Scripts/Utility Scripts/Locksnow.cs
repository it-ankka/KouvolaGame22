using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locksnow : MonoBehaviour
{
    Vector3 PlayerOffset = new Vector3(0, 14, 0);
    // Start is called before the first frame update
    
    void Update()
    {
        if(Player.instance != null) {
            
            transform.position = Player.instance.transform.position + PlayerOffset;
        }
        
    }

}
