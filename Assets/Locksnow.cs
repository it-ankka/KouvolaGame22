using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locksnow : MonoBehaviour
{
    Quaternion InitRot;
    Vector3 InitPos;
    // Start is called before the first frame update
    void Start()
    {
        InitRot = transform.rotation;
        InitPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = InitRot;
    }
}
