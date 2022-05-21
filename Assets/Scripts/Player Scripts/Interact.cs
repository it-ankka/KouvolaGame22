using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    GameObject interactTarget;
    public float maxInteractDistance = 10.0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            RaycastHit hit;
            
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxInteractDistance, LayerMask.GetMask("Interactable"))) {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * hit.distance, Color.red);
                interactTarget = hit.collider.gameObject;
                Interactable interactable =  interactTarget.GetComponent<Interactable>();
                if(interactable != null) interactable.interact();
            }
        }
    }
}
