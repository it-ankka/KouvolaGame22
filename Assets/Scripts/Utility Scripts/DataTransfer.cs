using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTransfer : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(this);
    }
}
