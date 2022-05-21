using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locksnow : MonoBehaviour
{
    Quaternion InitRot;
    Vector3 PlayerOffset = new Vector3(0, 14, 0);
    // Start is called before the first frame update
    void Start()
    {
        InitRot = transform.rotation;
    }
    
    void Update()
    {
        if(Player.instance != null) {
            
            transform.position = Player.instance.transform.position + PlayerOffset;
        }
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = InitRot;
    }
}
